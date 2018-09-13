using Auction.BLL.DTO;
using Auction.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Interface
{
    public interface IIdentityService
    {
        Task<Result> CreateAsync(ApplicationUserDTO userDto);
        Task<ClaimsIdentity> Authenticate(ApplicationUserDTO userDto);
        Task<Result> DeleteUserAsync(string Id);
        Task<Result> EditUserAsync(ApplicationUserDTO userDto);
        Task SetInitialData(ApplicationUserDTO adminDto, List<string> roles);
    }
}
