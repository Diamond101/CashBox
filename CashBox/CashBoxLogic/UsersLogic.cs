using CashBoxData.Interface;
using CashBoxData.Repository;
using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CashBoxLogic
{
  public  class UsersLogic
    {
        private readonly IUser _usersRepository = new UsersRepository();
        public Users FindUserById(int id)
        {
            var user = _usersRepository.FindUserById(id);           
            return user;
        }

        public ICollection<Users> GetUsers()
        {
            return _usersRepository.GetUsers();
        }
       
        public void AddUser(Users user)
        {
            var fullname = user.FirstName + " " + user.Surname;
            user.Deleted = false;
            user.DateCreated = DateTime.UtcNow;
            _usersRepository.AddUser(user);
        }

        public void UpdateUser(Users user)
        {
            var currUser = FindUserById(user.ID);
            currUser.FirstName = user.FirstName;
            currUser.Surname = user.Surname;           
            currUser.DateOfBirth = user.DateOfBirth;           
            currUser.Email = user.Email;
            currUser.Phone = user.Phone;           
            currUser.Status = user.Status;           
            currUser.Image = user.Image ?? currUser.Image;           
            currUser.Password = user.Password ?? currUser.Password;
            _usersRepository.UpdateUser(currUser);
            
        }

        public bool LoginUser(string username, string password)
        {
            Users user = _usersRepository.LoginUser(username, password);
            if (user != null)
            {
                CreateUserSession(user);
                return true;
            }

            HttpContext.Current.Session["FailedUser"] = username;
            return false;

        }

        void CreateUserSession(Users user)
        {
            UserSession userSession = new UserSession()
            {
                UserID = user.ID,
                Fullname = user.Fullname,
                Email = user.Email,
                Image = user.Image
            };
            HttpContext.Current.Session["UserSession"] = userSession;
        }

        public void DeleteUser(int id)
        {
            var user = FindUserById(id);
            user.Deleted = true;
            _usersRepository.UpdateUser(user);
           
        }
    }
}

