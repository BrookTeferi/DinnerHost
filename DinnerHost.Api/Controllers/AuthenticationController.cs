﻿using DinnerHost.Application.Services.Authentication;
using DinnerHost.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DinnerHost.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService uthenticationService)
        {
            _authenticationService = uthenticationService;                
        }
        [Route("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
                );
            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);

            return Ok(response);
        }


        [Route("login")]
        public IActionResult Login(LoginRequest request) 
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password
                );
            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);

            return Ok(response);
        }

    }
}
 