using System.Threading;
using System.Threading.Tasks;
using Framework.Data;
using Framework.Data.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Framework.Identity.Data
{
    public class BaseIdentityDataContext<TDataContextType> :IdentityDbContext <BaseUser, BaseRole, int, BaseUserLogin, BaseUserRole, BaseUserClaim>,
        IBaseDataContext<TDataContextType>
        where TDataContextType : IBaseDataContext<TDataContextType>, new()
    {
        private static TDataContextType _instanz;

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

        public static TDataContextType CreateInstanz()
            => _instanz != null ? _instanz : (_instanz = new TDataContextType());
    }
}