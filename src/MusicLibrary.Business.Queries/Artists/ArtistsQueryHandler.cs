using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;
using MusicLibrary.Data;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Artists;

public class ArtistsQueryHandler : IRequestHandler<ArtistsQuery, PagedQueryResponse<ArtistItem>>
{
    private readonly MusicLibraryContext _context;
    private readonly IMapper _mapper;

    public ArtistsQueryHandler(MusicLibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedQueryResponse<ArtistItem>> Handle(ArtistsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _context.Artists
            .Where(a => a.Name.Contains(request.SearchString))
            .PaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);
        
        var totalCount = await _context.Artists.CountAsync(cancellationToken);
        var data = _mapper.Map<IEnumerable<ArtistItem>>(authors).ToArray();

        return new PagedQueryResponse<ArtistItem>(data)
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}