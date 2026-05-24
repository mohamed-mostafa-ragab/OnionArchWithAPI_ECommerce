using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }

        #region Relations
        public int BrandId { get; set; } //Foreign key
        public ProductBrand ProductBrand { get; set; } = null!;
        public int TypeId { get; set; } //Foreign key
        public ProductType ProductType { get; set; } = null!;
        #endregion
    }
}
