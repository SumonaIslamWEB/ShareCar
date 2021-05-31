using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using ShareCar.Repository;
using ShareCar.Entity;

namespace ShareCar_v2
{
    public partial class Login : MetroForm
    {
        //Point lastPoint;
        LoginRepo loginRepo = new LoginRepo();
        UserRepo userRepo = new UserRepo();
        ExeRepo exeRepo = new ExeRepo();
        
        CurrentUserRepo cUser = new CurrentUserRepo();
        public static string username;
        
        string a = "admin";
        string z = "user";
        string y = "exe";

        public Login()
        {
            InitializeComponent();
        }
     

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginEnt login = new loginEnt();
            login.username = tbUser.Text;
            login.password = tbPassword.Text;
            login.userTypeAdmin = a;
            login.userTypeUser = z;
            login.userTypeExe = y;


            CurrentUserValue currentUser = new CurrentUserValue();
            currentUser.currentUser = tbUser.Text;

            username = tbUser.Text;


            if (tbUser.Text == "")
            {
                MessageBox.Show("Username required!", "Login Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Password required!", "Login validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool b = loginRepo.LoginAdmin(login);
                bool c = userRepo.UserLogin(login);
                bool f = exeRepo.ExLogin(login);
                bool d = cUser.CurrentUserStore(currentUser);


                if (c == true && d == true)
                {
                    MessageBox.Show("Login Successful admin");
                    this.Hide();
                    DashboardAdmin management = new DashboardAdmin();
                    management.Show();
                    this.Hide();
                }
                else if (b == true && d == true)
                {
                    MessageBox.Show("Login Successful User");
                    this.Hide();
                    UserDash dashboard = new UserDash();
                    dashboard.Show();
                }
                else if (f == true && d == true)
                {
                    MessageBox.Show("Login Successful Exe");
                    this.Hide();
                    ExeDash exedashboard = new ExeDash();
                    exedashboard.Show();
                }
                else
                    MessageBox.Show("Login Failed!", "Login Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
