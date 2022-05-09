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
        public async Task<ActionResult<ComicBook>> Get(int id)
        {
            var comic = await _context.ComicBooks.FindAsync(id);
            if (comic == null)
                return BadRequest("Comic not found.");
            return Ok(comic);
        }

        [HttpPost("{idStart}/{idEnd}")]
        public async Task<ActionResult<List<ComicBook>>> AddBooks(ComicBook bookTemplate,int idStart, int idEnd) 
        { 
            for(int i = 0; i <= idEnd; i++)
            {
                var book = new ComicBook(bookTemplate);
                book.SeriesNumber = i;
                _context.ComicBooks.Add(book);
            }
            
            await _context.SaveChangesAsync();

            return Ok(await _context.ComicBooks.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<ComicBook>>> AddBook(ComicBook book)
        {
            _context.ComicBooks.Add(book);

            await _context.SaveChangesAsync().ContinueWith((res) => {
                for (int i = 0; i < book.Traits.Length; i++)
                    {
                        var trait = new CBTrait(book.Id, book.Traits[i]);
                        _context.CBTrait.Add(trait);
                    }
            });
            await _context.SaveChangesAsync();
            return Ok(await _context.ComicBooks.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ComicBook>>> Delete(int id)
        {
            var comic = await _context.ComicBooks.FindAsync(id);
            if (comic == null)
                return BadRequest("Comic not found.");

            _context.ComicBooks.Remove(comic);
            await _context.SaveChangesAsync();

            return Ok(await _context.ComicBooks.ToListAsync());
        }
    }
}
