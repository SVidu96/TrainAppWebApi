using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Data;
using TrainAppWebApi.Models;
using TrainAppWebApi.Services.Interfaces;

namespace TrainAppWebApi.Services
{
    public class PurchaseTicketService : IPurchaseTicketService
    {
        private readonly ITrainAppRepo _trainAppRepo;

        public PurchaseTicketService(ITrainAppRepo trainAppRepo)
        {
            _trainAppRepo = trainAppRepo;
        }
        public IEnumerable<PurchasedTicket> GetPurchasedTicketsByUserId(Guid userId)
        {
            return _trainAppRepo.GetAll<PurchasedTicket>().Where(s => s.UserId == userId).OrderByDescending(p => p.PurchasedDate).ToList();
        }

        public IEnumerable<PurchasedTicket> GetPurchasedTickets()
        {
            return _trainAppRepo.GetAll<PurchasedTicket>().ToList();
        }

        public PurchasedTicket AddPurchasedTicket(PurchasedTicket purchasedTicket)
        {
            return _trainAppRepo.Add<PurchasedTicket>(purchasedTicket);
        }

        public bool DeletePurchasedTicket(Guid ticketId)
        {
            var purchasedTicket = _trainAppRepo.GetAll<PurchasedTicket>().FirstOrDefault(t => t.PurchasedTicketId == ticketId);

            if (purchasedTicket != null) {
                _trainAppRepo.Remove<PurchasedTicket>(purchasedTicket);
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<PurchasedTicket> GetPurchasedTicketsByTicketId(Guid ticketId)
        {
            return _trainAppRepo.GetAll<PurchasedTicket>().Where(s => s.PurchasedTicketId == ticketId).OrderByDescending(p => p.PurchasedDate).ToList();
        }
    }
}
