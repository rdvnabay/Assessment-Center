using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeComplexity.Models
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> items, int count, int currentPage, int perPage)
        {
            CurrentPage = currentPage;
            PerPage = perPage;    
            TotalPages = (int)Math.Ceiling(count / (double)perPage);

            this.AddRange(items);
        }
        public int CurrentPage { get; private set; }
        public int PerPage { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public static PaginatedList<T> Load(IQueryable<T> source, int currentPage, int perPage)
        {
            var count = source.Count();
            var items = source.Skip((currentPage - 1) * perPage).Take(perPage).ToList();
            return new PaginatedList<T>(items, count, currentPage, perPage);
        }
    }
}