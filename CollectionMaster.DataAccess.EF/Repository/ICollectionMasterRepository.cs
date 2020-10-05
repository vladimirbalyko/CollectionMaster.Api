using CollectionMaster.DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionMaster.DataAccess.EF.Repository
{
    public interface ICollectionMasterRepository : IDisposable
    {
        IEnumerable<Album> GetAlbums();
        IEnumerable<Album> GetAlbums(string search);
        Album GetAlbum(int id);
        void InsertAlbum(Album album);
        void DeleteAlbum(int id);
        void UpdateAlbum(Album album);
        void Save();
    }
}
