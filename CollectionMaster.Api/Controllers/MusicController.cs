using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using CollectionMaster.Api.Models;
using CollectionMaster.Api.Services;

namespace CollectionMaster.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet("")]
        public IEnumerable<MusicAlbum> GetAlbums()
        {
            return _musicService.GetAlbums();
        }

        [HttpGet("{id:int}")]
        public MusicAlbum GetAlbum(int id)
        {
            return _musicService.GetAlbum(id);
        }

        [HttpGet("{search}")]
        public IEnumerable<MusicAlbum> GetAlbums(string search)
        {
            return _musicService.GetAlbums(search);
        }
    }
}