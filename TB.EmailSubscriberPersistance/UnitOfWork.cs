using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TB.EmailSubscriber.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _persistance;

        public UnitOfWork(AppDbContext persistence)
        {
            this._persistance = persistence;
        }

        public async Task CompleteAsync()
        {
            await _persistance.SaveChangesAsync();
        }
    }
}