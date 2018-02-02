using ListenThen.Application.ViewModels;
using System;

namespace ListenThen.Application.Interfaces
{
    public interface IEmployeeAppService
    {
        EmployeeViewModel GetById(Guid id);
        void Register(EmployeeViewModel employeeViewModel);
    }
}