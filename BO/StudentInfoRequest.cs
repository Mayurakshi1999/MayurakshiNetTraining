using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [MessageContract]
    public class StudentInfoRequest
    {
        [MessageHeader]
        public HeaderInfo Header { get; set; }

        [MessageBodyMember]
        public StudentBO Body { get; set; }
    }
}
