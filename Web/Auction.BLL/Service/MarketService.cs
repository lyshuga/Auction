using Auction.BLL.DTO;
using Auction.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Service
{
    public class MarketService : IMarketService
    {

        public void CreateLot(LotDTO lotDTO)
        {
            throw new NotImplementedException();
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
