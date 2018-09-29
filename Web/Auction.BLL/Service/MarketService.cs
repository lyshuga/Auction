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
using BidDTO = Auction.BLL.DTO.BidDTO;

namespace Auction.BLL.Service
{
    public class MarketService : IMarketService
    {
        IMarketUnitOfWork Database;
        public MarketService(IMarketUnitOfWork iuw)
        {
            Database = iuw;
        }
        public async Task<Result> CreateLot(LotDTO lotDTO)
        {
            if (lotDTO != null)
            {
                Lot lot = Mapper.Map<LotDTO, Lot>(lotDTO);
                var profile = await Database.Profiles.Get(lotDTO.Seller.Id);
                lot.Seller = profile;
                Database.Lots.Create(lot);
                await Database.SaveAsync();
                return new Result(true, $"Lot {lotDTO.Name} is created", "");
            }
            throw new ArgumentNullException("lotDTO is null");
        }
        

        public IEnumerable<LotDTO> GetLots(ApplicationProfileDTO userDTO)
        {
            if (userDTO == null)
            {
                var allLots = Database.Lots.GetAll();
                var lotDTOs = Mapper.Map<IEnumerable<Lot>, IEnumerable<LotDTO>>(allLots);
                return lotDTOs;
            }
            else
            {
                var lots = Database.Lots.Find(x => x.Seller.Id == userDTO.Id).ToList();
                var lotDTOs = Mapper.Map<IEnumerable<Lot>, IEnumerable<LotDTO>>(lots);
                return lotDTOs;
            }
        }

        public async Task DeleteLotAsync(int id)
        {
            await Database.Lots.DeleteAsync(id);
            await Database.SaveAsync();
        }

        public async Task<Result> EditLotAsync(LotDTO lotDTO)
        {
            var lot = await Database.Lots.Get(lotDTO.Id);
            lot.StartPrice = lotDTO.StartPrice;
            Database.Lots.Update(lot);
            await Database.SaveAsync();
            return new Result(true, $"", "");
        }

        public async Task<ApplicationProfileDTO> GetProfile(string userID)
        {
            var profiles = Database.Profiles.GetAll();
            var foundProfile = await Database.Profiles.Get(userID);
            return Mapper.Map<ApplicationProfile, ApplicationProfileDTO>(foundProfile);
        }

        public async Task<LotDTO> GetLotAsync(int lotId)
        {
            var lot = await Database.Lots.Get(lotId);
            var lotDTO = Mapper.Map<Lot, LotDTO>(lot);
            return lotDTO;
        }

        public async Task MakeBidAsync(BidDTO bidDTO)
        {
            var bidder = await Database.Profiles.Get(bidDTO.Bidder.Id);
            var lot = await Database.Lots.Get(bidDTO.Lot.Id);
            var bid = Mapper.Map<BidDTO, Bid>(bidDTO);
            bid.Lot = lot;
            bid.Bidder = bidder;
            Database.Bids.Create(bid);
            await Database.SaveAsync();
        }
        public BidDTO FindBid(int lotId)
        {
            var bid = Database.Bids.Find(x => x.Lot.Id == lotId).LastOrDefault();
            var bidDTO = Mapper.Map<Bid, BidDTO>(bid);
            return bidDTO;
        }
    }
}
