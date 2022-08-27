using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainAppWebApi.Models
{
    public class Train
    {
        [Key]
        public Guid TrainId { get; set; }

        [Required]
        public string TrainNumber { get; set; }

        public string TrainName { get; set; }

        public string TrainCategory { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string TrainStops { get; set; }

        [Required]
        public string StartStation { get; set; }

        [Required]
        public string EndStation { get; set; }

    }
}
