namespace CollectionMaster.Api.Models
{
    public class MusicAlbum
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Singer { get; set; }

        public int? Year { get; set; }

        //public AlbumType Type { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }
    }
}
