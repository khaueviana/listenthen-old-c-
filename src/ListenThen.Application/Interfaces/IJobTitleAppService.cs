using ListenThen.Application.ViewModels;
using System;

namespace ListenThen.Application.Interfaces
{
    public interface IJobTitleAppService
    {        
        void Add(JobTitleViewModel jobTitleViewModel);
        JobTitleViewModel GetById(Guid id);
        void Update(JobTitleViewModel jobTitleViewModel);
        void Remove(Guid id);
    }
}