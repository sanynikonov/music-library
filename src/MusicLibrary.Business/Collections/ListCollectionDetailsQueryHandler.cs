using AutoMapper;
using MediatR;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Collections;

public class ListCollectionDetailsQueryHandler : IRequestHandler<ListCollectionDetailsQuery, Response<CollectionDetails>>
{
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public ListCollectionDetailsQueryHandler(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _mapper = mapper;
    }

    public async Task<Response<CollectionDetails>> Handle(ListCollectionDetailsQuery request, CancellationToken cancellationToken)
    {
        var collection = await _unit.SongsCollectionsRepository.GetWithAuthorsAndSongsAndTypesAsync(request.CollectionId, cancellationToken);

        if (collection is null)
        {
            return new Response<CollectionDetails>();
        }

        var model = _mapper.Map<CollectionDetails>(collection);

        foreach (var song in model.Songs)
        {
            song.LikesCount = await _unit.LikesRepository.CountAsync(l => song.Id == l.SongId, cancellationToken);
        }

        return new Response<CollectionDetails>(model);
    }
}