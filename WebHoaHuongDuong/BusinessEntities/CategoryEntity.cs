﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CategoryEntity
    {
        public CategoryEntity()
        {
            this.Products = new HashSet<ProductEntity>();
        }

        public int Category_ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public Nullable<int> Level { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
