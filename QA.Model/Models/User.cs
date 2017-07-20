using QA.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Model.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual City City { get; set; }
        public int CityId { get; set; }

        public virtual Student Student{ get; set; }
        public virtual Professor Professor { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserPasswordForget> PasswordForget { get; set; }        

    }
}
