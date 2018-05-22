using Auction.BLL.DTO;
using Auction.BLL.Interface;
using Auction.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Auction.BLL.BusinessModels.Profiles;
using Auction.DAL.Entities;

namespace Auction.BLL.Service
{
    public class MarketService : IMarketService
    {
        IMarketUnitOfWork Database;
        public MarketService(IMarketUnitOfWork iuw)
        {
            Database = iuw;
        }
        public void CreateLot(LotDTO lotDTO)
        {
            if (lotDTO != null)
            {
                var mapper = LotDTOToLot.CreateMap();
                Lot lot = mapper.Map<LotDTO, Lot>(lotDTO);

            }
        }
        

        public IEnumerable<LotDTO> GetLots(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUser(string userID)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
