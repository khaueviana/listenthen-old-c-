using System;
using AutoMapper;
using ListenThen.Application.ViewModels;
using ListenThen.Domain.Models;

namespace ListenThen.Application.AutoMapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();

            CreateMap<JobTitleViewModel, JobTitle>();
            CreateMap<JobTitle, JobTitleViewModel>();
        }       
    }
}