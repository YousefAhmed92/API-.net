using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.Product.DTOs
{
    public class ProductDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public string PictureUrl { get; set; }
        public int BrandId { get; set; }

        public int TypeId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
