using System;
using NUnit.Framework;
using NUnit;
using Auction.BLL.Service;
using Auction.BLL.DTO;
using Auction.DAL.Repostories;
using Auction.BLL.Infrastructure;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using Auction.DAL.UnitOfWork.Service;

namespace Auction.Test
{
    [TestFixture]
    public class IdentityServiceTest
    {
        //[Test]
        //public async Task Create_ShouldBeNoExcpetionsAsync()
        //{
        //    IdentityService service = new IdentityService(new IdentityUnitOfWork(new DAL.EF.MarketContext("DefaultConnection")));
        //    ApplicationUserDTO user = new ApplicationUserDTO() { Name = "Kolia", Email = "kolia@gmail.com", Password = "pukpuk", Role = "admin", Balance = 234, CreditCard = "1234567890" };
            
        //    try
        //    {
        //        Result result = await service.CreateAsync(user);
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        string s = "";
        //        foreach (var entityValidationErrors in ex.EntityValidationErrors)
        //        {
        //            foreach (var validationError in entityValidationErrors.ValidationErrors)
        //            {
        //                s += "Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage;
        //            }
        //        }
        //        throw new Exception(s);
        //    }
        //}
    }
}
