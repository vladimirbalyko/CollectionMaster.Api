using CollectionMaster.DataAccess.EF.Models.Enums;

namespace CollectionMaster.DataAccess.EF.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public string Singer { get; set; }

        public int? Year { get; set; }

        public AlbumType Type { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }

    }
}
