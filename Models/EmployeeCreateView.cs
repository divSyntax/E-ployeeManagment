using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public class EmployeeCreateView
    {
        [Required]
        [MaxLength(10, ErrorMessage = "10 MAX!")]
        public string Name { get; set; }

        [Required]
        public Dept? Dep { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format.")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        public IFormFile Photo { get; set; }
    }
}
