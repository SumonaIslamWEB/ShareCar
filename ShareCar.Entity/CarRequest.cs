using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareCar.Entity
{
    public class CarRequest
    {
        public int id { get; set; }
        public string time { get; set; }
        public string reason { get; set; }
        public string address { get; set; }
        public string status { get; set; }

    }
}
