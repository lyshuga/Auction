using Auction.BLL.DTO;
using Auction.BLL.Interface;
using Auction.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

                Lot lot = Mapper.Map<LotDTO, Lot>(lotDTO);
                Database.Lots.Create(lot);
                Database.SaveAsync();
                return new Result(true, $"Lot {lotDTO.Name} is created", "");
            }
            throw new ArgumentNullException("lotDTO is null");
        }
        

        public IEnumerable<LotDTO> GetLots(ApplicationUserDTO userDTO)
        {
            if (userDTO == null)
            {
                var allLots = Database.Lots.GetAll();
                var lotDTOs = Mapper.Map<IEnumerable<Lot>, IEnumerable<LotDTO>>(allLots);
                return lotDTOs;
            }
            else
            {
                var lots = Database.Lots.Find(x => x.Seller.Id == userDTO.Id);
                var lotDTOs = Mapper.Map<IEnumerable<Lot>, IEnumerable<LotDTO>>(lots);
                return lotDTOs;
            }
            
        }

        public Task<Result> DeleteLotAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> EditLotAsync(LotDTO lotDTO)
        {
            var lot = await Database.Lots.Get(lotDTO.Id);
            lot.StartPrice = lotDTO.StartPrice;
            Database.Lots.Update(lot);
            await Database.SaveAsync();
            return new Result(true, $"", "");
        }

        public ApplicationUserDTO GetProfile(string userID)
        {
            var profiles = Database.Profiles.GetAll();
            var foundProfiles = Database.Profiles.Find(x => x.Id == userID);
            return Mapper.Map<DAL.Entities.ApplicationProfile, ApplicationUserDTO>(foundProfiles.First());
        }

        public Task<LotDTO> GetLotAsync(string lotId)
        {
            throw new NotImplementedException();
        }
    }
}
