using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Users : Person
    {
        private string sEmail;
        public string Email
        { get { return sEmail; } set { sEmail = value; } }

        private string sPassword;
        public string Password
        { get { return sPassword; } set { sPassword = value; } }

        private string sPhoneNumber;
        public string PhoneNumber
        { get { return sPhoneNumber; } set { sPhoneNumber = value; } }

        public Users(string sLastName, string sFirstName, string sPhoneNumber, string sEmail, string sPassword) : base(sLastName, sFirstName)
        {
            this.Email = sEmail;
            this.sPassword = sPassword;
            this.PhoneNumber = sPhoneNumber;
        }
        public Users(string[] arr) : base(arr[1], arr[0])
        {
            base.FirstName = arr[0];
            base.LastName = arr[1];
            this.Email = arr[3];
            this.sPassword = arr[4];
            this.PhoneNumber = arr[2];
        }
        
        public override string ToString()
        {
            return string.Format("Nome:{0}\nCognome:{1}\nTelefono:{2}\nEmail:{3}\nPassword:{4}",
                base.FirstName,
                base.LastName,
                this.PhoneNumber,
                this.Email,
                this.Password);
        }
    }
}
