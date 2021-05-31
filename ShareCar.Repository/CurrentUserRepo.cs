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
    public class CurrentUserRepo
    {
        public bool CurrentUserStore(CurrentUserValue currentUser)
        {
            try
            {
                string query = "insert into currentUser values(' " + currentUser.currentUser + " ')";
                int count = DataAccess.ExecuteUpdateQuery(query);

                if (count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                //MessageBox.Show(Console.WriteLine(exception));
                return false;
            }
        }
    }
}
