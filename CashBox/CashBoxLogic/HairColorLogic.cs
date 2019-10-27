using CashBoxData.Interface;
using CashBoxData.Repository;
using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBoxLogic
{
 public   class HairColorLogic
    {
        private readonly IHairColour _hairColourRepository = new HairColourRepository();
        public HairColour FindHairColourById(int id)
        {
            var hei = _hairColourRepository.FindHairColourById(id);
            return hei;
        }
        public ICollection<HairColour> GetHairColour()
        {
            return _hairColourRepository.GetHairColour();
        }

        public void AddHairColour(HairColour hairColour)
        {
            hairColour.Deleted = false;
            hairColour.DateCreated = DateTime.UtcNow;
            _hairColourRepository.AddHairColour(hairColour);
        }

        public void UpdateHairColour(HairColour hairColour)
        {
            var currHair = FindHairColourById(hairColour.ID);
            currHair.Colour = hairColour.Colour;
            _hairColourRepository.UpdateHairColour(currHair);
        }

        public void DeleteHairColour(int id)
        {
            var hairColour = FindHairColourById(id);
            hairColour.Deleted = true;
            _hairColourRepository.UpdateHairColour(hairColour);

        }

    }
}
