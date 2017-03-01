using System;
using Framework.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Framework.Identity.Data
{
    public class BaseUser : IdentityUser<int, BaseUserLogin, BaseUserRole, BaseUserClaim>, IBaseEntity
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}