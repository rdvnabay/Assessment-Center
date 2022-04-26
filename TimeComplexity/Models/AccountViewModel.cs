using AssessmentLibrary;
using EntityFrameworkUsage.Models;

namespace TimeComplexity.Models
{
    public class AccountViewModel
    {
        public PaginatedList<Account> Accounts { get; set; }
        public QueryString QueryFilter { get; set; }
    }
}