using System.Collections.Generic;

using CollectionMaster.Api.Models;

namespace CollectionMaster.Api.Services
{
    public interface IMusicService
    {
        IEnumerable<MusicAlbum> GetAlbums();
        MusicAlbum GetAlbum(int id);
        IEnumerable<MusicAlbum> GetAlbum(string search);
        bool Add(MusicAlbum album);
        bool Delete(int id);
    }
}
