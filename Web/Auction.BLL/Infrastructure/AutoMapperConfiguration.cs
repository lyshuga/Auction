using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTO;
using Auction.DAL.Entities;
using AutoMapper;

namespace Auction.BLL.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<LotDTO, Lot>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Description", c => c.MapFrom(s => s.Description))
                .ForMember("GoodType", c => c.MapFrom(s => s.GoodType))
                .ForMember("Photo", c => c.MapFrom(s => s.Photo))
                .ForMember("Price", c => c.MapFrom(s => s.Price))
                .ForMember("StartDate", c => c.MapFrom(s => s.StartDate))
                .ForMember("ExpireDate", c => c.MapFrom(s => s.ExpireDate))
                .ForMember("LastBid", c => c.MapFrom(s => s.LastBid))
                .ForMember("BidderId", c => c.MapFrom(s => s.BidderId))
                .ForMember("SellerId", c => c.MapFrom(s => s.SellerId));
            cfg.CreateMap<Lot, LotDTO>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Description", c => c.MapFrom(s => s.Description))
                .ForMember("GoodType", c => c.MapFrom(s => s.GoodType))
                .ForMember("Photo", c => c.MapFrom(s => s.Photo))
                .ForMember("Price", c => c.MapFrom(s => s.Price))
                .ForMember("StartDate", c => c.MapFrom(s => s.StartDate))
                .ForMember("ExpireDate", c => c.MapFrom(s => s.ExpireDate))
                .ForMember("LastBid", c => c.MapFrom(s => s.LastBid));
            cfg.CreateMap<UserDTO, ApplicationUser>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Email", c => c.MapFrom(s => s.Email))
                .ForMember("UserName", c => c.MapFrom(s => s.UserName))
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Balance", c => c.MapFrom(s => s.Balance))
                .ForMember("CreditCard", c => c.MapFrom(s => s.CreditCard));
            cfg.CreateMap<DAL.Entities.ApplicationProfile, UserDTO>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Email", c => c.MapFrom(s => s.User.Email))
                .ForMember("UserName", c => c.MapFrom(s => s.User.UserName))
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Balance", c => c.MapFrom(s => s.Balance))
                .ForMember("CreditCard", c => c.MapFrom(s => s.CreditCard));
        }
    }
}
