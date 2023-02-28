
using Domain.Models.Enums;

namespace Domain.Models.ModelTwillo
{
    public class TwilloMensageModel : TwilloModel
    {
        public TwilloMensageModel()
        {
            AccountSid = "AC97d8820f4fbfb3884c78587da93e6937";
            AuthToken = "5ee4cfb8e03b13da94b83dfc81ccabcd";
            ToPhoneNumber = "+5511953078189";
            FromPhoneNumber = "+16193299142";
            ServiceSid = "MGc5b6e7504c14e704058827f77e8d3a4a";


        }
    }
    public class TwilloModel : Entity
    {

        public string Mensagem { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string ServiceSid { get; set; }
        public string ToPhoneNumber { get; set; }
        public string FromPhoneNumber { get; set; }
        public SendTwilloEnum StatusSend { get; set; }
    }
}
