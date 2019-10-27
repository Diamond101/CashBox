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
    public  class HeightLogic
    {
        private readonly IHeight _heightRepository = new HeightRepository();
        public Height FindHeightById(int id)
        {
            var hei = _heightRepository.FindHeightById(id);
            return hei;
        }
        public ICollection<Height> GetHeight()
        {
            return _heightRepository.GetHeight();
        }

        public void AddHeight(Height height)
        {
            height.Deleted = false;
            height.DateCreated = DateTime.UtcNow;
            _heightRepository.AddHeight(height);
        }

        public void UpdateHeight(Height height)
        {
            var currHei = FindHeightById(height.ID);
            currHei.HeightNumber = height.HeightNumber;
            _heightRepository.UpdateHeight(currHei);
        }

        public void DeleteHeight(int id)
        {
            var height = FindHeightById(id);
            height.Deleted = true;
            _heightRepository.UpdateHeight(height);

        }
        public int CountDeleted()
        {
            return _heightRepository.CountDeleted();
        }

        public int CountNewHeight()
        {
            return _heightRepository.CountNewHeight();
        }

        public int CountTotal()
        {
            return _heightRepository.CountTotal();
        }
    }
}

