using System.Runtime.Serialization;

namespace BO
{
    [DataContract]
    public class HeaderInfo
    {
        [DataMember]
        public string TransactionID { get; set; }
        [DataMember]
        public string CallStatus { get; set; }
    }
}