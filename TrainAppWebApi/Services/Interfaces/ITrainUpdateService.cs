using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Models;

namespace TrainAppWebApi.Services.Interfaces
{
    public interface ITrainUpdateService
    {
        IEnumerable<TrainUpdate> GetTrainUpdates();
        IEnumerable<TrainUpdate> GetTrainUpdateById(Guid trainId);
        TrainUpdate AddTrainUpdate(TrainUpdate trainUpdate);
        
        //Add a function to reset the update at the end of the day
    }
}
