using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainAppWebApi.Models
{
    public class PurchasedTicket
    {
        [Key]
        public Guid PurchasedTicketId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        //[MaxLength(250)]
        public int TicketType { get; set; }

        [Required]
        public string FromStation { get; set; }

        [Required]
        public string ToStation { get; set; }

        [Required]
        public int TicketClass { get; set; }

        [Required]
        public DateTime PurchasedDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

    }
}
