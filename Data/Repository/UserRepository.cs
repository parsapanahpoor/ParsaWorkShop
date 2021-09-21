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
            return _context.Users.FirstOrDefault(p => p.ActiveCode == ActiveCode);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserById(int Userid)
        {
            return _context.Users.Find(Userid);
        }

        public User GetUserByPhoneNumber(string PhoneNumber)
        {
            return _context.Users.FirstOrDefault(p => p.PhoneNumber == PhoneNumber);
        }

        public User GetUserByUserName(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public int GetUserIdByUserName(string userName)
        {
            return _context.Users.Single(u => u.UserName == userName).UserId;
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersInRoles(int Role)
        {
            throw new NotImplementedException();
        }

        public List<int> GetUsersRoles(User user)
        {
            return _context.UsersRoles.Where(p => p.UserId == user.UserId).Select(p => p.RoleId).ToList();
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

        public void Savechanges()
        {
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
        }


    }
}
