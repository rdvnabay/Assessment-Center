namespace EntityFrameworkUsage.Models
{
    public class QueryString
    {
        public QueryString(string search, int perPage)
        {
            _search = search;
            _perPage = perPage;
        }
        private string _search;
        private int _perPage;


        public string LinkToPerPage()
        {
            if (!string.IsNullOrWhiteSpace(_search))
                return $"?search={_search}&perPage";

            return $"?perPage";
        }

        public string LinkToPagination()
        {
            if (!string.IsNullOrWhiteSpace(_search) && _perPage > 0)
                return $"?search={_search}&perPage={_perPage}&page";

            if (!string.IsNullOrWhiteSpace(_search) && _perPage == 0)
                return $"?search={_search}&page";

            if (string.IsNullOrWhiteSpace(_search) && _perPage > 0)
                return $"?perPage={_perPage}&page";

            return $"?page";
        }
    }
}