using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Windows.Forms;
using ShareCar.Entity;
using ShareCar.Repository;

namespace ShareCar_v2
{
    public partial class AddCarRequest : MetroForm
    {
        CarRequestRepo requestRepo = new CarRequestRepo();
        
        public AddCarRequest()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CarRequest request = new CarRequest();
            request.time = TbTime.Text;
            request.reason = TbReason.Text;
            request.address = TbAddress.Text;
            loginEnt user = new loginEnt();


            if (TbTime.Text == "")
            {
                MessageBox.Show("Time required!", "Add Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TbReason.Text == "")
            {
                MessageBox.Show("Reason required!", "Add validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TbAddress.Text == "")
            {
                MessageBox.Show("Address required!", "Add validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                user.username = Login.username;
                bool b = requestRepo.AddRequest(request, user);
                

                if (b == true)
                {
                    MessageBox.Show("Request add Successful");
                    UserDash management = new UserDash();
                    management.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Request add Failed!", "Login Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
