using ListenThen.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ListenThen.Domain.Models
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Genre { get; set; }
        public JobTitle JobTitle { get; set; }
        public List<OneToOneMeeeting> OneToOneMeetingManagers { get; set; }
        public List<OneToOneMeeeting> OneToOneMeetingReceivers { get; set; }
        public List<MeetingNote> MeetingNoteAuthors { get; set; }
        public List<MeetingPoint> MeetingPointAuthors { get; set; }
    }
}