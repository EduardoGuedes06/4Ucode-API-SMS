using _4Ucode_sms.Bussines.Models;
using _4Ucode_sms.Data.Context;
using DevIO.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace _4Ucode_sms.Data.Repository
{
    public class BaseUploadRepository : Repository<UploadDocument>, IBaseUploadRepository
    {
        public BaseUploadRepository(MeuDbContext context) : base(context) {}
    }
}