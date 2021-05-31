using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareCar.Entity
{
    public class loginEnt
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string userTypeAdmin { get; set; }
        public string userTypeUser { get; set; }
        public string userTypeExe { get; set; }

    }
}
