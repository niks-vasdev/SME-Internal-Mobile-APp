using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace SmedaInternalMobile.Authentication
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Constructor to accept any required dependencies
        public ApiAuthenticationStateProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var savedToken = Preferences.Get("authToken", string.Empty);

                if (string.IsNullOrWhiteSpace(savedToken))
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                // Parse token claims
                var claims = ParseClaimsFromJwt(savedToken);

                // Check token expiration
                var expClaim = claims.FirstOrDefault(c => c.Type == "exp")?.Value;
                if (expClaim != null)
                {
                    var expDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expClaim));
                    if (expDate < DateTime.UtcNow) // Token has expired
                    {
                        Preferences.Remove("authToken"); // Remove the expired token
                        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                    }
                }

                // Token is valid, return the authentication state
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")));
            }
            catch (Exception ex)
            {
                Preferences.Remove("authToken"); // Remove token on exception
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }


        public void MarkUserAsAuthenticated(string username)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }


        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task SaveToken(string token)
        {
            Preferences.Set("authToken", token);
        }

        public async Task RemoveToken()
        {
            Preferences.Remove("authToken");
        }
    }
}
