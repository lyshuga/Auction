using System;
using NUnit.Framework;
using NUnit;
using Auction.BLL.Service;
using Auction.BLL.DTO;
using Auction.DAL.Repostories;
using Auction.BLL.Infrastructure;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace Auction.Test
{
    [TestFixture]
    public class IdentityServiceTest
    {
        [Test]
        public async Task Create_ShouldBeNoExcpetionsAsync()
        {
            IdentityService service = new IdentityService(new IdentityUnitOfWork(new DAL.EF.LotMarketContext("DefaultConnection")));
            UserDTO user = new UserDTO() { Name = "Kolia", Email = "kolia@gmail.com", Password = "pukpuk", Role = "admin", Balance = 234, CreditCard = "1234567890" };
            
            try
            {
                Result result = await service.CreateAsync(user);
            }
            catch (DbEntityValidationException ex)
            {
                string s = "";
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        s += "Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage;
                    }
                }
                throw new Exception(s);
            }
        }
    }
}
