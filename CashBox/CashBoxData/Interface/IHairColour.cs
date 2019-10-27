using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBoxData.Interface
{
   public interface IHairColour : IDisposable
    {
        HairColour FindHairColourById(int id);
        ICollection<HairColour> GetHairColour();
        void AddHairColour(HairColour hairColour);
        void UpdateHairColour(HairColour hairColour);
    }
}
