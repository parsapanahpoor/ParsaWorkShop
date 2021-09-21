using Application.Convertors;
using Application.Genarator;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void DeleteUser(int userId)
        {
            User user = GetUserById(userId);
            user.IsDelete = true;
            UpdateUser(user);
        }

        public void EditProfile(string username, EditProfileViewModel profile)
        {
            if (profile.UserAvatar != null)
            {
                string imagePath = "";
                if (profile.AvatarName != "Defult.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", profile.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                profile.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(profile.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", profile.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.UserAvatar.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar/thumb", profile.AvatarName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);

            }

            User user = GetUserByUserName(username);
            user.Email = profile.Email;
            user.PhoneNumber = profile.PhoneNumber;
            user.UserAvatar = profile.AvatarName;

            UpdateUser(user);
        }

        public EditProfileViewModel GetDataForEditProfileUser(string username)
        {
            User user = GetUserByUserName(username);

            EditProfileViewModel editProfile = new EditProfileViewModel()
            {
                AvatarName = user.UserAvatar,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };

            return editProfile;
        }

        public User GetUserByActiveCode(string ActiveCode)
        {
            return _userRepository.GetUserByActiveCode(ActiveCode);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email.Trim().ToLower());
        }

        public User GetUserById(int Userid)
        {
            return _userRepository.GetUserById(Userid);
        }

        public User GetUserByPhoneNumber(string PhoneNumber)
        {
            return _userRepository.GetUserByPhoneNumber(PhoneNumber.Trim().ToLower());
        }

        public User GetUserByUserName(string username)
        {
            return _userRepository.GetUserByUserName(username);
        }

        public int GetUserIdByUserName(string userName)
        {
            return _userRepository.GetUserIdByUserName(userName);
        }

        public InformationUserViewModel GetUserInformation(string username)
        {
            var user = GetUserByUserName(username);
            InformationUserViewModel information = new InformationUserViewModel();
            information.UserName = user.UserName;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;
            information.PhoneNumber = user.PhoneNumber;

            return information;
        }

        public List<int> GetUsersRoles(string username)
        {
            User user = GetUserByUserName(username);
            return _userRepository.GetUsersRoles(user);
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
            return _userRepository.LoginUser(PhoneNumber , login.Password);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            _userRepository.Savechanges();
        }
    }
}
