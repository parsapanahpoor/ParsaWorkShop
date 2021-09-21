﻿using Domain.Models.ContactUs;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        void Savechanges();
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        bool IsExistPhoneNumber(string PhoneNumber);
        int AddUser(User user);
        User LoginUser(string PhoneNumber , string Password);
        User GetUserByEmail(string email);
        User GetUserByPhoneNumber(string PhoneNumber);
        User GetUserByActiveCode(string ActiveCode);
        User GetUserById(int Userid);
        void UpdateUser(User user);
        int GetUserIdByUserName(string userName);
        User GetUserByUserName(string username);
        List<int> GetUsersRoles(User user);




        #region User Panel

        bool CompareOldPassword(string oldPassword, string username);
        void ChangeUserPassword(string userName, string newPassword);
        List<User> GetUsersInRoles(int Role);

        #endregion




        #region Panel Admin

        List<User> GetUsers();
        List<User> GetDeleteUsers();
        //int AddUserFromAdmin(CreateUserViewModel user);
        //EditUserViewModel GetUserForShowInEditMode(int userId);
        //void EditUserFromAdmin(EditUserViewModel editUser);
        //SideBarUserPanelViewModel GetSideBarUserPanelData(string username);

        #endregion




        #region ContactUs

        void addMessage(ContactUs contactus);
        List<ContactUs> GetAllMessages();
        ContactUs GetMessageById(int id);

        #endregion
    }
}