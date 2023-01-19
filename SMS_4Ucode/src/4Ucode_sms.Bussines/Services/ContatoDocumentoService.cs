using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Bussines.Interfaces;
using Data.Repository;

namespace _4Ucode_sms.Bussines.Services
{
    public class ContatoDocumentoService : BaseService, IContatoDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IContatoDocumentoRepository _baseUploadRepository;

        public ContatoDocumentoService(IContatoDocumentoRepository documento,INotificador notificador, IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _baseUploadRepository = documento;  
        }

        public Task GetDocuments<UploadDocumentResponse>(Guid operatorId)
        {
            throw new NotImplementedException();
        }

        public async Task Adicionar(ContatoDocumento documento)
        {
            await _baseUploadRepository.Adicionar(documento);
        }


    }
}
