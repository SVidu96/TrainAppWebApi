using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Models;

namespace TrainAppWebApi.Services.Interfaces
{
    public interface IPurchaseTicketService
    {
        IEnumerable<PurchasedTicket> GetPurchasedTickets();
        IEnumerable<PurchasedTicket> GetPurchasedTicketsByUserId(Guid userId);
        IEnumerable<PurchasedTicket> GetPurchasedTicketsByTicketId(Guid ticketId);
        PurchasedTicket AddPurchasedTicket(PurchasedTicket purchasedTicket);
        bool DeletePurchasedTicket(Guid ticketId);
    }
}
