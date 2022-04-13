using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Models;

namespace TrainAppWebApi.Data
{
    public class SqlPurchasedTicketRepo : IPurchasedTicketRepo
    {
        private PurchasedTicketContext _context;

        public SqlPurchasedTicketRepo(PurchasedTicketContext context)
        {
            _context = context;
        }
        public PurchasedTicket GetPurchasedTicketByUserId(Guid userId)
        {
            return _context.PurchasedTickets.FirstOrDefault(p => p.UserId == userId);
        }

        public IEnumerable<PurchasedTicket> GetPurchasedTickets()
        {
            return _context.PurchasedTickets.ToList();
        }
    }
}
