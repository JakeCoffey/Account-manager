using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

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

        Font normalFont = new Font("Roboto", 11 ,FontStyle.Bold);
        Font smallFont = new Font("Roboto", 9, FontStyle.Bold);

        UsrCrtDta accountData = new UsrCrtDta();
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
                    FirstLabel.Font = smallFont;
                    SecondLabel.Text = "Phone number";
                    SecondLabel.Font = smallFont;
                    ThirdLabel.Text = "Fax number";
                    FourthLabel.Text = "Office Location";


                    //sets user inputs from last page
                    if (DeptDrop.SelectedItem != null) {
                        accountData.Department = DeptDrop.SelectedItem.ToString();
                    }

                    FirstName = FirstBox.Text.Trim();
                    LastName = SecondBox.Text.Trim();
                    if (FirstName !="" && LastName !="")
                    {
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
                    }
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
                    FirstLabel.Text = "OU";
                    FirstLabel.Font = normalFont;
                    SecondLabel.Visible = false;
                    ThirdLabel.Visible = false;
                    FourthLabel.Visible=false;
                    SecondBox.Visible = false;
                    ThirdBox.Visible = false;
                    Fourthbox.Visible = false;
                    //save user input
                    accountData.TemplateUPN = FirstBox.Text;
                    accountData.PhoneNumber = SecondBox.Text;
                    accountData.FaxNumber = ThirdBox.Text;
                    accountData.Location = Fourthbox.Text;
                    //clears text from boxes 
                    FirstBox.Text = null;
                    SecondBox.Text = null;
                    ThirdBox.Text = null;
                    Fourthbox.Text = null;
                    //hides next button
                   
                    break;

                case 3:
                    //save user input
                    accountData.OU = FirstBox.Text;
                    ConfirmCreate confirmscreen = new ConfirmCreate(accountData);
                    confirmscreen.Show();
                    this.Close();
      
                    break;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//moves page back
            page--;
            switch (page){
                case 0:
                    //sets labels
                    Backbutton.Visible = false;
                    FirstLabel.Text = "First name";
                    SecondLabel.Text = "Last Name";
                    ThirdLabel.Text = "Job Title";
                    FourthLabel.Text = @"Manager's UPN";
                    FirstLabel.Font = normalFont;
                    SecondLabel.Font = normalFont;

                    DepartmentLabel.Visible = true;
                    DeptDrop.Visible = true;
                    passgenbut.Visible = true;
                    Passwordbox.Visible = true;
                    PasswordLabel.Visible = true;
                    //saves user input
                    accountData.TemplateUPN = FirstBox.Text;
                    accountData.PhoneNumber = SecondBox.Text;
                    accountData.FaxNumber = ThirdBox.Text;
                    accountData.Location = Fourthbox.Text;
                    //fills previous user fields
                    FirstBox.Text = accountData.FirstName;
                    SecondBox.Text = accountData.LastName;
                    ThirdBox.Text = accountData.JobTitle;
                    Fourthbox.Text = accountData.ManagerUPN;
                    DeptDrop.SelectedItem = accountData.Department;



                    break;
                case 1:
                    //sets labels and re shows UI
                    FirstLabel.Text = "Template UPN";
                    SecondLabel.Text = "Phone number";
                    ThirdLabel.Text = "Fax number";
                    FourthLabel.Text = "Office Location";
                    FirstLabel.Font = smallFont;
                    SecondLabel.Font = smallFont;

                    SecondBox.Visible = true;
                    ThirdBox.Visible = true;
                    Fourthbox.Visible = true;
                    SecondLabel.Visible = true;
                    ThirdLabel.Visible = true;
                    FourthLabel.Visible = true;


                    //saves input
                    accountData.OU = FirstBox.Text;
                    //clearstext boxes
                    FirstBox.Text = null;
                    SecondBox.Text = null;
                    ThirdBox.Text = null;
                    Fourthbox.Text = null;
                    

                    break;

                case 2:

                    break;
                
                case 3:

                    break;


                        
            
            }

        }
       
    }
}
