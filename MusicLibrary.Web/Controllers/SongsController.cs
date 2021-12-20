using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business;

namespace MusicLibrary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _service;

        public SongsController(ISongService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongModel>>> GetAll([FromQuery] SongsCollectionSearchFilterModel filter)
        {
            var songs = await _service.GetAllSongsAsync(filter);
            return Ok(songs);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] SongModel model)
        {
            var id = await _service.AddAsync(model);
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> PutToPlaylist([FromQuery] int songId, [FromQuery] int userId)
        {
            await _service.LikeAsync(songId, userId);
            return Ok();
        }

        [HttpPut("likes")]
        public async Task<ActionResult> PutLike([FromQuery] int songId, [FromQuery] int userId)
        {
            await _service.LikeAsync(songId, userId);
            return Ok();
        }
    }
}
