using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ShareCar.Entity;
using ShareCar.Data;

namespace ShareCar.Repository
{
    public class LoginRepo
    {
        public Boolean LoginAdmin(loginEnt adminLogin)
        {

            try
            {

                string query = "select * from loginCredit where username = '" + adminLogin.username + "' and password = '" + adminLogin.password + "' and userType = '"+ adminLogin.userTypeAdmin +"';";
                var dt = DataAccess.GetDataTable(query);

                if (dt.DataSet.Tables[0].Rows.Count == 1)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
