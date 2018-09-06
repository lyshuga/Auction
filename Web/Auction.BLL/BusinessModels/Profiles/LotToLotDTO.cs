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
    public static class LotToLotDTO
    {
        static MapperConfiguration config;
        static LotToLotDTO()
        {
            config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Lot, LotDTO>()
                .ForMember("Id", c => c.MapFrom(s => s.Id))
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Description", c => c.MapFrom(s => s.Description))
                .ForMember("GoodType", c => c.MapFrom(s => s.GoodType))
                .ForMember("Photo", c => c.MapFrom(s=> s.Photo))
                .ForMember("Price", c => c.MapFrom(s => s.Price))
                .ForMember("StartDate", c => c.MapFrom(s => s.StartDate))
                .ForMember("ExpireDate", c => c.MapFrom(s => s.ExpireDate))
                .ForMember("LastBid", c => c.MapFrom(s => s.LastBid));

            });
        }
        public static IMapper CreateMap()
        {
            return config.CreateMapper();
        }
    }
}
