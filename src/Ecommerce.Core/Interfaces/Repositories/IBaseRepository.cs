using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        Task<TModel> CreateAsync(TModel entity);
        Task<TModel?> UpdateAsync(int id, TModel entity);
        Task<TModel?> UpdatePatchAsync(int id, JsonPatchDocument<TModel> patchDocument);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TModel>> GetAllAsync(params string[] navsToInclude);
        Task<TModel?> GetById(int id);
    }
}
