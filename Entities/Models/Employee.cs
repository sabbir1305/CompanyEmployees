﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
