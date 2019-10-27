using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBoxModel
{
    [MetadataType(typeof(UsersMetadata))]
    public partial class Users
    {
        public string Fullname { get { return Surname + " " + FirstName; } }
    }

    public class UsersMetadata
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Image { get; set; }
        public bool Deleted { get; set; }
    }
}
