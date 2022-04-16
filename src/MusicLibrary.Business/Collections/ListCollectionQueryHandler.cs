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
        Expression<Func<Collection, bool>> predicate = c =>
            c.Title.Contains(request.SearchString) && 
            c.Type.ToString().Equals(request.CollectionType);
        
        var collections = 
            await _unit.CollectionsRepository.GetAsync(predicate, request.PageNumber, request.PageSize, cancellationToken);
        var totalCount = await _unit.CollectionsRepository.CountAsync(predicate, cancellationToken);

        return new PagedQueryResponse<CollectionItem>(_mapper.Map<IEnumerable<CollectionItem>>(collections).ToArray())
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount,
        };
    }
}