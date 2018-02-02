using ListenThen.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ListenThen.Domain.Models
{
    public class JobTitle : Entity
    {
        public string Description { get; set; }
        public List<Employee> Employees { get; set; }
    }
}