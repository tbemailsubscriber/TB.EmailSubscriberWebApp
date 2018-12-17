using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TB.EmailSubscriber.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}