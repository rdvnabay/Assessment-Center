using AssessmentLibrary;
using EntityFrameworkUsage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeComplexity.Models;

namespace TimeComplexity.Controllers
{
    public class HomeController : Controller
    {
        //some data
        private readonly List<Account> _dataList;
        private readonly Random _random;


        public HomeController()
        {
            //get your (random) data at controller initializing
            _dataList = GetData.GetDataList();
            _random = new Random();
        }

        /*
         * Controllers
         */
        public ActionResult Index(string search, int page = 1, int perPage = 25)
        {
            #region task 1.1
            /*
            * Find a specific amount of random objects in the fastest time possible and add them to List
            */
            var results = new List<Account>();

            #endregion

            //don´t alter the loop           
            for (int i = 0; i <= 2500; i++)
            {
                var account = FindAccount(_random.Next(0, 25000));
                results.Add(account);
            }


            #region task 1.3
            /*
             * create a view and list the results
             */
            #endregion

            #region task 1.4
            /*
             * create a pagination for 25, 50, 100 and ALL results per page (or custom input for page size 1-1000000)
            */

            if (!string.IsNullOrWhiteSpace(search))
                results = SearchByBalance(results, search);


            QueryString query = new QueryString(search, perPage);
            ViewBag.queryPerPage = query.LinkToPerPage();
            ViewBag.queryPagination = query.LinkToPagination();

            results = PaginatedList<Account>.Load(results.AsQueryable(), page, perPage);
            return View(results);

            #endregion
        }


        /*
         * Business Logic
         */
        #region task 1.2 + 1.5
        /*
        * Implement your search method and define the time complexity ( O(n), O(1), O(n²) ... ) 
        */
        private List<Account> SearchByBalance(List<Account> accounts, string search)
        {
            return accounts.Where(x => x.Balance.ToString().Contains(search)).ToList();
        }

        #region task 1.5 Your estimated time complexity
        //time complexity =    <--- Fill in here
        #endregion

        public Account FindAccount(int id) => _dataList.FirstOrDefault(x => x.Id == id);

        #endregion
    }
}