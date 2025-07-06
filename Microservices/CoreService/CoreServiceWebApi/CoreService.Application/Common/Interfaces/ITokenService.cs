using CoreService.Domain.Entities;

namespace CoreService.Application.Common.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user, int? userProfileId = null);
    }
}
