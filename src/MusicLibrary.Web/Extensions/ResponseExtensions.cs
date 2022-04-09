﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Core;
using MusicLibrary.Business.Models;

namespace MusicLibrary.Web.Extensions;

public static class ResponseExtensions
{
    public static ActionResult<PagedResponse<T>> ToActionResult<T>(this PagedQueryResponse<T> result, IMapper mapper)
        => !result.IsValid
            ? new BadRequestObjectResult(result.Errors)
            : !result.HasData
                ? new NotFoundResult()
                : new OkObjectResult(mapper.Map<PagedResponse<T>>(result));
}