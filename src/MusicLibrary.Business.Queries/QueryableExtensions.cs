using Microsoft.EntityFrameworkCore;

namespace MusicLibrary.Business;

public static class QueryableExtensions
{
    public static async Task<List<T>> PaginatedAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken)
        => await query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
}