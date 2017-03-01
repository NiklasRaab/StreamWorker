using System;

namespace Framework.Data.Model
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}