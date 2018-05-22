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

namespace Auction.BLL.Service
{
    public class IdentityService : IIdentityService
    {
        IIdentityUnitOfWork Database;
        public IdentityService(IIdentityUnitOfWork iuw)
        {
            Database = iuw;
        }
        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            if (userDto != null)
            {
                if (string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.Password))
                {
                    //TODO: 
                }
                
            }
            return null;
        }

        public async Task<Result> CreateAsync(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new Result(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                ApplicationProfile clientProfile = new ApplicationProfile { Id = user.Id, Name = userDto.Name, Balance = userDto.Balance, CreditCard = userDto.CreditCard };
                user.ApplicationProfile = clientProfile;
                await Database.SaveAsync();
                return new Result(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new Result(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            throw new NotImplementedException();
        }
    }
}
