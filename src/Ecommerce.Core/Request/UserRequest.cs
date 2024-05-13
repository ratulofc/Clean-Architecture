using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Request
{
    public class UserRequest
    {
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string Email { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public int ProductId { get; set; }
    }
}
