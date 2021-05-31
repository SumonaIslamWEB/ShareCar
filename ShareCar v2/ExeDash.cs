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
using ShareCar.Entity;
using ShareCar.Repository;

namespace ShareCar_v2
{
    public partial class ExeDash : MetroForm
    {
        ExeRepo exeRepo = new ExeRepo();
        loginEnt user = new loginEnt();
        
        public ExeDash()
        {
            InitializeComponent();
        }
        private void PopulatedGridView()
        {
            user.username = Login.username;
            this.ExeGrid.AutoGenerateColumns = false;
            this.ExeGrid.DataSource = exeRepo.GetAll().ToList();
            this.ExeGrid.ClearSelection();
            this.ExeGrid.Refresh();
        }

        private void ExeDash_Load(object sender, EventArgs e)
        {
            this.PopulatedGridView();
        }
    }
}
