using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBoxData.Interface
{
  public  interface IWeight : IDisposable
    {
        Weight FindWeightById(int id);
        ICollection<Weight> GetWeight();
        void AddWeight(Weight weight);
        void UpdateWeight(Weight weight);
        int CountDeleted();
        int CountNewWeight();
        int CountTotal();
    }
}
