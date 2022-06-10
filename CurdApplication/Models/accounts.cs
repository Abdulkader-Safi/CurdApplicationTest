using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurdApplication.Models
{
    //(@fName, @lName, @email, @phone, @gender)"


    
    public class accounts
    {
        public int ID { get; set; }
        public string fristName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int phoneNumber { get; set; }
        public string gender { get; set; }

        public accounts() 
        {

        }

        public accounts(string fName, string lName, string email, int phone, string gender)
        {
            this.fristName = fName;
            this.lastName = lName;
            this.email = email;
            this.phoneNumber = phone;
            this.gender = gender;
        }
    }
}
