
using _4Ucode_sms.Bussines.Models;

namespace _4Ucode_sms.Bussines.Interfaces
{
    public interface IBaseUploadService
    {

        Task GetDocuments<UploadDocument> (Guid operatorId);
        Task Upload(UploadDocument request);
    }
}
