using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Distance.WebAPI.Authorization
{
    public class AutenticacaoBasica : AuthenticationHandler<AuthenticationSchemeOptions>
    {
       // private readonly IUserService _userService;

        public AutenticacaoBasica(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
)
            : base(options, logger, encoder, clock)
        {
            //_userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization") || String.IsNullOrEmpty(Request.Headers["Authorization"]))
                return AuthenticateResult.Fail("Missing Authorization Header");

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "teste"),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            //TODO: IMPLEMENTAR VALIDACOES
            return AuthenticateResult.Success(ticket);
        }
    }
}

