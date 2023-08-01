using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetTest1V4_UPS.DataServices.Base
{
    public interface IDataService<T>
    {
        Task<CreateResult> Create(T model);
        void Edit(T model);
        Task<RemoveResult> Remove(int id);
        Task<GetDataListResult<T>> GetDataListAsync(int page, Dictionary<String, Object> filterValues);
    }
}