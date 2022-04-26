using AssessmentLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkUsage.DAL
{
    public class Repository : IRepository
    {
        //db access
        private readonly DbContext _db;

        public Repository()
        {
            _db = new DatabaseContext();
        }

        public IQueryable<Account> GetAccounts(Expression<Func<Account, bool>> predicate = null) => _db.Set<Account>();

        public void ImportAccounts(List<Account> accounts) => _db.Set<Account>().AddRange(accounts);

        public Account GetAccount(int id) => _db.Set<Account>().FirstOrDefault(x => x.Id == id);

        public void SaveChanges() => _db.SaveChanges();

        public void UpdateAccount(Account account) => _db.Entry(account).State = EntityState.Modified;
    }
}