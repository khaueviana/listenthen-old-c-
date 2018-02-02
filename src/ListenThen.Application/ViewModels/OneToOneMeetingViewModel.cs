using System;
using System.Collections.Generic;

namespace ListenThen.Application.ViewModels
{
    public class OneToOneMeetingViewModel
    {
        public Guid Id { get; set; }
        public EmployeeViewModel Manager { get; set; }
        public EmployeeViewModel Receiver { get; set; }
        public List<MeetingPointViewModel> Points { get; set; }
        public List<MeetingNoteViewModel> Notes { get; set; }
        public DateTime Created { get; set; }
    }
}