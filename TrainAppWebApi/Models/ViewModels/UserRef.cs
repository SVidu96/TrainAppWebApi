using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainAppWebApi.Models.ViewModels
{
    public class UserRef
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string NicNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
