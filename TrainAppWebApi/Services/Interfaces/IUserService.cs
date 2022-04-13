using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainAppWebApi.Models;
using TrainAppWebApi.Models.ViewModels;

namespace TrainAppWebApi.Services.Interfaces
{
    public interface IUserService
    {
        User GetUser(UserLogin userLogin);

        User AddUser(UserSignupViewModel userSignupViewModel);

        UserLogin AddUserLogin(UserLogin userLogin);

        bool IsUsernameAvailable(string username);
    }
}
