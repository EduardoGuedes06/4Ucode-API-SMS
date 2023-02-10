using _4Ucode_sms.Api.VewModel;
using _4Ucode_sms.Api.ViewModel.ViewModelTwilio;
using AutoMapper;
using Domain.Models;
using Domain.Models.ModelTwillo;

namespace _4Ucode_sms.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ContatoDocumentoViewModel, ContatoDocumento>().ReverseMap();
            CreateMap<EnvioDocumentoViewModel, EnvioDocumento>().ReverseMap();

            CreateMap<PostMensageTwilloViewModel, TwilloMensageModel>().ReverseMap();
            CreateMap<PostTwilloViewModel, TwilloModel>().ReverseMap();

        }
    }
}
