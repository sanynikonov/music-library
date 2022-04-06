using AutoMapper;
using MediatR;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Collections;

public class ListCollectionDetailsQueryHandler : IRequestHandler<ListCollectionDetailsQuery, CollectionDetails>
{
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public ListCollectionDetailsQueryHandler(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _mapper = mapper;
    }

    public async Task<CollectionDetails> Handle(ListCollectionDetailsQuery request, CancellationToken cancellationToken)
    {
        if (request.CollectionId <= 0)
        {
            throw new ArgumentException("Id should be higher than 0", nameof(request.CollectionId));
        }

        var collection = await _unit.SongsCollectionsRepository.GetWithAuthorsAndSongsAndTypesAsync(request.CollectionId);

        if (collection is null)
        {
            return null;
        }

        var model = _mapper.Map<CollectionDetails>(collection);

        foreach (var song in model.Songs)
        {
            song.LikesCount = await _unit.LikesRepository.CountAsync(l => song.Id == l.SongId);
        }

        return model;
    }
}