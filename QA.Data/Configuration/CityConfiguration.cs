using QA.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Configuration
{
    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            ToTable("Cities");
            Property(c=>c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
