using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identityserver
{
    public class Config
    {
        //this is implementation is same as the once below.

        //public static IEnumerable<Client> Clients { get; } = new Client[]
        //{

        //};

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "shopping_web",
                    ClientName = "Shopping Web App",
                    //AllowedGrantTypes = GrantTypes.Code,
            AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                    AllowRememberConsent = false,
                    RedirectUris = new List<string>()
                        {
                        "https://localhost:5003/signin-oidc" //— this is client app port
                        },
                    PostLogoutRedirectUris = new List<string>()
                        {
                        "https://localhost:5003/signout-callback-oidc"
                        },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                 new Client
       {
            ClientId = "company-employee",
            ClientSecrets = new [] { new Secret("codemazesecret".Sha512()) },
            AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
            AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId }
        }

            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                //new ApiScope( "shoppingAPI", "Shopping Aggregator API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359–073C-434B-AD2D-A3932222DABE",
                    Username = "Iriajen",
                    Password = "Iriajen",
                    Claims = new List<Claim>()
                    {
                        new Claim(JwtClaimTypes.GivenName, "Onaivbi"),
                        new Claim(JwtClaimTypes.FamilyName, "Iriajen")
                    }
                }
            };




    }
}
