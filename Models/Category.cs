using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30, ErrorMessage ="Maximum length of Category Name is 30 characters.")]
        public string CategoryName { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Display order range is between 1-100.")]
        public int DisplayOrder { get; set; }

    }
}
