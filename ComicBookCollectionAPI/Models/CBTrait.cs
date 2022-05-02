namespace ComicBookCollectionAPI.Models
{
    public class CBTrait
    {
        public int ID { get; set; }
        public int comicID { get; set; }
        public string Trait { get; set; }

        [JsonConstructor]
        public CBTrait() { }

        public CBTrait(int comicID, string trait)
        {
            this.comicID = comicID;
            this.Trait = trait;
        }
    }
}
