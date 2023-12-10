using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            // Declare the scheme and specify some options
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Specify all the rules how token should be validated
                    
                    // Server going to check token signing key and make sure its valid
                    ValidateIssuerSigningKey = true,
                    // 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        config?["TokenKey"] ?? "")),
                    // Middleware will not check whether the "issuer" is valid.
                    ValidateIssuer = false,
                    //  Middleware will not check whether the token is intended for a specific audience
                    ValidateAudience = false

                    //  Notes
                    // Disabling issuer and audience validation(ValidateIssuer = false and ValidateAudience = false) is common in scenarios where the tokens are self - contained and not validated against specific issuers or audiences.
                    // This might be the case when using JWTs in a more decentralized or loosely - coupled environment.
                    // The signing key(IssuerSigningKey) is crucial for verifying the integrity of the token.It's derived from the "TokenKey" configuration setting, assuming that it's a symmetric key used to sign the JWTs.Ensure that the "TokenKey" configuration value is securely stored and shared between the token issuer and the token consumer(e.g., your application and the authorization server).
                };
            });

            return services;    
        }
    }
}