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

        var songIds = collection.Songs.Select(s => s.Id).ToHashSet();
        var likesCount = await _context.Likes
            .Where(l => songIds.Contains(l.SongId))
            .GroupBy(l => l.SongId)
            .ToDictionaryAsync(g => g.Key, g => g.Count(), cancellationToken);

        foreach (var song in model.Songs)
            song.LikesCount = likesCount.TryGetValue(song.Id, out var likes) ? likes : 0;

        return new Response<CollectionDetails>(model);
    }
}