using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainAppWebApi.Models.ViewModels
{
    public class UserTokenViewModel
    {
        public User user { get; set; }
        public string token { get; set; }
    }
}
