using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace _4Ucode_sms.Bussines.Models
{


    public class UploadDocument : Entity
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }

        public byte[] Dados { get; set; }
        public string ContentType { get; set; }
    }

}