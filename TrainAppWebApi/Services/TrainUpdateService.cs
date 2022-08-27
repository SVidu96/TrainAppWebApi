using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Data;
using TrainAppWebApi.Models;
using TrainAppWebApi.Models.ViewModels;
using TrainAppWebApi.Services.Interfaces;

namespace TrainAppWebApi.Services
{
    public class TrainUpdateService : ITrainUpdateService
    {
        private readonly ITrainAppRepo _trainAppRepo;

        public TrainUpdateService(ITrainAppRepo trainAppRepo)
        {
            _trainAppRepo = trainAppRepo;
        }

        public TrainUpdate AddTrainUpdate(TrainUpdateViewModel trainUpdateViewModel)
        {
            var trainUpdate = new TrainUpdate();
            trainUpdate.TrainId = Guid.Parse(trainUpdateViewModel.TrainId);
            trainUpdate.LastStation = trainUpdateViewModel.LastStation;
            trainUpdate.LastLatitude = Convert.ToSingle(trainUpdateViewModel.LastLatitude);
            trainUpdate.LastLongitude = Convert.ToSingle(trainUpdateViewModel.LastLongitude);
            trainUpdate.LastTime =Convert.ToDateTime(trainUpdateViewModel.LastTime);
            trainUpdate.EstimatedTime = trainUpdateViewModel.EstimatedTime;
            trainUpdate.Notes = trainUpdateViewModel.Notes;

            return _trainAppRepo.Update<TrainUpdate>(trainUpdate);
        }

        public IEnumerable<TrainUpdate> GetTrainUpdateById(Guid trainId)
        {
            return _trainAppRepo.GetAll<TrainUpdate>().Where(x => x.TrainId == trainId);    
        }

        public IEnumerable<TrainUpdate> GetTrainUpdates()
        {
            return _trainAppRepo.GetAll<TrainUpdate>().ToList();
        }

        private void getTime(string time)
        {
           
        }
    }
}
