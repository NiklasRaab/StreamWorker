using StreamWorker.Data.DataContext;
using StreamWorker.Data.Models;

namespace StreamWorker.Business.Repository
{
    public class TaskRepository : StreamWorkerRepository<Task>, ITaskRepository
    {
        public TaskRepository(StreamWorkerDataContext dataContext) : base(dataContext)
        {
        }
    }
}