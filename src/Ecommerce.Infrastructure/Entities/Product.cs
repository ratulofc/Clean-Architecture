using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Entities
{
    public class Product
    {
        public Product()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
