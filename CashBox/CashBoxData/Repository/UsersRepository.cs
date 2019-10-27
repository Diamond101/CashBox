using CashBoxData.Interface;
using CashBoxModel;
using CashBoxModel.SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CashBoxModel.ViewModel.GenericClass;

namespace CashBoxData.Repository
{
    public class UsersRepository : IUser
    {
        private readonly SecurityLayer _security = new SecurityLayer();
        private readonly CashBoxDBContext _db = new CashBoxDBContext();
        public void AddUser(Users user)
        {
            user.Password = _security.Encrypt(user.Password);
            _db.Users.Add(user);
            Save();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool Disposing)
        {
            if (!this.disposed)
            {
                if (Disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Users FindUserById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Deleted == false && u.ID == id);
        }

        public ICollection<Users> GetUsers()
        {
            return _db.Users
            .Where(u => u.Deleted == false)
            .ToList();
        }

        public Users LoginUser(string Email, string password)
        {
            string encryptedPassword = _security.Encrypt(password);

            Users user = _db.Users
                .FirstOrDefault(u => u.Email.ToLower() == Email.ToLower() && u.Password == encryptedPassword && u.Status == UserStatus.Active);

            return user;
        }

        public void UpdateUser(Users user)
        {
            _db.Entry(user).State = EntityState.Modified;
            Save();
        }
        void Save()
        {
            _db.SaveChanges();
        }

       
    }
}

