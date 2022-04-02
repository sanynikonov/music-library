﻿namespace MusicLibrary.Business;

public class SongModel
{
    public int Id { get; set; }
    public int LikesCount { get; set; }
    public string Name { get; set; }
    public string AudioPath { get; set; }
    public int AlbumId { get; set; }
    public IEnumerable<AuthorListItemModel> Authors { get; set; } = Enumerable.Empty<AuthorListItemModel>();
}