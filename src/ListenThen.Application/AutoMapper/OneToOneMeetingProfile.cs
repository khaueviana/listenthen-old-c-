using AutoMapper;
using ListenThen.Application.ViewModels;
using ListenThen.Domain.Models;

namespace ListenThen.Application.AutoMapper
{
    public class OneToOneMeetingProfile : Profile
    {
        public OneToOneMeetingProfile()
        {
            CreateMap<OneToOneMeeeting, OneToOneMeetingViewModel>();
            CreateMap<OneToOneMeetingViewModel, OneToOneMeeeting>();

            CreateMap<MeetingPointViewModel, MeetingPoint>();
            CreateMap<MeetingPoint, MeetingPointViewModel>();

            CreateMap<MeetingNoteViewModel, MeetingNote>();
            CreateMap<MeetingNote, MeetingNoteViewModel>();
        }
    }
}