using Auction.BLL.DTO;
using Auction.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Interface
{
    public interface IMarketService:IDisposable
    {
        Result CreateLot(LotDTO lotDTO);
        Task<Result> DeleteLotAsync(string id);
        Task<Result> EditLotAsync(LotDTO lotDTO);

        UserDTO GetProfile(string userID);
        IEnumerable<LotDTO> GetLots(UserDTO userDTO);
        Task<LotDTO> GetLotAsync(string lotId);
    }
}
