using Framework.Business.Repository;
using Framework.Data.Model;

namespace StreamWorker.Business.Repository
{
    public interface IStreamWorkerRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
    }
}