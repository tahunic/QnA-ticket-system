﻿using QA.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Model.Models
{
    public class Professor : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public virtual User User { get; set; }
    }
}
