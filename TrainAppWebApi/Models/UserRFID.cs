using System;
using System.ComponentModel.DataAnnotations;

namespace TrainAppWebApi.Models
{
    public class UserRFID
    {
        [Key]
        public Guid UserId { get; set; }

        public string RfidNumber { get; set; }
    }
}
