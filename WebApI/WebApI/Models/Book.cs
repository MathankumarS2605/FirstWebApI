namespace WebApI.Models
{
    public class Book
    {
        public int BookID { set; get; }
        public string Title { set; get; } = string.Empty;
        public float Cost { set; get; }
        public string AuthorName { set; get; } = string.Empty;
    }
}
