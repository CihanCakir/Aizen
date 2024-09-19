using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aizen.Modules.Identity.Abstraction.Dto.Authentication
{
    public class AizenLoginDto
    {
        public TokenInfo TokenInfo { get; private set; }
        public UserInfo UserInfo { get; private set; }
        public AgreementInfo AgreementInfo { get; set; }

        private AizenLoginDto(TokenInfo tokenInfo, UserInfo userInfo, AgreementInfo agreementInfo)
        {
            TokenInfo = tokenInfo;
            UserInfo = userInfo;
        }

        public static AizenLoginDto Create(TokenInfo tokenInfo, UserInfo userInfo, AgreementInfo agreementInfo)
        {
            return new AizenLoginDto(tokenInfo, userInfo, agreementInfo);
        }
    }
    public class TokenInfo
    {
        public string AccessToken { get; private set; }
        public DateTime AccessTokenExpiration { get; private set; }
        public string RefreshToken { get; private set; }
        public DateTime RefreshTokenExpiration { get; private set; }

        private TokenInfo(string accessToken, DateTime accessTokenExpiration, string refreshToken, DateTime refreshTokenExpiration)
        {
            AccessToken = accessToken;
            AccessTokenExpiration = accessTokenExpiration;
            RefreshToken = refreshToken;
            RefreshTokenExpiration = refreshTokenExpiration;
        }

        public static TokenInfo Create(string accessToken, DateTime accessTokenExpiration, string refreshToken, DateTime refreshTokenExpiration)
        {
            return new TokenInfo(accessToken, accessTokenExpiration, refreshToken, refreshTokenExpiration);
        }


    }
    public class UserInfo
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public long TenantId { get; set; }
        public long CompanyId { get; set; }

        private UserInfo(string email, string name, string surname, string phoneNumber, long tenantId, long companyId)
        {
            Email = email;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            TenantId = tenantId;
            CompanyId = companyId;
        }

        public static UserInfo Create(string email, string name, string surname, string phoneNumber, long tenantId, long companyId)
        {
            return new UserInfo(email, name, surname, phoneNumber, tenantId, companyId);
        }
    }

    public class AgreementInfo
    {
        public int AgreementId { get; set; } = 0;
        public bool AgreementApproved { get; set; } = true;
    }
}