﻿using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Business.Collections;

public class CollectionQueryHandler : IRequestHandler<CollectionQuery, PagedQueryResponse<CollectionItem>>
{
    private readonly MusicLibraryContext _context;
    private readonly IMapper _mapper;

    public CollectionQueryHandler(MusicLibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedQueryResponse<CollectionItem>> Handle(CollectionQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Collection, bool>> predicate = Enum.TryParse<ReleaseType>(request.ReleaseType, out var releaseType)
            ? c => c.Type == releaseType && c.Title.Contains(request.SearchString)
            : c => c.Title.Contains(request.SearchString);
        
        var collections = await _context.Collections
            .Where(predicate)
            .PaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);
        
        var totalCount = await _context.Collections.CountAsync(predicate, cancellationToken);
        var collectionItems = _mapper.Map<IEnumerable<CollectionItem>>(collections).ToArray();

        return new PagedQueryResponse<CollectionItem>(collectionItems)
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount,
        };
    }
}