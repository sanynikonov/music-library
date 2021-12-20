﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business;

namespace MusicLibrary.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<UserProfileModel>> GetById([FromRoute] int id)
        {
            var model = await _service.GetUserProfileAsync(id);
            return Ok(model);
        }

        [HttpGet("{id}/collections")]
        public async Task<ActionResult<UserPlaylistsModel>> GetPlaylists([FromRoute] int id)
        {
            var model = await _service.GetUserPlaylistsAsync(id);
            return Ok(model);
        }
    }
}