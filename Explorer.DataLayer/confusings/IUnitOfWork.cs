using System;
using System.Data.Entity;

namespace Explorer.DataLayer.confusings
{
    public interface IUnitOfWork<out TContext>: IDisposable where TContext : DbContext
    {
        int Save();
        TContext Context { get; }
    }
}
