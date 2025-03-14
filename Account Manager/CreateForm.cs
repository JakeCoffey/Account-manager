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
    public partial class CreateForm : Form
    {
        int page = 0;
        /*counter for "page" to keep the form consise and too avoid too many forms on each new "page" 
        the old labels and boxes will be made invisible and the new ones will be made visable in 
        their place*/

        // temp vars for name clean up process
        string FirstName ;
        string LastName;
        
        new UsrCrtDta accountData = new UsrCrtDta();
        public CreateForm()
        {
            InitializeComponent();
            if (page == 0)
            { 
                // sets visability for first page
                Backbutton.Visible = false;
                FirstLabel.Text = "First name";
                SecondLabel.Text = "Last Name";
                ThirdLabel.Text = "Job Title";
                FourthLabel.Text = @"Manager's UPN";
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dash = new Dashboard();
            dash.Show();
            this.Close();
        }
        private void NextStepButton_Click(object sender, EventArgs e)
        {//moves page forward
            page++;
            switch (page)
            {
                case 1:
                    //shows back button and hides unsed assets
                    Backbutton.Visible = true;
                    DepartmentLabel.Visible = false;
                    DeptDrop.Visible = false;
                    passgenbut.Visible = false;
                    Passwordbox.Visible = false;
                    PasswordLabel.Visible = false;
                    //sets new labels
                    FirstLabel.Text = "Template UPN";
                    SecondLabel.Text = "Phone number";
                    ThirdLabel.Text = "Fax number";
                    FourthLabel.Text = "Credentials";

                    //sets user inputs from last page
                    //Department = DeptDrop.SelectedItem.ToString();
                    FirstName = FirstBox.Text.Trim();
                    LastName = SecondBox.Text.Trim();
                    //Cleans up names
                        //converts input to char array
                        char[] firstNameChars = FirstName.ToCharArray();
                        char[] lastNameChars = LastName.ToCharArray();
                        //sets first index of char array to caps
                        firstNameChars[0] = char.ToUpper(firstNameChars[0]);
                        lastNameChars[0] = char.ToUpper(lastNameChars[0]);
                        //sets corrected array back to string
                    accountData.FirstName = new string(firstNameChars);
                    accountData.LastName = new string(lastNameChars);
                    accountData.JobTitle = ThirdBox.Text;
                    accountData.ManagerUPN = Fourthbox.Text;
                    //clears text from boxes
                    FirstBox.Text = null;
                    SecondBox.Text = null;
                    ThirdBox.Text = null;
                    Fourthbox.Text = null;
                    break;

                case 2:
                    //sets new labels
                    FirstLabel.Text = "Office Location";
                    SecondLabel.Text = "OU";
                    ThirdLabel.Visible = false;
                    FourthLabel.Visible=false;
                    //save user input
                    accountData.TemplateUPN = FirstBox.Text;
                    accountData.PhoneNumber = SecondBox.Text;
                    accountData.FaxNumber = ThirdBox.Text;
                    accountData.Creds = Fourthbox.Text;
                    //clears text from boxes 
                    FirstBox.Text = null;
                    SecondBox.Text = null;
                    ThirdBox.Text = null;
                    Fourthbox.Text = null;
                    //hides next button
                    NextStepButton.Visible = false;
                    break;

                case 3:
                    //save user input
                    accountData.Location = FirstBox.Text;
                    accountData.OU = SecondBox.Text;
      
                    break;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//moves page back
            page--;
            switch (page){
                case 0:
                   
                    break;
                case 1:

                    break;

                case 2:

                    break;
                
                case 3:

                    break;


                        
            
            }

        }
    }
}
