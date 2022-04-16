using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Artists;
using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Models;
using MusicLibrary.Web.Extensions;

namespace MusicLibrary.Web.Controllers;

[Route("api/artists")]
[ApiController]
public class ArtistsController : ControllerBase
{
    private readonly IAuthorService _service;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ArtistsController(IAuthorService service, IMediator mediator, IMapper mapper)
    {
        _service = service;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<ArtistItem>>> GetAll([FromQuery] SearchFilterModel filter, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(_mapper.Map<ListArtistsQuery>(filter), cancellationToken);
        return response.ToActionResult(_mapper);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ArtistDetails>> GetById([FromRoute] int id)
    {
        var author = await _service.GetAuthorAsync(id);
        return Ok(author);
    }
}