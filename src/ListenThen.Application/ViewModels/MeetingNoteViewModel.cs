using System;

namespace ListenThen.Application.ViewModels
{
    public class MeetingNoteViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EmployeeViewModel Author { get; set; }
        public DateTime Created { get; set; }
    }
}