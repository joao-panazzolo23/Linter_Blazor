using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Linter.Seguranca
{
    public class Security : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var usuario = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuario)));
        }
    }
}
