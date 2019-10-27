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
 public   class WeightLogic
    {
        private readonly IWeight _weightRepository = new WeightRepository();
        public Weight FindWeightById(int id)
        {
            var wei = _weightRepository.FindWeightById(id);
            return wei;
        }

        public ICollection<Weight> GetWeight()
        {
            return _weightRepository.GetWeight();
        }

        public void AddWeight(Weight weight)
        {
            weight.Deleted = false;
            weight.DateCreated = DateTime.UtcNow;
            _weightRepository.AddWeight(weight);
        }

        public void UpdateWeight(Weight weight)
        {
            var currWei = FindWeightById(weight.ID);
            currWei.WeightValue = weight.WeightValue;            
            _weightRepository.UpdateWeight(currWei);
        }

        public void DeleteWeight(int id)
        {
            var weight = FindWeightById(id);
            weight.Deleted = true;
            _weightRepository.UpdateWeight(weight);

        }
        public int CountDeleted()
        {
            return _weightRepository.CountDeleted();
        }

        public int CountNewWeight()
        {
            return _weightRepository.CountNewWeight();
        }

        public int CountTotal()
        {
            return _weightRepository.CountTotal();
        }
    }
}

