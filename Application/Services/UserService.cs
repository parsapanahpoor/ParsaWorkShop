using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public bool IsExistEmail(string email)
        {
            return _userRepository.IsExistEmail(email.Trim().ToLower());
        }

        public bool IsExistPhoneNumber(string PhoneNumber)
        {
            return _userRepository.IsExistPhoneNumber(PhoneNumber);
        }

        public bool IsExistUserName(string userName)
        {
            return _userRepository.IsExistUserName(userName);
        }

        public User LoginUser(LoginViewModel login)
        {
            string PhoneNumber = FixedText.FixEmail(login.phoneNumber);
        }
    }
}
