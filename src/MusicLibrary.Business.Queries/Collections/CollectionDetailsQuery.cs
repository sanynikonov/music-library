using MediatR;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Collections;

public record CollectionDetailsQuery(int CollectionId) : IRequest<Response<CollectionDetails>>;