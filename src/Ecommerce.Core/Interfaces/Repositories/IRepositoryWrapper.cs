using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        Task<int> SaveAsync();
    }
}
