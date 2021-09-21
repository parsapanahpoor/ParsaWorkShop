using Application.ViewModels;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        bool IsExistPhoneNumber(string PhoneNumber);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);


    }
}
