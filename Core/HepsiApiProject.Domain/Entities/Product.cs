using HepsiApiProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            
        }

        public Product(string title, string description, int vrandId, decimal price, decimal discount)
        {
            Description = description;
            Title = title;
            BrandId = vrandId;
            Price = price;
            Discount = discount;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public Brand Brand { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
