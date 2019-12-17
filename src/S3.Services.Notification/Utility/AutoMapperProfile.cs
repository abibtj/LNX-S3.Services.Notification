using AutoMapper;
using S3.Services.Notification.Domain;
using S3.Services.Notification.Dto;

namespace S3.Services.Notification.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Message, MessageDto>().ReverseMap();
        }
    }
}
