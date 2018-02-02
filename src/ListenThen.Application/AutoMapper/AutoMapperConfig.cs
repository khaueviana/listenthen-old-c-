using AutoMapper;

namespace ListenThen.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OneToOneMeetingProfile());
            });
        }
    }
}