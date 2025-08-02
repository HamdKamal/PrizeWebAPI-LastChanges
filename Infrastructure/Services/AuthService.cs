using Application.Abstractions.Common;
using Application.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services
{
    public class AuthService(IHttpContextAccessor context,IConfiguration configuration,IOptions<JWTModel> Options) : IAuthService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly JWTModel _options = Options.Value;
        private readonly string site = "https://api.swcc.gov.sa";
        private readonly IHttpContextAccessor _context = context;

        public bool ValidateToken(out string uid, out string? fullName, bool fromForm = false)
        {
            uid = fullName = null;
            string EncKey = _options.EncKey;
            var tokenValidationParameters = TokenValidationParameters();

            try
            {
                //string authString = fromForm ? request.Form["authtoken"] : request.Headers["Authorization"];
                string? authString = fromForm ? _context.HttpContext.Request.Form["auth"] : _context.HttpContext.Request.Headers.Authorization;
                if (string.IsNullOrEmpty(authString)) return false;

                if (!fromForm) authString = authString.Replace("Bearer ", "");

                var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(authString, tokenValidationParameters, out var token);

                if (token is JwtSecurityToken jwtSecurityToken)
                {
                    fullName = jwtSecurityToken.Claims.First(claim => claim.Type == "fullName").Value;
                    try
                    {
                        uid = jwtSecurityToken.Claims.First(claim => claim.Type == "uid").Value;
                        uid = Decrypt(uid, EncKey);
                    }
                    catch (Exception) { uid = fullName.Split('@')[0]; }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public string Decrypt(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }



        public TokenValidationParameters TokenValidationParameters()
        {
            var res = new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = site, //some string, normally web url,
                ValidAudience = site,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.MasterKey))
            };
            return res;
        }
    }


}
