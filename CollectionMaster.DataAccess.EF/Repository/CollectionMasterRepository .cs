using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using CollectionMaster.DataAccess.EF.Context;
using CollectionMaster.DataAccess.EF.Models;

namespace CollectionMaster.DataAccess.EF.Repository
{
    public class CollectionMasterRepository : ICollectionMasterRepository, IDisposable
    {
        private readonly CollectionMasterContext _context;

        public CollectionMasterRepository(CollectionMasterContext context)
        {
            _context = context;
        }

        public Album GetAlbum(int id)
        {
            return _context.Albums.FirstOrDefault(p => p.AlbumId == id);
        }

        public IEnumerable<Album> GetAlbums()
        {
            return _context.Albums;
        }

        public IEnumerable<Album> GetAlbums(string search)
        {
            search = search.ToLower();
            return _context.Albums.Where(props => props.Name.ToLower().Contains(search) ||
                props.Singer.ToLower().Contains(search));
        }

        public void InsertAlbum(Album album)
        {
            _context.Albums.Add(album);
        }

        public void UpdateAlbum(Album album)
        {
            _context.Entry(album).State = EntityState.Modified;
        }

        public void DeleteAlbum(int id)
        {
            var album = _context.Albums.Find(id);
            _context.Albums.Remove(album);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
