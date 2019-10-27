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
    public class WeightRepository : IWeight
    {
        private readonly CashBoxDBContext _db = new CashBoxDBContext();
        public void AddWeight(Weight weight)
        {
            _db.Weight.Add(weight);
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
        public Weight FindWeightById(int id)
        {
            return _db.Weight.FirstOrDefault(u => u.Deleted == false && u.ID == id);
        }

        public ICollection<Weight> GetWeight()
        {
            return _db.Weight
          .Where(u => u.Deleted == false)
          .ToList();
        }

        public void UpdateWeight(Weight weight)
        {
            _db.Entry(weight).State = EntityState.Modified;
            Save();
        }
        void Save()
        {
            _db.SaveChanges();
        }

        public int CountDeleted()
        {
            return _db.Weight.Count(u => u.Deleted == true);
        }

        public int CountNewWeight()
        {
            return _db.Weight.Count(u => u.Deleted == false);
        }

        public int CountTotal()
        {
            return _db.Weight.Count();
        }
    }
}
