using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Models;

namespace TrainAppWebApi.Data
{
    public interface IPurchasedTicketRepo
    {
        IEnumerable<PurchasedTicket> GetPurchasedTickets();
        PurchasedTicket GetPurchasedTicketByUserId(Guid userId);
    }
}
