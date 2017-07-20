using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Configuration
{
    public class UserPasswordForgetConfiguration : EntityTypeConfiguration<UserPasswordForget>
    {
        public UserPasswordForgetConfiguration()
        {
            ToTable("UserPasswordForget");
            Property(u=>u.Code).IsRequired();
            Property(u=>u.UserId).IsRequired();
        }
    }
}
