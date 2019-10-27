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
    public class HairColourRepository : IHairColour
    {
        private readonly CashBoxDBContext _db = new CashBoxDBContext();
        public void AddHairColour(HairColour hairColour)
        {
            _db.HairColour.Add(hairColour);
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

        public HairColour FindHairColourById(int id)
        {
            return _db.HairColour.FirstOrDefault(u => u.Deleted == false && u.ID == id);
        }

        public ICollection<HairColour> GetHairColour()
        {
            return _db.HairColour
         .Where(u => u.Deleted == false)
         .ToList();
        }

        public void UpdateHairColour(HairColour hairColour)
        {
            _db.Entry(hairColour).State = EntityState.Modified;
            Save();
        }
        void Save()
        {
            _db.SaveChanges();
        }
    }
}
