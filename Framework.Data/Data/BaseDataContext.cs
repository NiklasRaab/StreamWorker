using System.Data.Entity;

namespace Framework.Data.Data
{
    public class BaseDataContext<TDataContextType> : DbContext, IBaseDataContext<TDataContextType>
        where TDataContextType : IBaseDataContext<TDataContextType>
    {
    }
}