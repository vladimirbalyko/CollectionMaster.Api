using System.Collections.Generic;

using CollectionMaster.Api.Models;

namespace CollectionMaster.Api.Services
{
    public interface IMusicService
    {
        IEnumerable<MusicAlbum> GetAlbums();
        IEnumerable<MusicAlbum> GetAlbums(string search);
        MusicAlbum GetAlbum(int id);
        void Add(MusicAlbum album);
        void Delete(int id);
    }
}
