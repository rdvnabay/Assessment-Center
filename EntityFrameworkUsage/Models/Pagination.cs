using System;

namespace EntityFrameworkUsage.Models
{
    public class Pagination
    {
        public Pagination(int totalItems, int currentPage, int perPage)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PerPage = perPage;
        }

        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / PerPage);
            }
        }
    }
}