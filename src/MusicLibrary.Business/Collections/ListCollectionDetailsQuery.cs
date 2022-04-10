using MediatR;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Collections;

public record ListCollectionDetailsQuery(int CollectionId) : IRequest<Response<CollectionDetails>>;