using System.ComponentModel.DataAnnotations;

namespace RestAPIPractice.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name can't be null")]
        public string name { get; set; }
        [Required(ErrorMessage = "Description can't be null")]
        public string description { get; set; }
        public string Url { get; set; }
    }
}
