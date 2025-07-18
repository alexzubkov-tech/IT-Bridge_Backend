﻿using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly CoreServiceDbContext _context;

        public UserProfileRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfiles
                .Include(up => up.Company)
                .Include(up => up.Category)

                .Include(up => up.Questions)
                .Include(up => up.Answers)

                .Include(up => up.CommentQuestions)
                .Include(up => up.CommentAnswers)

                .Include(up => up.RatingQuestions)
                .Include(up => up.RatingAnswers)
                .FirstOrDefaultAsync(up => up.Id == id);
        }

        public async Task<UserProfile> GetByUserIdAsync(string userId)
        {
            return await _context.UserProfiles
                .Include(up => up.Company)
                .Include(up => up.Category)
                .FirstOrDefaultAsync(up => up.UserId == userId);

        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfiles
                .Include(up => up.Company)
                .Include(up => up.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserProfile>> GetByCategoryIdsAsync(IEnumerable<int> categoryIds)
        {
            return await _context.UserProfiles
                .Include(u => u.Category)
                .Where(u => categoryIds.Contains(u.CategoryId ?? 0))
                .ToListAsync();
        }

        public async Task<int> CreateAsync(UserProfile profile)
        {
            await _context.UserProfiles.AddAsync(profile);
            await _context.SaveChangesAsync();
            return profile.Id; // возвращаем ID созданной записи
        }

        public async Task<bool> UpdateAsync(UserProfile profile)
        {
            _context.UserProfiles.Update(profile);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profile = await _context.UserProfiles.FindAsync(id);
            if (profile == null) return false;

            _context.UserProfiles.Remove(profile);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<string> GetCategoryNameByUserProfileIdAsync(int userProfileId)
        {
            var profile = await _context.UserProfiles
                .Include(up => up.Category)
                .FirstOrDefaultAsync(up => up.Id == userProfileId);

            return profile?.Category?.Name ?? string.Empty;
        }
    }
}