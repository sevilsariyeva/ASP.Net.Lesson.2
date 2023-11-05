using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lesson._2.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [DisplayName("Price")]
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        [DisplayName("Discount")]
        [Required(ErrorMessage = "Discount is required")]
        public int Discount { get; set; }
        public string ImageLink { get; set; }
    }
}

