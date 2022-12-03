﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
