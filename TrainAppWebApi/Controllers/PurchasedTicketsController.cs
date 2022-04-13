using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Data;
using TrainAppWebApi.Models;
using TrainAppWebApi.Models.ViewModels;
using TrainAppWebApi.Services.Interfaces;

namespace TrainAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasedTicketsController : ControllerBase
    {
        private IPurchaseTicketService _purchaseTicketService;

        public PurchasedTicketsController(IPurchaseTicketService purchaseTicketService)
        {
            _purchaseTicketService = purchaseTicketService;
        }
        //private readonly MockPurchasedTicketRepo _repository = new MockPurchasedTicketRepo();

        //can remove after testing
        
        [HttpGet]
        [Authorize] 
        public ActionResult<IEnumerable<PurchasedTicket>> GetAllPurchasedTickets()
        {
            var purchasedTickets = _purchaseTicketService.GetPurchasedTickets();
            return Ok(purchasedTickets);
        }


        // api/purchasedtickets/1
        [HttpGet("{userid}")]
        public ActionResult<IEnumerable<PurchasedTicket>> GetPurchasedTicketsByUserId(string userid)
        {  
            if (Guid.TryParse(userid, out var guidId))
            {
                var guidUserId = Guid.Parse(userid);
                var purchasedTickets = _purchaseTicketService.GetPurchasedTicketsByUserId(guidUserId);
                return Ok(purchasedTickets);
            }
            else {
                return BadRequest("Invalid UserId");
            } 
        }

        [HttpPost]
        public ActionResult<PurchasedTicket> AddPurchasedTicket(PurchasedTicketViewModel purchasedTicketViewModel)
        {
            var purchasedTicket = PurchasedTicketViewModel.ToDataModel(purchasedTicketViewModel);
            purchasedTicket = _purchaseTicketService.AddPurchasedTicket(purchasedTicket);
            return Ok(purchasedTicket);
        }

        [HttpDelete("{ticketId}")]
        public ActionResult DeletePurchasedTicket(string ticketId)
        {
            var result = false;
            if(Guid.TryParse(ticketId, out Guid guidOut))
            {
                var guidTicketId = Guid.Parse(ticketId);
                result = _purchaseTicketService.DeletePurchasedTicket(guidTicketId);
            }

            if (result)
                return Ok("Success");
            else
                return StatusCode(StatusCodes.Status500InternalServerError,"Failed");
        }

    }
}
 