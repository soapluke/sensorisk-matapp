﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UsersOptions : IEntity
    {
        public int ID { get; set; }
        public String Option { get; set; }
    }
}
