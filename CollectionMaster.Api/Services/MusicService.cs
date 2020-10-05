using System.Collections.Generic;
using System.Linq;

using CollectionMaster.Api.Models;

namespace CollectionMaster.Api.Services
{
    public class MusicService : IMusicService
    {
        private IEnumerable<MusicAlbum> _reposotory;

        public MusicService()
        {
            Initialize();
        }

        public bool Add(MusicAlbum album)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public MusicAlbum GetAlbum(int id)
        {
            return _reposotory.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<MusicAlbum> GetAlbums(string search)
        {
            var filter = search.ToLower();
            return _reposotory.Where(p => p.Title.ToLower().Contains(filter) || p.Singer.ToLower().Contains(filter));
        }

        public IEnumerable<MusicAlbum> GetAlbums()
        {
            return _reposotory;
        }

        private void Initialize()
        {
            _reposotory = new List<MusicAlbum>
            {
                new MusicAlbum
                {
                    Id = 1,
                    Title = "Never mind",
                    Singer = "Nirvana"
                },
                new MusicAlbum
                {
                    Id = 2,
                    Title = "Черный альбом",
                    Singer = "Кино"
                }
            };
        }
    }
}
