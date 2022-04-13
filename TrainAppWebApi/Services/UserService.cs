using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Data;
using TrainAppWebApi.Models;
using TrainAppWebApi.Services.Interfaces;

namespace TrainAppWebApi.Services
{
    public class UserService :IUserService
    {
        private readonly ITrainAppRepo _trainAppRepo;
        public UserService(ITrainAppRepo trainAppRepo)
        {
            _trainAppRepo = trainAppRepo;
        }

        public User GetUser(UserLogin userLogin)
        {
            return _trainAppRepo.GetAll<User>().FirstOrDefault(s => s.Username == userLogin.UserName && s.Password == userLogin.Password);
        }
    }
}
