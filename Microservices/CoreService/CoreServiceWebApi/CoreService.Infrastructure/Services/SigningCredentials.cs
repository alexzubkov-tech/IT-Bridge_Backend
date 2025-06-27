
namespace CoreService.Services
{
    internal class SigningCredentials
    {
        private SymmetricSecurityKey key;
        private object hmacSha512Signature;

        public SigningCredentials(SymmetricSecurityKey key, object hmacSha512Signature)
        {
            this.key = key;
            this.hmacSha512Signature = hmacSha512Signature;
        }

        public static implicit operator Microsoft.IdentityModel.Tokens.SigningCredentials(SigningCredentials v)
        {
            throw new NotImplementedException();
        }
    }
}