using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhagaa.DataEntities
{
    public class ActionResultEntity
    {
        public ActionResultEntity()
        {
            this.Status = "success";
            this.StatusResult = true;
        }
        public string Status { get; set; }
        public bool StatusResult { get; set; }
        public string Message { get; set; }
        public object ReturnObject { get; set; }
    }
}
