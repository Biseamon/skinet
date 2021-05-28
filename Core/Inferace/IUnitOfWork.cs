using System;
using System.Threading.Tasks;
using skinet.Core;
using skinet.Core.Inferace;

namespace Core.Inferace
{
    public interface IUnitOfWork : IDisposable
    {
         IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
         Task<int> Complete();
    }
}