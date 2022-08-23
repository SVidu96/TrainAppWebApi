using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainAppWebApi.Models
{
    public class TrainUpdate
    {
        [Key]
        public Guid TrainId { get; set; }

        public string LastStation { get; set; }

        public DateTime LastTime { get; set; }

        public float LastLatitude { get; set; }

        public float LastLongitude { get; set; }

        public string EstimatedTime { get; set; }

        public string Notes { get; set; }
    }
}
