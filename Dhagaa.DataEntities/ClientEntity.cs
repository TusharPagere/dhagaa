using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhagaa.DataEntities
{
    public class ClientEntity
    {
        public long UserId { get; set; }
        public int UserTypeId { get; set; }
        public string IPAddress { get; set; }
    }
}
