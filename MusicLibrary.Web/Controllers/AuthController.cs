using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business;
using MusicLibrary.Business.Interfaces;

namespace MusicLibrary.Web.Controllers;

[Route("api/users")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }
}