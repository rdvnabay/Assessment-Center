namespace EntityFrameworkUsage.Models
{
    public class PageRequest
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 5;
    }
}