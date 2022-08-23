using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TrainAppWebApi.Models;
using TrainAppWebApi.Services.Interfaces;

namespace TrainAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainUpdateController : BaseApiController
    {
        private ITrainUpdateService _trainUpdateService;
        //private readonly IWebHostEnvironment _env;
        public TrainUpdateController(
            IWebHostEnvironment environment,
            ITrainUpdateService trainUpdateService) : base(environment)
        {
            //_env = environment;
            _trainUpdateService = trainUpdateService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrainUpdate>> GetTrainUpdates()
        {
            var trainUpdates = _trainUpdateService.GetTrainUpdates();
            return Ok(trainUpdates);
        }

        [HttpPut]
        public ActionResult<IEnumerable<TrainUpdate>> AddTrainUpdate(TrainUpdate trainUpdate)
        {
            _trainUpdateService.AddTrainUpdate(trainUpdate);
            return Ok(trainUpdate);
        }
    }
}
