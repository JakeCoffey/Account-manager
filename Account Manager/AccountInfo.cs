using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Manager
{
    public class UsrCrtDta//data used for Account Creation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string ManagerUPN { get; set; }
        public string TemplateUPN { get; set; }
        public string OU { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string FaxNumber { get; set; }



    
    }
    public class UserOFData//dats used for offboarding 
    {
        public string LoginName { get; set; }
    }
    public class NameChngeData
    {

    }
}
