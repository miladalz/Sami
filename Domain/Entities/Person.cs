﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Person:BaseEntity
    {
        public string Name { get; set; } 
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
