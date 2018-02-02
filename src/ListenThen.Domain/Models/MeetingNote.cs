using ListenThen.Domain.Core.Models;
using System;

namespace ListenThen.Domain.Models
{
    public class MeetingNote : Entity
    {
        public string Description { get; set; }
        public OneToOneMeeeting OneToOneMeeting { get; set; }
        public Employee Author { get; set; }
        public DateTime Created { get; set; }
    }
}