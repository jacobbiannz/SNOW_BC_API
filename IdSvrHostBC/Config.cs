﻿using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdSvrHostBC
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                 new ApiResource("api1", "My API"),
            };
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(), // <-- usefull
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                     ClientName = "Client Credentials Client",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RequireConsent = false,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },

                new Client {
                    ClientId = "angular_spa",
                    ClientName = "Angular 4 Client",
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string> { "openid", "profile", "api1", "email"},
                    RedirectUris = new List<string> { "http://localhost:61155/auth-callback" },
                    PostLogoutRedirectUris = new List<string> { "http://localhost:61155/home.html" },
                    AllowedCorsOrigins = new List<string> { "http://localhost:61155" },
                    AllowAccessTokensViaBrowser = true
                }
            };
        }

      

    }
}
