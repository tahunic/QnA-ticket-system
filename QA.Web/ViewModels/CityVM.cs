using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QA.Web.ViewModels
{
    public class CityVM
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
    }
}