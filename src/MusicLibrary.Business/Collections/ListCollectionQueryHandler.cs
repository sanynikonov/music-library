using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Collections;

public class ListCollectionQueryHandler : IRequestHandler<ListCollectionQuery, PagedQueryResponse<CollectionItem>>
{
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public ListCollectionQueryHandler(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _mapper = mapper;
    }

    public async Task<PagedQueryResponse<CollectionItem>> Handle(ListCollectionQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<SongsCollection, bool>> predicate = c =>
            c.Name.Contains(request.SearchString) && 
            c.SongsCollectionType.Name.Equals(request.CollectionType);
        
        var collections = 
            await _unit.SongsCollectionsRepository.GetAllWithTypesAsync(predicate, request.PageNumber, request.PageSize);
        var totalCount = await _unit.SongsCollectionsRepository.CountAsync(predicate);

        return new PagedQueryResponse<CollectionItem>(_mapper.Map<IEnumerable<CollectionItem>>(collections).ToArray())
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount,
        };
    }
}