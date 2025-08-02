using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Common
{
    public interface IAuthService
    {
        bool ValidateToken(out string uid, out string fullName, bool fromForm = false);
        string Decrypt(string cipherText, string keyString);
        TokenValidationParameters TokenValidationParameters();
    }
}

