using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBoxData.Interface
{
    public   interface IHeight : IDisposable
    {
        Height FindHeightById(int id);
        ICollection<Height> GetHeight();
        void AddHeight(Height height);
        void UpdateHeight(Height height);
        int CountDeleted();
        int CountNewHeight();
        int CountTotal();
    }
}
