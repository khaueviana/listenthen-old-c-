using ListenThen.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ListenThen.Domain.Models
{
    public class OneToOneMeeeting : Entity
    {
        public Employee Manager { get; set; }
        public Employee Receiver { get; set; }
        public List<MeetingPoint> Points { get; set; }
        public List<MeetingNote> Notes { get; set; }
        public DateTime Created { get; set; }
    }
}