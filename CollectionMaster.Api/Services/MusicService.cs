using System.Collections.Generic;
using System.Linq;

using CollectionMaster.Api.Models;
using CollectionMaster.DataAccess.EF.Models;
using CollectionMaster.DataAccess.EF.Repository;

namespace CollectionMaster.Api.Services
{
    public class MusicService : IMusicService
    {
        private readonly ICollectionMasterRepository _collectionRepository;

        public MusicService(ICollectionMasterRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public void Add(MusicAlbum album)
        {
            // TODO: Add Auto Mapper
            var newAlbum = new Album
            {
                Name = album.Title,
                Singer = album.Singer,
                Year = album.Year,
                Description = album.Description,
                Logo = album.Logo,
            };
            _collectionRepository.InsertAlbum(newAlbum);
            _collectionRepository.Save();
        }

        public void Delete(int id)
        {
            _collectionRepository.DeleteAlbum(id);
            _collectionRepository.Save();
        }

        public MusicAlbum GetAlbum(int id)
        {
            var album = _collectionRepository.GetAlbum(id);

            return album != null
                ? new MusicAlbum
                {
                    Id = album.AlbumId,
                    Title = album.Name,
                    Singer = album.Singer,
                    Year = album.Year,
                    Description = album.Description,
                    Logo = album.Logo
                } : null;
        }

        public IEnumerable<MusicAlbum> GetAlbums(string search)
        {
            var result = _collectionRepository.GetAlbums(search);
            return result.Select(album => new MusicAlbum
            {
                Id = album.AlbumId,
                Title = album.Name,
                Singer = album.Singer,
                Year = album.Year,
                Description = album.Description,
                Logo = album.Logo
            });
        }

        public IEnumerable<MusicAlbum> GetAlbums()
        {
            var albums = _collectionRepository.GetAlbums();

            foreach (var album in albums)
            {
                yield return new MusicAlbum
                {
                    Id = album.AlbumId,
                    Title = album.Name,
                    Singer = album.Singer,
                    Year = album.Year,
                    Description = album.Description,
                    Logo = album.Logo
                };
            }
        }
    }
}
