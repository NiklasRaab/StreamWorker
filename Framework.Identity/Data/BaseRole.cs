using System;
using Framework.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Framework.Identity.Data
{
    public class BaseRole : IdentityRole<int, BaseUserRole>, IBaseEntity
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}