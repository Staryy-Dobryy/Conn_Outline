using AutoMapper;
using ConnOutlineMessenger.BuisnessLogic.Models;
using ConnOutlineMessenger.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CurrentChatModel, Chat>()
                .ForMember(currentChatModel => currentChatModel.ChatName,
                opt => opt.MapFrom(chat => chat.ChatName))
                .ForMember(currentChatModel => currentChatModel.Messages,
                opt => opt.MapFrom(chat => chat.Messages))
                .ForMember(currentChatModel => currentChatModel.CreationTime,
                opt => opt.MapFrom(chat => chat.CreationTime))
                .ForMember(currentChatModel => currentChatModel.Members,
                opt => opt.MapFrom(chat => chat.Members));

            CreateMap<Chat, CurrentChatModel>()
                .ForMember(chat => chat.ChatName,
                opt => opt.MapFrom(currentChatModel => currentChatModel.ChatName))
                .ForMember(chat => chat.Messages,
                opt => opt.MapFrom(currentChatModel => currentChatModel.Messages))
                .ForMember(chat => chat.CreationTime,
                opt => opt.MapFrom(currentChatModel => currentChatModel.CreationTime))
                .ForMember(chat => chat.Members,
                opt => opt.MapFrom(currentChatModel => currentChatModel.Members));
        }
    }
}
