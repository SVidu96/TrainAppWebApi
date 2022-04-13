using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainAppWebApi.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string NicNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
