using NotificationBotApp.Domain.Entities;
using NotificationBotApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace NotificationService.Application.ChatBindin.Mapper
{
    public class ChatBindingMapper : Profile
    {
        public ChatBindingMapper()
        {
            CreateMap<UserChatBinding, ChatBindingDto>();
            CreateMap<ChatBindingDto, UserChatBinding>();
        }
    }
}
