using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> GetByUserProfileIdAsync(int userProfileId);
        Task CreateAsync(UserProfile expert);
        Task UpdateAsync(UserProfile expert);
        Task DeleteAsync(int userProfileId);
    }
}
