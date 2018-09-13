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
        public Result CreateLot(LotDTO lotDTO)
        {
            if (lotDTO != null)
            {
                var mapper = LotDTOToLot.CreateMap();

                Lot lot = mapper.Map<LotDTO, Lot>(lotDTO);
                Database.Lots.Create(lot);
                Database.SaveAsync();
                return new Result(true, $"Lot {lotDTO.Name} is created", "");
            }
            throw new ArgumentNullException("lotDTO is null");
        }
        

        public IEnumerable<LotDTO> GetLots(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                var allLots = Database.Lots.GetAll();
                var mapper = LotToLotDTO.CreateMap();
                var lotDTOs = mapper.Map<IEnumerable<Lot>, IEnumerable<LotDTO>>(allLots);
                return lotDTOs;
            }
            else
            {
                var lots = Database.Lots.Find(x => x.Seller.Id == userDTO.Id);
                var mapper = LotToLotDTO.CreateMap();
                var lotDTOs = mapper.Map<IEnumerable<Lot>, IEnumerable<LotDTO>>(lots);
                return lotDTOs;
            }
            
        }
        
        public void Dispose()
        {
            Database?.Dispose();
        }

        public Task<Result> DeleteLotAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> EditLotAsync(LotDTO lotDTO)
        {
            var mapper = LotToLotDTO.CreateMap();
            var lot = await Database.Lots.Get(lotDTO.Id);
            lot.Price = lotDTO.Price;
            Database.Lots.Update(lot);
            await Database.SaveAsync();
            return new Result(true, $"", "");
        }

        public UserDTO GetProfile(string userID)
        {
            var mapper = UserToUserDTO.CreateMap();
            var varvar = Database.Profiles.GetAll();
            var profiles = Database.Profiles.Find(x => x.Id == userID);
            return mapper.Map<DAL.Entities.ApplicationProfile, UserDTO>(profiles.First());
        }

        public Task<LotDTO> GetLotAsync(string lotId)
        {
            throw new NotImplementedException();
        }
    }
}
