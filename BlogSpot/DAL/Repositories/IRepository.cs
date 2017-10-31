using System;
using System.Collections.Generic;

namespace BlogSpot.DAL.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class 
    {
        ICollection<TEntity> GetAll();
        TEntity Get(int id);
    }
}
