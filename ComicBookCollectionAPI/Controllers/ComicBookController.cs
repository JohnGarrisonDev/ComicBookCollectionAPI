using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicBookCollectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicBookController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IComicBookRepo _bookRepo;

        public ComicBookController(DataContext context, IComicBookRepo bookRepo)
        {
            _context = context;
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<ComicBook>> Get()
        {
            var books =  _bookRepo.GetAllComicBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<ComicBook> Get(int id)
        {
            var comic =  _bookRepo.GetComicBook(id);
            if (comic == null)
                return BadRequest("Comic not found.");
            return Ok(comic);
        }

        [HttpPost("{idStart}/{idEnd}")]
        public ActionResult<List<ComicBook>> AddBooks(ComicBook bookTemplate,int idStart, int idEnd) 
        { 
            for(int i = 0; i <= idEnd; i++)
            {
                var book = new ComicBook(bookTemplate);
                book.SeriesNumber = i;
                _context.ComicBooks.Add(book);
            }
            
             _bookRepo.SaveChanges();

            return Ok( _bookRepo.GetAllComicBooks());
        }

        [HttpPost]
        public  ActionResult<IEnumerable<ComicBook>> AddBook(ComicBook book)
        {
            _bookRepo.CreateComicBook(book);

            //Need to fix this 
            _bookRepo.SaveChanges();
                for (int i = 0; i < book.Traits.Length; i++)
                    {
                        var trait = new CBTrait(book.Id, book.Traits[i]);
                        _context.CBTrait.Add(trait);
                    }
            _bookRepo.SaveChanges();
            return Ok( _bookRepo.GetAllComicBooks());
        }

        [HttpDelete("{id}")]
        public  ActionResult<List<ComicBook>> Delete(int id)
        {
            var comic =  _bookRepo.GetComicBook(id);
            if (comic == null)
                return BadRequest("Comic not found.");

            _bookRepo.DeleteComicBook(comic);
            _bookRepo.SaveChanges();

            return Ok(_bookRepo.GetAllComicBooks());
        }
    }
}
