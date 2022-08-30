using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name:")]
        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }
        [Display(Name = "Gender:")]
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        [Display(Name = "Age:")]
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        [Display(Name = "Salary:")]
        public int Salary { get; set; }
        [Display(Name = "City:")]
        public string City { get; set; }
    }
}
