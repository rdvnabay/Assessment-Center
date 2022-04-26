namespace EntityFrameworkUsage.Models
{
    public class QueryString
    {
        public QueryString(string search, string sortBy)
        {
            _search = search;
            _sortBy = sortBy;  
        }
        private string _search { get; set; }
        private string _sortBy { get; set; }


        public string LinkToSort()
        {
            if (!string.IsNullOrWhiteSpace(_search))
                return $"?search={_search}&sortBy";

            return $"?sortBy";
        }

        public string LinkToPagination()
        {
            if (!string.IsNullOrWhiteSpace(_search) && !string.IsNullOrEmpty(_sortBy))
                return $"?search={_search}&sortBy={_sortBy}&page";

            if (!string.IsNullOrWhiteSpace(_search) && string.IsNullOrEmpty(_sortBy))
                return $"?search={_search}&page";

            if (string.IsNullOrWhiteSpace(_search) && !string.IsNullOrEmpty(_sortBy))
                return $"?sortBy={_sortBy}&page";

            return $"?page";
        }
    }
}