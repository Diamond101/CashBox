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
    public  class PeopleLogic
    {
        private readonly IPeople _peopleRepository = new PeopleRepository();
        public People FindPeopleById(int id)
        {
            var peo = _peopleRepository.FindPeopleById(id);
            return peo;
        }

        public ICollection<People> GetPeople()
        {
            return _peopleRepository.GetPeople();
        }

        public void AddPeople(People people)
        {
            TimeSpan dateDiff =  DateTime.UtcNow - people.DateOfBirth;

            people.Deleted = false;
            people.DateCreated = DateTime.UtcNow;
            people.Age = dateDiff.Days / 365;
            _peopleRepository.AddPeople(people);
        }

        public void UpdatePeople(People people)
        {
            TimeSpan dateDiff = DateTime.UtcNow - people.DateOfBirth;
            var currPer = FindPeopleById(people.ID);
            currPer.FirstName = people.FirstName;
            currPer.Surname = people.Surname;
            currPer.DateOfBirth = people.DateOfBirth;
            currPer.Age = dateDiff.Days / 365;
            currPer.Height = people.Height;
            currPer.HairColour = people.HairColour;
            currPer.Weight = people.Weight;
           _peopleRepository.UpdatePeople(currPer);

        }

        public void DeletePeople(int id)
        {
            var people = FindPeopleById(id);
            people.Deleted = true;
            _peopleRepository.UpdatePeople(people);

        }
        public int CountDeleted()
        {
            return _peopleRepository.CountDeleted();
        }

        public int CountNewMember()
        {
            return _peopleRepository.CountNewMember();
        }

        public int CountTotal()
        {
            return _peopleRepository.CountTotal();
        }
    }

}

