﻿

using DinnerHost.Contracts.Authentication;

namespace DinnerHost.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email , string password);
        AuthenticationResult Register(string firstname, string lastname , string email, string password);
    }
}
