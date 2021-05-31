using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareCar.Entity;
using ShareCar.Data;
using System.Data;

namespace ShareCar.Repository
{
    public class ExeRepo
    {
         
        public Boolean ExLogin(loginEnt ExeLogin)
        {

            try
            {

                string query = "select * from loginCredit where username = '" + ExeLogin.username + "' and password = '" + ExeLogin.password + "' and userType = '" + ExeLogin.userTypeExe + "';";
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

        ExeEnt exeEnt = new ExeEnt();

        public List<ExeEnt> GetAll()
        {
            var exeEnt = new List<ExeEnt>();
            var sql = "select * from CarList";
            var dt = DataAccess.GetDataTable(sql);
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                ExeEnt k = ConvertToEntity(dt.Rows[index]);
                exeEnt.Add(k);
            }
            return exeEnt;
        }
        public ExeEnt ConvertToEntity(DataRow row)
        {
            if (row == null)
            {
                return null;
            }
            var k = new ExeEnt();
            k.id = Convert.ToInt32(row["id"].ToString());
            k.CarSeatNumber = row["CarSeatNumber"].ToString();
            k.CarNumber = row["CarNumber"].ToString();
            k.CarStatus = row["CarStatus"].ToString();
            k.DriverName = row["DriverName"].ToString();
            return k;
        }
    }
}
