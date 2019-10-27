using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBoxData.Interface
{
   public interface IPeople:IDisposable
    {
        People FindPeopleById(int id);
        ICollection<People> GetPeople();
        void AddPeople(People people);
        void UpdatePeople(People people);
        int CountDeleted();
        int CountNewMember();
        int CountTotal();       
    }
}
