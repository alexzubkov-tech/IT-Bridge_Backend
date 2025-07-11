﻿using CoreService.Application.UserProfiles.Dtos;

namespace CoreService.Application.Account.Dtos
{
    public class UserFullInfoDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserProfileDto UserProfile { get; set; }
    }
}
