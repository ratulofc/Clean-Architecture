using AutoMapper;
using Ecommerce.Core.Interfaces.Repositories;
using Ecommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly StoreDBContext storeDBContext;
        public IUserRepository UserRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }

        public RepositoryWrapper(StoreDBContext storeDBContext, IMapper mapper)
        {
            this.storeDBContext = storeDBContext;
            UserRepository = new UserRepository(storeDBContext, mapper);
            ProductRepository = new ProductRepository(storeDBContext, mapper);
        }

        public async Task<int> SaveAsync()
        {
            return await storeDBContext.SaveChangesAsync();
        }
    }
}
