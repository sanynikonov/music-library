using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Artists;

public class ListArtistsQueryHandler : IRequestHandler<ListArtistsQuery, PagedQueryResponse<ArtistItem>>
{
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public ListArtistsQueryHandler(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _mapper = mapper;
    }

    public async Task<PagedQueryResponse<ArtistItem>> Handle(ListArtistsQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Data.Entities.Artist, bool>> predicate = a => a.Name.Contains(request.SearchString);

        var authors = await _unit.AuthorsRepository.GetAsync(predicate, request.PageNumber, request.PageSize, cancellationToken);
        var totalCount = await _unit.AuthorsRepository.CountAsync(predicate, cancellationToken);

        return new PagedQueryResponse<ArtistItem>(_mapper.Map<IEnumerable<ArtistItem>>(authors).ToArray())
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount,
        };
    }
}