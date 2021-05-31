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
    public partial class UserDash : MetroForm
    {
        CarRequestRepo RequestRepo = new CarRequestRepo();
        loginEnt user = new loginEnt();
        public UserDash()
        {
            InitializeComponent();
        }
        

        private void PopulatedGridView()
        {
            user.username = Login.username;
            this.userGrid.AutoGenerateColumns = false;
            this.userGrid.DataSource = RequestRepo.GetAll(user).ToList();
            this.userGrid.ClearSelection();
            this.userGrid.Refresh();
        }

        private void UserDash_Load(object sender, EventArgs e)
        {
            this.PopulatedGridView();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            AddCarRequest addCarRequest = new AddCarRequest();
            this.Close();
            addCarRequest.Show();
        }
    }
}
