using Data.Context;
using Domain.Interfaces;
using Domain.Models.ContactUs;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Ctor

        private ParsaWorkShopContext _context;

        public UserRepository(ParsaWorkShopContext context)
        {
            _context = context;
        }

        #endregion

        public void addMessage(ContactUs contactus)
        {
            throw new NotImplementedException();
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public void ChangeUserPassword(string userName, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool CompareOldPassword(string oldPassword, string username)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetAllMessages()
        {
            throw new NotImplementedException();
        }

        public List<User> GetDeleteUsers()
        {
            throw new NotImplementedException();
        }

        public ContactUs GetMessageById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByActiveCode(string ActiveCode)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int Userid)
        {
            throw new NotImplementedException();
        }

        public User GetUserByPhoneNumber(string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public int GetUserIdByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersInRoles(int Role)
        {
            throw new NotImplementedException();
        }

        public List<int> GetUsersRoles(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistPhoneNumber(string PhoneNumber)
        {
            return _context.Users.Any(p => p.PhoneNumber == PhoneNumber);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public User LoginUser(string PhoneNumber, string Password)
        {
            return _context.Users.SingleOrDefault(u => u.PhoneNumber == PhoneNumber && u.Password == Password);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }


    }
}
