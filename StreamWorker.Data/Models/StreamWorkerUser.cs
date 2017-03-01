using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StreamWorker.Data.Models
{
    public class StreamWorkerUser : IdentityUser<int, StreamWorkerUserLogin, StreamWorkerUserRole, StreamWorkerUserClaim>
    {
        public virtual ICollection<Task> Tasks { get; set; }
    }
}