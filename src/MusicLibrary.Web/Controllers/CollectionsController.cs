using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Collections;
using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Models;

namespace MusicLibrary.Web.Controllers;

[Route("api/collections")]
[ApiController]
public class CollectionsController : ControllerBase
{
    private readonly ISongsCollectionService _service;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CollectionsController(ISongsCollectionService service, IMediator mediator, IMapper mapper)
    {
        _service = service;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<CollectionItem>>> GetAll(
        [FromQuery] SongsCollectionSearchFilterModel filter)
    {
        var result = await _mediator.Send(_mapper.Map<ListCollectionQuery>(filter));

        if (!result.HasData)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PagedResponse<CollectionItem>>(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CollectionDetails>> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new ListCollectionDetailsQuery(id));

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] CollectionDetails details)
    {
        var result = await _service.AddAsync(details);
        return Ok(result);
    }

    [HttpPut("likes")]
    public async Task<ActionResult> PutLike([FromQuery] int collectionId, [FromQuery] int userId)
    {
        await _service.LikeAsync(collectionId, userId);
        return Ok();
    }
}