using Auction.BLL.DTO;
using Auction.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Interface;
using Auction.BLL.Infrastructure;
using Auction.DAL.Entities;
using Microsoft.AspNet.Identity;
using Auction.BLL.Infrastructure.Exceptions;

namespace Auction.BLL.Service
{
    public class IdentityService : IIdentityService
    {
        IIdentityUnitOfWork Database;
        public IdentityService(IIdentityUnitOfWork iuw)
        {
            Database = iuw;
        }
        public async Task<ClaimsIdentity> Authenticate(ApplicationUserDTO userDto)
        {
            if (userDto != null)
            {
                if (string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.Password))
                {
                    throw new ValidateException("Email or password is invalid");
                }
                ClaimsIdentity claim = null;
                
                ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
                
                if (user != null)
                    claim = await Database.UserManager.CreateIdentityAsync(user,
                                                DefaultAuthenticationTypes.ApplicationCookie);
                return claim;
            }
            throw new ArgumentNullException("UserDTO is null");
        }

        public async Task<Result> CreateAsync(ApplicationUserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new Result(false, result.Errors.FirstOrDefault(), "");
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                ApplicationProfile clientProfile = new ApplicationProfile { Id = user.Id, Name = userDto.ApplicationProfile.Name, Balance = userDto.ApplicationProfile.Balance, CreditCard = userDto.ApplicationProfile.CreditCard };
                user.ApplicationProfile = clientProfile;
                var list = Database.UserManager.Users.ToList();
                await Database.SaveAsync();
                return new Result(true, $"User {userDto.Email} has been registered", "");
            }
            else
            {
                return new Result(false, $"The user with {userDto.Email} is already registered", "Email");
            }
        }
        public async Task SetInitialData(ApplicationUserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await CreateAsync(adminDto);
        }
        public Task<Result> DeleteUserAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> EditUserAsync(ApplicationUserDTO userDto)
        {
            throw new NotImplementedException();
        }
    }
}
