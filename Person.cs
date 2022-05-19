using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Person
    {
        /* cognome, nome, email, password, recapito telefonico, */
        private string sLastName;
        public string LastName
        { get { return sLastName; } set { sLastName = value; } }
        private string sFirstName;
        public string FirstName
        { get { return sFirstName; } set { sFirstName = value; } }
        
        public Person(string sLastName, string sFirstName)
        {
            this.LastName = sLastName;
            this.FirstName = sFirstName;
        }
    }

    public class Auth : Person
    {
    public Auth (string sFirstName, string sLastName) : base (sFirstName, sLastName) { }
    }
}
