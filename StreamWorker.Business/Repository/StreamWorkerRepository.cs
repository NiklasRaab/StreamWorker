using Framework.Business.Repository;
using Framework.Data.Model;
using StreamWorker.Data.DataContext;

namespace StreamWorker.Business.Repository
{
    public class StreamWorkerRepository<TEntity> : Repository<TEntity, StreamWorkerDataContext>
        where TEntity : BaseEntity
    {
        protected StreamWorkerRepository(StreamWorkerDataContext dataContext) : base(dataContext)
        {
        }
    }
}