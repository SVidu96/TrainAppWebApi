using System;
using System.Collections.Generic;
using TrainAppWebApi.Models;

namespace TrainAppWebApi.Services.Interfaces
{
    public interface ITrainService
    {
        Train GetTrainById(Guid trainId);
    }
}
