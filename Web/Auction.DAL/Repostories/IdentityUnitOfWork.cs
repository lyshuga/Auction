using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Identity;
using Auction.DAL.Interface;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Repostories
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        LotMarketContext db;
        
        public ApplicationUserManager UserManager { get; }
        public ApplicationRoleManager RoleManager { get; }
        public IdentityUnitOfWork(string connectionString)
        {
            db = new LotMarketContext(connectionString);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
        }
        
        
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UserManager?.Dispose();
                    RoleManager?.Dispose();
                }
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        ~IdentityUnitOfWork()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(false);
        }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
