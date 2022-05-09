using Microsoft.AspNetCore.Mvc;

namespace ComicBookCollectionAPI.Data
{
    public class ComicBookRepo : IComicBookRepo
    {
        private readonly DataContext _context;

        public ComicBookRepo(DataContext context)
        {
            _context = context;
        }
        public void CreateComicBook(ComicBook comic)
        {
          if (comic == null)
            {
                throw new ArgumentNullException(nameof(comic));
            }
          _context.ComicBooks.Add(comic);
        }

        public void DeleteComicBook(ComicBook comic)
        {
            if (comic == null)
            {
                throw new ArgumentNullException(nameof(comic));
            }
            _context.ComicBooks.Remove(comic);
        }

        public IEnumerable<ComicBook> GetAllComicBooks()
        {
            return  _context.ComicBooks.ToList();
        }

        public ComicBook GetComicBook(int id)
        {
            return _context.ComicBooks.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateComicBook(ComicBook comic)
        {
            throw new NotImplementedException();
        }
    }
}
