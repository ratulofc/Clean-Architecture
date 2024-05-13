using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces.Services
{
    public interface IBaseService<TRequest, TResponse, T> where T : class
    {
        Task<IEnumerable<TResponse>> GetAll();
        Task<TResponse?> GetById(int id);
        Task<TResponse> Add(TRequest request);
        Task<bool> Delete(int id);
        Task<TResponse?> Update(int id, TRequest requestDTO);
        Task<TResponse?> UpdatePatch(int id, JsonPatchDocument<T> patchDocument);
    }
}
