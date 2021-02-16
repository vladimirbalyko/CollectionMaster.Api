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

        [HttpPost]
        public ActionResult<MusicAlbum> Add([FromBody] MusicAlbum album)
        {
            if (album == null)
            {
                return BadRequest();
            }

            _musicService.Add(album);

            return CreatedAtAction(nameof(GetAlbum), new { id = album.Id, controller = "Music" }, album);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<MusicAlbum> Delete(int id)
        {
            var album = _musicService.GetAlbum(id);
            if (album == null)
            {
                return NotFound();
            }

            _musicService.Delete(id);

            return album;
        }
    }
}