using CashBoxData.Interface;
using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBoxData.Repository
{
    public class HeightRepository : IHeight
    {
  
        private readonly CashBoxDBContext _db = new CashBoxDBContext();
        public void AddHeight(Height height)
        {
            _db.Height.Add(height);
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

        public Height FindHeightById(int id)
        {
            return _db.Height.FirstOrDefault(u => u.Deleted == false && u.ID == id);
        }

        public ICollection<Height> GetHeight()
        {
            return _db.Height
           .Where(u => u.Deleted == false)
           .ToList();
        }

        public void UpdateHeight(Height height)
        {
            _db.Entry(height).State = EntityState.Modified;
            Save();
        }
        void Save()
        {
            _db.SaveChanges();
        }

        public int CountDeleted()
        {
            return _db.Height.Count(u => u.Deleted == true);
        }

        public int CountNewHeight()
        {
            return _db.Height.Count(u => u.Deleted == false);
        }

        public int CountTotal()
        {
            return _db.Height.Count();
        }
    }
}
