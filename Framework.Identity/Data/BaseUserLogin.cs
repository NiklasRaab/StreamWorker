using System;
using Framework.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Framework.Identity.Data
{
    public class BaseUserLogin : IdentityUserLogin<int>, IBaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}