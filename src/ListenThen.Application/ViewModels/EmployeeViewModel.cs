using System;

namespace ListenThen.Application.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Genre { get; set; }
        public JobTitleViewModel JobTitle { get; set; }
    }
}
