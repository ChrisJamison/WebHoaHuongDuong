using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ProductEntity
    {
        public ProductEntity()
        {
            this.CartDetails = new HashSet<CartDetailEntity>();
        }

        public int Product_ID { get; set; }
        public string Name { get; set; }
        public int Category_ID { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Image { get; set; }
        public Nullable<System.DateTime> DateUpload { get; set; }
        public int Price { get; set; }
        public int NumberInStock { get; set; }

        public virtual ICollection<CartDetailEntity> CartDetails { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
