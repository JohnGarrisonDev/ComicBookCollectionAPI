using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ComicBookCollectionAPI.Models
{
    public class ComicBook
    {
        public int Id { get; set; }
        public string ComicName { get; set; }

        public string Publisher { get; set; }

        public string Author { get; set; }

        public int SeriesNumber { get; set; }

        [NotMapped]
        public string[] Traits { get; set; }

        [JsonConstructor]
        public ComicBook() { }
        public ComicBook(ComicBook book)
        {
            this.Id = book.Id;
            this.ComicName = book.ComicName;
            this.Publisher = book.Publisher;
            this.Author = book.Author;
            this.SeriesNumber = book.SeriesNumber;
        }
    }
}
