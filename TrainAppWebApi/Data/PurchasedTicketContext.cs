using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Models;

namespace TrainAppWebApi.Data
{
    public class PurchasedTicketContext :DbContext
    {
        public PurchasedTicketContext(DbContextOptions<PurchasedTicketContext> opt):base(opt)
        {

        }

        public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }



    }
}
