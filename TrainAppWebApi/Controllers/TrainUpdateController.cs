using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TrainAppWebApi.Models;
using TrainAppWebApi.Models.ViewModels;
using TrainAppWebApi.Services.Interfaces;

namespace TrainAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainUpdateController : BaseApiController
    {
        private ITrainUpdateService _trainUpdateService;
        private ITrainService _trainService;
        private readonly IWebHostEnvironment _env;
        public TrainUpdateController(
            IWebHostEnvironment environment,
            ITrainUpdateService trainUpdateService,
            ITrainService trainService) : base(environment)
        {
            _env = environment;
            _trainUpdateService = trainUpdateService;
            _trainService = trainService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrainUpdateViewModel>> GetTrainUpdates()
        {
            var updates = _trainUpdateService.GetTrainUpdates();
            var trainUpdates = new List<TrainUpdateViewModel>();

            foreach (var update in updates)
            {
                var train = new Train();
                train = _trainService.GetTrainById(update.TrainId);
                var trainUpdate = new TrainUpdateViewModel()
                {
                    TrainId = update.TrainId.ToString(),
                    EstimatedTime = update.EstimatedTime,
                    LastLatitude =  update.LastLatitude.ToString(),
                    LastLongitude = update.LastLongitude.ToString(),
                    LastTime = update.LastTime.ToString(),
                    Notes = update.Notes,
                    LastStation = update.LastStation,
                    EndTime = train.EndTime.ToString(),
                    StartTime = train.StartTime.ToString(),
                    TrainCategory = train.TrainCategory,
                    TrainName = train.TrainName,
                    TrainNumber = train.TrainNumber,
                    TrainStops = train.TrainStops,
                    StartStation = train.StartStation,
                    EndStation = train.EndStation,
                };

                trainUpdates.Add(trainUpdate);
            }


            return Ok(trainUpdates);
        }

        [HttpPut]
        public ActionResult<IEnumerable<TrainUpdateViewModel>> AddTrainUpdate(TrainUpdateViewModel trainUpdate)
        {
            _trainUpdateService.AddTrainUpdate(trainUpdate);
            return Ok(trainUpdate);
        }
    }
}
