using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using MusicLibrary.Business.Core;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Collections;

public class ListCollectionQueryHandler : IRequestHandler<ListCollectionQuery, PagedQueryResponse<SongsCollectionListItemModel>>
{
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public ListCollectionQueryHandler(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _mapper = mapper;
    }

    public async Task<PagedQueryResponse<SongsCollectionListItemModel>> Handle(ListCollectionQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.SearchString) || string.IsNullOrEmpty(request.SongsCollectionType))
        {
            throw new ArgumentException("Wrong searching parameters", nameof(request));
        }

        Expression<Func<SongsCollection, bool>> predicate = c =>
            c.Name.Contains(request.SearchString) && 
            c.SongsCollectionType.Name.Equals(request.SongsCollectionType);
        
        var collections = 
            await _unit.SongsCollectionsRepository.GetAllWithTypesAsync(predicate, request.PageNumber, request.PageSize);
        var totalCount = await _unit.SongsCollectionsRepository.CountAsync(predicate);

        return new PagedQueryResponse<SongsCollectionListItemModel>
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount,
            Data = _mapper.Map<IEnumerable<SongsCollectionListItemModel>>(collections).ToArray()
        };
    }
}