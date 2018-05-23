using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Interface;
using Auction.DAL.Market.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Repostories
{
    public class MarketUnitOfWork : IMarketUnitOfWork
    {
        LotMarketContext db;
        IRepository<Lot> lots;
        IRepository<ApplicationProfile> profiles;
        public MarketUnitOfWork(LotMarketContext db)
        {
            this.db = db;
        }
        public IRepository<Lot> Lots
        {
            get
            {
                if (lots == null)
                {
                    lots = new LotRepository(db);
                }
                return lots;
            }
        }
        public IRepository<ApplicationProfile> Profiles
        {
            get
            {
                if (profiles == null)
                {
                    profiles = new ProfileRepository(db);
                }
                return profiles;
            }
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
        ~MarketUnitOfWork()
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
