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
    public class UserRepository : BaseRepository<Core.Models.User, Entities.User>, IUserRepository
    {
        public UserRepository(StoreDBContext storeDBContext, IMapper mapper) : base(storeDBContext, mapper) { }
    }
}
