using AssessmentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EntityFrameworkUsage.DAL
{
    public interface IRepository
    {
        void ImportAccounts(List<Account> accounts);
        IQueryable<Account> GetAccounts(Expression<Func<Account, bool>> predicate = null);

        Account GetAccount(int id);
        void UpdateAccount(Account account);
        void SaveChanges();
    }
}