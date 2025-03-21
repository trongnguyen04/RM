using RM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RM
{
    public partial class frMain : Form
    {
        public frMain()
        {
            InitializeComponent();
        }
        
        //Methord to add controls in Main form
        public void AddControls(Form f)
        {
            this.centerPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            this.centerPanel.Controls.Add(f);
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frMain_Load(object sender, EventArgs e)
        {
            lbUser.Text = MainClass.USER;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControls(new frmCategoryView());

        }
    }
}
