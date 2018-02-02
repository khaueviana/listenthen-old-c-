using System;
using AutoMapper;
using ListenThen.Application.Interfaces;
using ListenThen.Application.ViewModels;
using ListenThen.Domain.Interfaces.Repository;
using ListenThen.Domain.Models;

namespace ListenThen.Application.Services
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJobTitleRepository _jobTitleRepository;
        private readonly IMapper _mapper;

        public EmployeeAppService(IEmployeeRepository employeeRepository, IJobTitleRepository jobTitleRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _jobTitleRepository = jobTitleRepository;
            _mapper = mapper;
        }
        public EmployeeViewModel GetById(Guid id)
        {
            return _mapper.Map<EmployeeViewModel>(_employeeRepository.GetById(id));
        }
        public void Register(EmployeeViewModel employeeViewModel)
        {

            var domain = _mapper.Map<Employee>(employeeViewModel);

            domain.JobTitle = _jobTitleRepository.GetById(new Guid("C1EBE077-C5B0-49F5-3FE3-08D55DCDFB1D"));

            _employeeRepository.Add(domain);
            _employeeRepository.SaveChanges();
        }
    }
}