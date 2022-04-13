using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Models;

namespace TrainAppWebApi.Data
{
    public class MockPurchasedTicketRepo : IPurchasedTicketRepo
    {
        public PurchasedTicket GetPurchasedTicketByUserId(Guid userId)
        {
            return new PurchasedTicket { UserId = new Guid(), PurchasedTicketId = new Guid(), TicketType = 1, TicketClass = 3, FromStation = "FOT", ToStation = "GPH", PurchasedDate = DateTime.Today, ExpirationDate = DateTime.Today.AddDays(1) };
        }

        public IEnumerable<PurchasedTicket> GetPurchasedTickets()
        {
            var PurchasedTickets = new List<PurchasedTicket>
            {
                new PurchasedTicket { UserId = Guid.Parse("3d15835d-4daf-4925-a987-5a1f6989d93b"), PurchasedTicketId = new Guid(), TicketType = 1, TicketClass = 3, FromStation = "MIR", ToStation = "GPH", PurchasedDate = DateTime.Today, ExpirationDate = DateTime.Today.AddDays(1) },
                new PurchasedTicket { UserId = Guid.Parse("45ada696-e12d-420f-8227-db0ab55b49db"), PurchasedTicketId = new Guid(), TicketType = 1, TicketClass = 3, FromStation = "PLG", ToStation = "FOT", PurchasedDate = DateTime.Today, ExpirationDate = DateTime.Today.AddDays(1) }
            };

            return PurchasedTickets;
        }
    }
}
