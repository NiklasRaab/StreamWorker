using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using Framework.Data;
using Framework.Data.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using StreamWorker.Data.Models;
using Task = StreamWorker.Data.Models.Task;

namespace StreamWorker.Data.DataContext
{
    public class StreamWorkerDataContext : IdentityDbContext<StreamWorkerUser, StreamWorkerRole, int, StreamWorkerUserLogin, StreamWorkerUserRole, StreamWorkerUserClaim>,
        IBaseDataContext<StreamWorkerDataContext>
    {
        public static StreamWorkerDataContext CreateInstanz()
        {
            return new StreamWorkerDataContext();
        }

        public override int SaveChanges()
        {
            DataContextHelper.TrackChanges(ChangeTracker);
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            DataContextHelper.TrackChanges(ChangeTracker);
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            DataContextHelper.TrackChanges(ChangeTracker);
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Task> Tasks { get; set; }
    }
}