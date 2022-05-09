namespace ComicBookCollectionAPI.Data
{
    public interface IComicBookRepo
    {
        IEnumerable<ComicBook> GetAllComicBooks();
        ComicBook GetComicBook(int id);
        void CreateComicBook(ComicBook comic);
        void UpdateComicBook(ComicBook comic);
        void DeleteComicBook(ComicBook comic);
        bool SaveChanges();
        
    }
}
