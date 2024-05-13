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
    public class ProductRepository : BaseRepository<Core.Models.Product, Entities.Product>, IProductRepository
    {
        public ProductRepository(StoreDBContext storeDBContext, IMapper mapper) : base(storeDBContext, mapper) { }
    }
}
