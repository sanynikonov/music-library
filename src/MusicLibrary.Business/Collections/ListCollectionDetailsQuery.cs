using MediatR;
using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Collections;

public record ListCollectionDetailsQuery(int CollectionId) : IRequest<CollectionDetails>;