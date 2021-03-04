using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiHandson.DTOs
{
    public class CommandCreateDto
    {
        [Required]
        
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string City { get; set; }
    }
}
