using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Data;
using TrainAppWebApi.Models;
using TrainAppWebApi.Models.ViewModels;
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

        public User AddUser(UserSignupViewModel userSignupViewModel)
        {
            var userRegister = new User
            {
                UserId = new Guid(),
                Username = userSignupViewModel.Username,
                EmailAddress = userSignupViewModel.EmailAddress,
                FirstName = userSignupViewModel.FirstName,
                LastName = userSignupViewModel.LastName,
                NicNumber = userSignupViewModel.NicNumber,
                Password = userSignupViewModel.Password,
                Role = "User"
            };

            return _trainAppRepo.Add<User>(userRegister);
        }

        public UserLogin AddUserLogin(UserLogin userLogin)
        {
            return _trainAppRepo.Add<UserLogin>(userLogin);
        }

        public User GetUser(UserLogin userLogin)
        {
            return _trainAppRepo.GetAll<User>().FirstOrDefault(s => s.Username == userLogin.Username && s.Password == userLogin.Password);
        }

        public bool IsUsernameAvailable(string username)
        {
            var user = _trainAppRepo.GetAll<UserLogin>().FirstOrDefault(s => s.Username == username);
            
            if (user != null)
                return false;
            else
                return true;
        }
    }
}
