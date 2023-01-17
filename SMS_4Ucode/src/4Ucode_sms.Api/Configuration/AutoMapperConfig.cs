using _4Ucode_sms.Api.Controllers;
using _4Ucode_sms.Bussines.Models;
using AutoMapper;
using Business.Models;

namespace _4Ucode_sms.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UploadDocumentViewModel, UploadDocument>().ReverseMap();


        }
    }
}
