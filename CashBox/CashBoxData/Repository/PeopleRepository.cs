using CashBoxData.Interface;
using CashBoxModel;
using CashBoxModel.SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBoxData.Repository
{
    public class PeopleRepository : IPeople
    {
        private readonly SecurityLayer _security = new SecurityLayer();
        private readonly CashBoxDBContext _db = new CashBoxDBContext();
        public void AddPeople(People people)
        {
           _db.People.Add(people);
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


        public People FindPeopleById(int id)
        {
            return _db.People.FirstOrDefault(u => u.Deleted == false && u.ID == id);
        }

        public ICollection<People> GetPeople()
        {
            return _db.People
            .Where(u => u.Deleted == false)
            .ToList();
        }

        public void UpdatePeople(People people)
        {
            _db.Entry(people).State = EntityState.Modified;
            Save();
        }
        void Save()
        {
            _db.SaveChanges();
        }

        public int CountDeleted()
        {
            return _db.People.Count(u => u.Deleted == true);
        }
               
        public int CountNewMember()
        {
            return _db.People.Count(u => u.Deleted == false );
        }

        public int CountTotal()
        {
            return _db.People.Count();
        }
    }
}
