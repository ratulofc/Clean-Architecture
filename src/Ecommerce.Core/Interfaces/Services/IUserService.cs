using Ecommerce.Core.Models;
using Ecommerce.Core.Request;
using Ecommerce.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces.Services
{
    public interface IUserService : IBaseService<UserRequest, UserResponse, User>
    {
    }
}
