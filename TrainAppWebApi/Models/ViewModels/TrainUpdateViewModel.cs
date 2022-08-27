using System;

namespace TrainAppWebApi.Models.ViewModels
{
    public class TrainUpdateViewModel
    {
        public string TrainId { get; set; }

        public string TrainNumber { get; set; }

        public string TrainName { get; set; }

        public string TrainCategory { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string StartStation { get; set; }

        public string EndStation { get; set; }

        public string TrainStops { get; set; }

        public string LastStation { get; set; }

        public string LastTime { get; set; }

        public string LastLatitude { get; set; }

        public string LastLongitude { get; set; }

        public string EstimatedTime { get; set; }

        public string Notes { get; set; }
    }
}
