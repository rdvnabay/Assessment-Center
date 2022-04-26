using AssessmentLibrary;
using System.Collections.Generic;

namespace EntityFrameworkUsage.Models
{
    public class AccountViewModel
    {
        public List<Account> Accounts { get; set; }
        public Pagination Pagination { get; set; }
        public QueryString QueryString { get; set; }
    }
}