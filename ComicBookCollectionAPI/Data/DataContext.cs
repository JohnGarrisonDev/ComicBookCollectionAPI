using Microsoft.EntityFrameworkCore;

namespace ComicBookCollectionAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<CBTrait> CBTrait { get; set; }
    }
}
