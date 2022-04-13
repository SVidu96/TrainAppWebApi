using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Models;

namespace TrainAppWebApi.Services.Interfaces
{
    public interface IUserService
    {
        User GetUser(UserLogin userLogin);
    }
}
