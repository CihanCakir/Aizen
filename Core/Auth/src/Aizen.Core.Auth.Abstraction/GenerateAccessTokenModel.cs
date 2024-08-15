namespace Aizen.Core.Auth.Abstraction
{
    public class GenerateAccessTokenModel
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public GenerateAccessTokenModel(string? id, string? userName)
        {
            Id = id;
            UserName = userName;
        }



        // public IList<String>? Roles { get; set; }

        //  new Claim(JwtRegisteredClaimNames.Sub, generateAccessTokenModel.InternalUserId.ToString()),
        //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //         new Claim("UserId", generateAccessTokenModel.UserId.ToString()),
        //         new Claim("UdId", generateAccessTokenModel.UdId),
        //         new Claim("PhoneNumber", generateAccessTokenModel.PhoneNumber),
        //         new Claim("UserType", generateAccessTokenModel.CustomerType.ToString())
    }
}