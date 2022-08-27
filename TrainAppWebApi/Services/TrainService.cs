using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Data;
using TrainAppWebApi.Models;
using TrainAppWebApi.Services.Interfaces;

namespace TrainAppWebApi.Services

{
    public class TrainService : ITrainService
    {
        private readonly ITrainAppRepo _trainAppRepo;

        public TrainService(ITrainAppRepo trainAppRepo)
        {
            _trainAppRepo = trainAppRepo;
        }

        public Train GetTrainById(Guid trainId)
        {
            return _trainAppRepo.GetAll<Train>().FirstOrDefault(x => x.TrainId == trainId);
        }
    }
}
