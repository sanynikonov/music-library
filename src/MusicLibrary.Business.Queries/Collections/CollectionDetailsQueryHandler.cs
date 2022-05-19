using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;
using MusicLibrary.Data;

namespace MusicLibrary.Business.Collections;

public class CollectionDetailsQueryHandler : IRequestHandler<CollectionDetailsQuery, Response<CollectionDetails>>
{
    private readonly MusicLibraryContext _context;
    private readonly IMapper _mapper;

    public CollectionDetailsQueryHandler(MusicLibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<CollectionDetails>> Handle(CollectionDetailsQuery request, CancellationToken cancellationToken)
    {
        var collection = await _context.Collections.Include(c => c.Artist)
            .Include(c => c.Songs)
            .ThenInclude(s => s.Artists)
            .SingleOrDefaultAsync(c => c.Id == request.CollectionId, cancellationToken);

        if (collection is null)
            return new Response<CollectionDetails>();

        var model = _mapper.Map<CollectionDetails>(collection);

        foreach (var song in model.Songs)
            song.LikesCount = await _context.Likes.CountAsync(l => song.Id == l.SongId, cancellationToken);

        return new Response<CollectionDetails>(model);
    }
}