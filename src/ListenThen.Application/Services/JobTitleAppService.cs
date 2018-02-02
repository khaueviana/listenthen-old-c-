using AutoMapper;
using ListenThen.Application.Interfaces;
using ListenThen.Application.ViewModels;
using ListenThen.Domain.Interfaces.Repository;
using ListenThen.Domain.Models;
using System;

namespace ListenThen.Application.Services
{
    public class JobTitleAppService : IJobTitleAppService
    {
        private readonly IJobTitleRepository _jobTitleRepository;
        private readonly IMapper _mapper;

        public JobTitleAppService(IJobTitleRepository jobTitleRepository, IMapper mapper)
        {
            _jobTitleRepository = jobTitleRepository;
            _mapper = mapper;
        }

        public void Add(JobTitleViewModel jobTitleViewModel)
        {
            _jobTitleRepository.Add(_mapper.Map<JobTitle>(jobTitleViewModel));
            _jobTitleRepository.SaveChanges();
        }

        public JobTitleViewModel GetById(Guid id)
        {
            return _mapper.Map<JobTitleViewModel>(_jobTitleRepository.GetById(id));
        }

        public void Update(JobTitleViewModel jobTitleViewModel)
        {
            _jobTitleRepository.Update(_mapper.Map<JobTitle>(jobTitleViewModel));
            _jobTitleRepository.SaveChanges();     
        }

        public void Remove(Guid id)
        {
            _jobTitleRepository.Remove(id);
            _jobTitleRepository.SaveChanges();
        }
    }
}