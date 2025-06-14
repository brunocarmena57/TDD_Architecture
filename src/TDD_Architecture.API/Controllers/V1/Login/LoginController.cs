﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDD_Architecture.Application.Services.Login.Interfaces;
using TDD_Architecture.Domain.Enums;

namespace TDD_Architecture.Controllers.V1.Login
{
    [Route("api/[controller]")] 
    [ApiController] 
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public  LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("GetLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLogin(string email)
        {
            var response = await _loginService.GetLogin(email);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);

        }
    }
}
