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
            cfg.CreateMap<Lot, LotDTO>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Description", c => c.MapFrom(s => s.Description))
                .ForMember("GoodType", c => c.MapFrom(s => s.GoodType))
                .ForMember("Photo", c => c.MapFrom(s => s.Photo))
                //.ForMember("Seller", c => c.MapFrom(s => s.Seller))
                .ForMember("StartPrice", c => c.MapFrom(s => s.StartPrice))
                .ForMember("StartDate", c => c.MapFrom(s => s.StartDate))
                .ForMember("ExpireDate", c => c.MapFrom(s => s.ExpireDate))
                /*.ForMember("Bids", c => c.MapFrom(s => s.Bids))*/;
            cfg.CreateMap<LotDTO, Lot>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Description", c => c.MapFrom(s => s.Description))
                .ForMember("GoodType", c => c.MapFrom(s => s.GoodType))
                .ForMember("Photo", c => c.MapFrom(s => s.Photo))
                .ForMember("StartPrice", c => c.MapFrom(s => s.StartPrice))
                .ForMember("StartDate", c => c.MapFrom(s => s.StartDate))
                .ForMember("ExpireDate", c => c.MapFrom(s => s.ExpireDate))
                //.ForMember("Bids", c => c.MapFrom(s => s.Bids))
                //.ForMember("Seller", c => c.MapFrom(s => s.Seller))
                ;
            cfg.CreateMap<Bid, BidDTO>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Bidder", c => c.MapFrom(s => s.Bidder))
                .ForMember("Lot", c => c.MapFrom(s => s.Lot))
                .ForMember("Time", c => c.MapFrom(s => s.Time))
                ;
            cfg.CreateMap<BidDTO, Bid>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Bidder", c => c.MapFrom(s => s.Bidder))
                .ForMember("Lot", c => c.MapFrom(s => s.Lot))
                .ForMember("Time", c => c.MapFrom(s => s.Time))
                ;
            //cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()
            //    .ForMember("Id", c => c.MapFrom(s => s.Id))
            //    .ForMember("Email", c => c.MapFrom(s => s.Email))
            //    .ForMember("Password", c => c.MapFrom(s => s.PasswordHash))
            //    .ForMember("Role", c => c.MapFrom(s => s.Roles.FirstOrDefault()))
            //    .ForMember("ApplicationProfile", c => c.MapFrom(s => s.ApplicationProfile))
            //    ;
            //cfg.CreateMap<ApplicationUserDTO, ApplicationUser>()
            //    .ForMember("Id", c => c.MapFrom(s => s.Id))
            //    .ForMember("Email", c => c.MapFrom(s => s.Email))
            //    .ForMember("UserName", c => c.MapFrom(s => s.Email))
            //    .ForMember("Password", c => c.MapFrom(s => s.Password))
            //    .ForMember("Role", c => c.MapFrom(s => s.Role))
            //    .ForMember("ApplicationProfile", c => c.MapFrom(s => s.ApplicationProfile))
            //    ;
            cfg.CreateMap<ApplicationProfile, ApplicationProfileDTO>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Balance", c => c.MapFrom(s => s.Balance))
                .ForMember("CreditCard", c => c.MapFrom(s => s.CreditCard))
                ;
            cfg.CreateMap<ApplicationProfileDTO, ApplicationProfile>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Balance", c => c.MapFrom(s => s.Balance))
                .ForMember("CreditCard", c => c.MapFrom(s => s.CreditCard))
                ;
        }
    }
}
