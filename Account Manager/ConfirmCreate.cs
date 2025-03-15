using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Manager
{
    public partial class ConfirmCreate : Form
    {
        public ConfirmCreate(UsrCrtDta accountinfo)
        {
            InitializeComponent();
            FirstnameBox.Text = accountinfo.FirstName;
            LastNameBox.Text = accountinfo.LastName;
            PhnNmbrBox.Text = accountinfo.PhoneNumber;
            FaxNmbrBox.Text = accountinfo.FaxNumber;
            LocationBox.Text = accountinfo.Location;
            JobTitleBox.Text = accountinfo.JobTitle;
            DepartmentBox.Text = accountinfo.Department;
            MngrBox.Text = accountinfo.ManagerUPN;
            TempAccBox.Text = accountinfo.TemplateUPN;
            OUBox.Text = accountinfo.OU;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dash = new Dashboard();
            dash.Show();
            this.Close();
        }
    }
}
