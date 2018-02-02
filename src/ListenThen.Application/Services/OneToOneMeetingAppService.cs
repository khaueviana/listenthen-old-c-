using AutoMapper;
using ListenThen.Application.Interfaces;
using ListenThen.Application.ViewModels;
using ListenThen.Domain.Interfaces.Repository;
using ListenThen.Domain.Models;
using System;

namespace ListenThen.Application.Services
{
    public class OneToOneMeetingAppService : IOneToOneMeetingAppService
    {
        private readonly IOneToOneMeetingRepository _oneToOneMeetingRepository;
        private readonly IMapper _mapper;

        public OneToOneMeetingAppService(IOneToOneMeetingRepository oneToOneMeetingRepository, IMapper mapper)
        {
            _oneToOneMeetingRepository = oneToOneMeetingRepository;
            _mapper = mapper;
        }

        public OneToOneMeetingViewModel GetById(Guid id)
        {
            return _mapper.Map<OneToOneMeetingViewModel>(_oneToOneMeetingRepository.GetById(id));
        }

        public void Register(OneToOneMeetingViewModel oneToOneMeetingViewModel)
        {
            _oneToOneMeetingRepository.Add(_mapper.Map<OneToOneMeeeting>(oneToOneMeetingViewModel));
        }
    }
}