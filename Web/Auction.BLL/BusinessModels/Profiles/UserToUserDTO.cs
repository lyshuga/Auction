﻿using Auction.BLL.DTO;
using Auction.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.BusinessModels.Profiles
{
    public static class UserToUserDTO
    {
        static MapperConfiguration config;
        static UserToUserDTO()
        {
            config = new MapperConfiguration(cfg => {

                cfg.CreateMap<ApplicationUser, UserDTO>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Email", c => c.MapFrom(s => s.Email))
                .ForMember("UserName", c => c.MapFrom(s => s.UserName))
                .ForMember("Name", c => c.MapFrom(s => s.ApplicationProfile.Name))
                .ForMember("Balance", c => c.MapFrom(s => s.ApplicationProfile.Balance))
                .ForMember("CreditCard", c => c.MapFrom(s => s.ApplicationProfile.CreditCard));
            });
        }
        public static IMapper CreateMap()
        {
            return config.CreateMapper();
        }
    }
}
