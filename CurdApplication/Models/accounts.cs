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
        public string fName { get; set; }
        public string lName { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public string gender { get; set; }

        public accounts() 
        {

        }

        public accounts(string fName, string lName, string email, int phone, string gender)
        {
            this.fName = fName;
            this.lName = lName;
            this.email = email;
            this.phone = phone;
            this.gender = gender;
        }
    }
}
