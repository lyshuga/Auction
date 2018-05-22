using Auction.BLL.DTO;
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
                .ForMember("Name", c => c.MapFrom(s => s.Name))
                .ForMember("Description", c => c.MapFrom(s => s.Description))
                .ForMember("GoodType", c => c.MapFrom(s => s.GoodType))
                .ForMember("Photo", c => c.MapFrom(s=> ImageConverter.byteArrayToImage(s.Photo)))
                .ForMember("Price", c => c.MapFrom(s => s.Price))
                .ForMember("StartDate", c => c.MapFrom(s => s.StartDate))
                .ForMember("ExpireDate", c => c.MapFrom(s => s.ExpireDate))
                .ForMember("LastBid", c => c.MapFrom(s => s.LastBid))
                .ForMember("BidderId", c => c.MapFrom(s => s.BidderId))
                .ForMember("SellerId", c => c.MapFrom(s => s.SellerId));

            });
        }
        public static IMapper CreateMap()
        {
            return config.CreateMapper();
        }
    }
}
