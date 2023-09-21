using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        static List<Book> list = new List<Book>();
        [HttpGet]

        public List<Book> GetBook()
        {
            
            for(int i=0; i < 5; i++)
            {
                Book book=new Book();
                book.BookID = i;
                book.Title = "Atomic Habits" + i;
                book.Cost = i * 100;
                book.AuthorName = "Author " + i;
                list.Add(book);
            }
            return list;    
        }
        [HttpPost]
        public int AddBook(Book book)
        {
            list.Add(book);
            return 1;
        }
        [HttpDelete]

        public void DeleteBook(int i)
        {
            list.RemoveAt((int)i);
        }
    }
}
