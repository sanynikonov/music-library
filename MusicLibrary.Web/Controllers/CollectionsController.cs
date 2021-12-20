using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business;

namespace MusicLibrary.Web.Controllers
{
    [Route("api/collections")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ISongsCollectionService _service;

        public CollectionsController(ISongsCollectionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongsCollectionListItemModel>>> GetAll(
            [FromQuery] SongsCollectionSearchFilterModel filter)
        {
            var result = await _service.GetAllSongsCollectionsAsync(filter);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SongsCollectionModel>> GetById([FromRoute] int id)
        {
            var result = await _service.GetSongsCollectionAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] SongsCollectionModel model)
        {
            var result = await _service.AddAsync(model);
            return Ok(result);
        }

        [HttpPut("likes")]
        public async Task<ActionResult> PutLike([FromQuery] int collectionId, [FromQuery] int userId)
        {
            await _service.LikeAsync(collectionId, userId);
            return Ok();
        }
    }
}
