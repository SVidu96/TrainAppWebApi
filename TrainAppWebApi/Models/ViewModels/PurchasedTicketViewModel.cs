using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainAppWebApi.Models.ViewModels
{
    public class PurchasedTicketViewModel
    {
        public Guid PurchasedTicketId { get; set; }

        public Guid UserId { get; set; }

        public int TicketType { get; set; }

        public string FromStation { get; set; }

        public string ToStation { get; set; }

        public int TicketClass { get; set; }

        public DateTime PurchasedDate { get; set; }

        public DateTime ExpirationDate { get; set; }


        public static PurchasedTicket ToDataModel(PurchasedTicketViewModel purchasedTicketViewModel)
        {
            return new PurchasedTicket()
            {
                PurchasedTicketId = new Guid(),
                UserId = purchasedTicketViewModel.UserId,
                TicketType = purchasedTicketViewModel.TicketType,
                FromStation = purchasedTicketViewModel.FromStation,
                ToStation = purchasedTicketViewModel.ToStation,
                TicketClass = purchasedTicketViewModel.TicketClass,
                PurchasedDate = purchasedTicketViewModel.PurchasedDate,
                ExpirationDate = purchasedTicketViewModel.ExpirationDate
            };
        }

        public static PurchasedTicketViewModel ToViewModel(PurchasedTicket purchasedTicket)
        {
            return new PurchasedTicketViewModel()
            {
                PurchasedTicketId = purchasedTicket.PurchasedTicketId,
                UserId = purchasedTicket.UserId,
                TicketType = purchasedTicket.TicketType,
                FromStation = purchasedTicket.FromStation,
                ToStation = purchasedTicket.ToStation,
                TicketClass = purchasedTicket.TicketClass,
                PurchasedDate = purchasedTicket.PurchasedDate,
                ExpirationDate = purchasedTicket.ExpirationDate
            };
        }
    }
}
