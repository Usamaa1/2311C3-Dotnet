using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicsWithDBProject.Models
{

    public class Employee
    {
        [Key]
        [DisplayName("Employee Id")]
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Employee Name", Prompt = "Enter Employee Name")]
        [MinLength(10)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(5, 16)]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$", ErrorMessage ="Password should contain one uppercase one lowercase and one number and one special symbol")]
        public string Password { get; set; }
    }

}
