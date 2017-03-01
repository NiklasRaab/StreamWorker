using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Framework.Data.Model;

namespace Framework.Data
{
    public static class DataContextHelper
    {
        public static void TrackChanges(DbChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries())
            {
                var entity = (IBaseEntity) entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.Created = DateTime.Now;
                        entity.Updated = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entity.Updated = DateTime.Now;
                        break;
                }
            }
        }
    }
}