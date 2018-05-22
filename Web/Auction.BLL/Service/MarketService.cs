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
using Auction.BLL.Infrastructure;

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
                Database.Lots.Create(lot);
                Database.SaveAsync();
            }
            throw new ArgumentNullException("lotDTO is null");
        }
        

        public IEnumerable<LotDTO> GetLots(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ArgumentNullException("UserDTO is null");
            }

        }

        public UserDTO GetUser(string userID)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Database?.Dispose();
        }

        public Task<Result> DeleteLotAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> EditLotAsync(LotDTO lotDTO)
        {
            throw new NotImplementedException();
        }
    }
}
