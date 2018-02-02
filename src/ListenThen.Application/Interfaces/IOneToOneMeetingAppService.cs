using ListenThen.Application.ViewModels;
using System;

namespace ListenThen.Application.Interfaces
{
    public interface IOneToOneMeetingAppService
    {
        OneToOneMeetingViewModel GetById(Guid id);
        void Register(OneToOneMeetingViewModel oneToOneMeetingViewModel);
    }
}