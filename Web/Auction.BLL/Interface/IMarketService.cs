using Auction.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Interface
{
    public interface IMarketService
    {

        void CreateLot(LotDTO lotDTO);
        UserDTO GetUser(string userID);
        IEnumerable<LotDTO> GetLots(UserDTO userDTO);
    }
}
