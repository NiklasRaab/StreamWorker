using System;

namespace Framework.Data.Model
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTimeOffset Created { get; set; }
        DateTimeOffset Updated { get; set; }
    }
}