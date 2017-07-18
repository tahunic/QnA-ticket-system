using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            Property(u => u.Fname).IsRequired().HasMaxLength(50);
            Property(u => u.Lname).IsRequired().HasMaxLength(50);
            Property(u => u.Username).IsRequired().HasMaxLength(50);
            Property(u => u.Password).IsRequired().HasMaxLength(50);
            Property(u => u.CityId).IsRequired();
        }
    }
}
