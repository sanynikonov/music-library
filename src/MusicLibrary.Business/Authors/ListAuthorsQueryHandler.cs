using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Authors;

public class ListAuthorsQueryHandler : IRequestHandler<ListAuthorsQuery, PagedQueryResponse<AuthorItem>>
{
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public ListAuthorsQueryHandler(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _mapper = mapper;
    }

    public async Task<PagedQueryResponse<AuthorItem>> Handle(ListAuthorsQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Data.Entities.Author, bool>> predicate = a => a.Name.Contains(request.SearchString);

        var authors = await _unit.AuthorsRepository.GetAsync(predicate, request.PageNumber, request.PageSize, cancellationToken);
        var totalCount = await _unit.AuthorsRepository.CountAsync(predicate, cancellationToken);

        return new PagedQueryResponse<AuthorItem>(_mapper.Map<IEnumerable<AuthorItem>>(authors).ToArray())
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount,
        };
    }
}