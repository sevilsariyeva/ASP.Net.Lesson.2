using Lesson._2.Entities;
using System.Collections.Generic;

namespace Lesson._2.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public string ImageLink { get; set; }
        public List<Product> Products { get; set; }
    }
}
