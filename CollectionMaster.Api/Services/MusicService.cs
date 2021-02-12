using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using CollectionMaster.Api.Models;
using CollectionMaster.DataAccess.EF.Models;
using CollectionMaster.DataAccess.EF.Repository;

namespace CollectionMaster.Api.Services
{
    public class MusicService : IMusicService
    {
        private readonly ICollectionMasterRepository _collectionRepository;
        private readonly IMapper _mapper;

        public MusicService(ICollectionMasterRepository collectionRepository, IMapper mapper)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }

        public void Add(MusicAlbum album)
        {
            var newAlbum = _mapper.Map<Album>(album);

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

            var musicAlbum = _mapper.Map<MusicAlbum>(album);

            return album != null ? musicAlbum : null;
        }

        public IEnumerable<MusicAlbum> GetAlbums(string search)
        {
            var result = _collectionRepository.GetAlbums(search);

            return result.Select(album => _mapper.Map<MusicAlbum>(album));
        }

        public IEnumerable<MusicAlbum> GetAlbums()
        {
            var albums = _collectionRepository.GetAlbums();

            foreach (var album in albums)
            {
                yield return _mapper.Map<MusicAlbum>(album);
            }
        }
    }
}
