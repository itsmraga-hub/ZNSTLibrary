using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ZNSTLibrary.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly ProtectedLocalStorage _localStorage;
        private readonly ILogger<CustomAuthenticationStateProvider> _logger;

        private ClaimsPrincipal _user = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage, ILogger<CustomAuthenticationStateProvider> logger, ProtectedLocalStorage localStorage)
        {
            _sessionStorage = sessionStorage;
            _logger = logger;
            _localStorage = localStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSession == null)               
                    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
                var claimsPrincipal = new ClaimsPrincipal(
                                            new ClaimsIdentity(
                                                new[] {
                                                    new Claim(ClaimTypes.NameIdentifier, userSession.Id),
                                                    new Claim(ClaimTypes.Name, userSession.Username),
                                                    new Claim(ClaimTypes.Email, userSession.Email),
                                                    new Claim(ClaimTypes.MobilePhone, userSession.PhoneNumber),
                                                    new Claim(ClaimTypes.Role, userSession.Role),
                                                }, "apiauth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {
                // await _localStorage.SetAsync("uid", "");
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }
        }

        public async Task<UserSession> UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            if (userSession == null)
            {
                await _sessionStorage.DeleteAsync("UserSession");
                await _localStorage.DeleteAsync("__id");
                claimsPrincipal = _user;
                return new UserSession();
            }
            else
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(
                                        new ClaimsIdentity(
                                            new[]
                        {
                    new Claim(ClaimTypes.NameIdentifier, userSession.Id),
                    new Claim(ClaimTypes.Name, userSession.Username),
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.Role, userSession.Role),
                    new Claim(ClaimTypes.MobilePhone, userSession.PhoneNumber),
                        }, "apiauth"));
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
            userSession.IsAuthenticated = true;
            return userSession;
        }

        public async Task<UserSession> GetAuthenticatedUser()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSession == null)
                    return await Task.FromResult(new UserSession());
                var claimsPrincipal = new ClaimsPrincipal(
                                            new ClaimsIdentity(
                                                new[] {
                                                    new Claim(ClaimTypes.NameIdentifier, userSession.Id),
                                                    new Claim(ClaimTypes.Name, userSession.Username),
                                                    new Claim(ClaimTypes.Email, userSession.Email),
                                                    new Claim(ClaimTypes.Role, userSession.Role),
                                                    new Claim(ClaimTypes.MobilePhone, userSession.PhoneNumber),
                                                }, "apiauth"));
                return await Task.FromResult(userSession);
            }
            catch (Exception)
            {
                return await Task.FromResult(new UserSession());
            }
        }
    }
}
