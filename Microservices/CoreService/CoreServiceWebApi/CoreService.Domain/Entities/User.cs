using System;

namespace CoreService.Domain.Entities;

public class User
{
    public Guid Id { get; set; } // Это UserId
    public string Email { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; } = string.Empty;

    // Связь 1 к 1: User -> UserProfile
    public Guid UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User() { }

    public User(string email, string passwordHash, Guid userProfileId)
    {
        Id = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
        UserProfileId = userProfileId;
        CreatedAt = UpdatedAt = DateTime.UtcNow;
    }
}