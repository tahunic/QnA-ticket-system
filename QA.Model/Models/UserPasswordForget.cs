using QA.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Model.Models
{
    public class UserPasswordForget : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public Guid Code { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
