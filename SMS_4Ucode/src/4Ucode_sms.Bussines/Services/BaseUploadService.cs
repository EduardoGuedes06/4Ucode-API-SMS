using _4Ucode_sms.Bussines.Interfaces;
using _4Ucode_sms.Bussines.Models;
using _4Ucode_sms.Data.Repository;
using AutoMapper;
using Business.Interfaces;
using Business.Services;

namespace _4Ucode_sms.Bussines.Services
{
    public class BaseUploadService : BaseService, IBaseUploadService
    {
        private readonly IMapper _mapper;
        private readonly IBaseUploadRepository _baseUploadRepository;

        public BaseUploadService(IBaseUploadRepository documento,INotificador notificador, IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _baseUploadRepository = documento;  
        }

        public Task GetDocuments<UploadDocumentResponse>(Guid operatorId)
        {
            throw new NotImplementedException();
        }

        public async Task Upload(UploadDocument documento)
        {
            await _baseUploadRepository.Adicionar(documento);
        }
    }
}
