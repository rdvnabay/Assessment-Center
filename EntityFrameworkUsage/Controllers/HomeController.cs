using AssessmentLibrary;
using EntityFrameworkUsage.DAL;
using EntityFrameworkUsage.Models;
using System;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;

namespace EntityFrameworkUsage.Controllers
{
    public class HomeController : Controller
    {
        //interface for db interaction
        private readonly IRepository _repo;

        public HomeController()
        {
            _repo = new Repository();
        }

        #region task 4.1 - 4.3
        public ActionResult Index(string search, PageRequest pageRequest, string sortBy, string order = "asc")
        {
            /*
            * show a pagination list with customizable pagesize
            * make the list sortable for every object attribute
            * make the list searchable for id
            * 
            * extra points: make it as fast and scalable as possible
            */
            ViewBag.Title = "all accounts in database";
            ViewBag.Order = order == "asc" ? "desc" : "asc";

            var list = _repo.GetAccounts();
            list = FilterList(list, search, sortBy, order);

            var viewModel = new AccountViewModel()
            {
                Accounts = list.Skip((pageRequest.Page - 1) * pageRequest.PerPage).Take(pageRequest.PerPage).ToList(),
                Pagination = new Pagination(list.Count(), pageRequest.Page, pageRequest.PerPage),
                QueryString = new QueryString(search, sortBy)
            };
            return View(viewModel);
        }

        private IQueryable<Account> FilterList(IQueryable<Account> list, string search, string sortBy, string order)
        {
            if (!string.IsNullOrWhiteSpace(search))
                list = list.Where(x => x.Id.ToString().Contains(search));


            if (sortBy == "Balance")
                list = order == "asc" ? list.OrderBy(x => x.Balance) : list.OrderByDescending(x => x.Balance);

            else if (sortBy == "Pin")
                list = order == "asc" ? list.OrderBy(x => x.Pin) : list.OrderByDescending(x => x.Pin);

            else if (sortBy == "Pan")
                list = order == "asc" ? list.OrderBy(x => x.Pan) : list.OrderByDescending(x => x.Pan);

            else
                list = order == "asc" ? list.OrderBy(x => x.Id) : list.OrderByDescending(x => x.Id);

            return list;
        }
        #endregion

        #region task 4.4
        public ActionResult Edit(int id)
        {
            var account = _repo.GetAccount(id);
            /*
             * make the objects from the index view editable
             * create an edit form view
             * 
             * write the needed repository methods and extend the interface
             */
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit(Account updateAccount)
        {
            var account = _repo.GetAccount((int)updateAccount.Id);

            if (account != null)
            {
                account.Balance = updateAccount.Balance;
                account.Pin = updateAccount.Pin;
                account.Pan = updateAccount.Pan;

                _repo.UpdateAccount(account);
                _repo.SaveChanges();
            }

            string message = "Record updated successfully";
            return View("Success", model: message);
        }
        #endregion

        #region task 3
        public ActionResult Import()
        {
            /*
             * import some data to your database             
             */
            try
            {
                var data = GetData.GetDataList();
                //alway use the transactionScope if necessary
                using (var tx = new TransactionScope())
                {
                    _repo.ImportAccounts(data.GetRange(0, 5));
                }
                _repo.SaveChanges();
            }

            catch (Exception ex)
            {
                /*
                 * show view with error, and exeption message / stacktrace
                 */
                return View("Error", ex);
            }

            /*
             * show view with success notification
             */
            string message = "Records imported successfully";
            return View("Success", model: message);
        }
        #endregion

        public ActionResult Success(string message) => View(message);
        public ActionResult Error(Exception ex) => View("Shared/Error", ex);
    }
}
