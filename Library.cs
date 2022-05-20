using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace csharp_biblioteca
{
    public class ListUsers
    {
        private Dictionary<string, Users> dictUsers;

        public ListUsers()
        {
            this.dictUsers = new Dictionary<string, Users>();
        }

        public void AddUser(Users Users)
        {
            var Key = Users.FirstName.ToLower() + ";" + Users.LastName.ToLower() + ";" + Users.Email.ToLower();
            this.dictUsers.Add(Key, Users);      
        }
    }
    public class Library
    {
        private string sName;
        public string Name
        { get { return sName; } set { sName = value; } }

        private List<Documents> lDocuments;
        public List<Documents> Documents
        { get { return lDocuments; } set { lDocuments = value; } }

        private List<Loan> lLoans;
        public List<Loan> Loans
        { get { return lLoans; } set { lLoans = value; } }

        private ListUsers listUsers;
        public ListUsers ListUsers
        { get { return listUsers; } set { listUsers = value; } }

        private List<Users> Users { get; set; }
        public Library(string sName)
        {
            this.Name = sName;
            this.Documents = new List<Documents>();
            this.Loans = new List<Loan>();
            this.Users = new List<Users>();
            this.ListUsers = new ListUsers();
        }

        public List<Documents> SearchByCode(string sCode)
        {
            return this.Documents.Where(d => d.Code == sCode).ToList();
        }

        public List<Documents> SearchByTitle(string sTitle)
        {
            return this.Documents.Where(d => d.Title == sTitle).ToList();
        }

        public List<Loan> SearchLoanByNameUser(string sFirstName, string sLastName)
        {
            return this.Loans.Where(l => l.User.FirstName == sFirstName && l.User.LastName == sLastName).ToList();
        }

        public List<Loan> SearchLoanByCode(string sNumber)
        {
            return this.Loans.Where(l => l.LoanNumber == sNumber).ToList();
        }
        public void SaveUsers(string Path, Users User){
            StreamWriter sw = new StreamWriter(Path, true);
            string newString = User.FirstName + ";" + User.LastName + ";" + User.PhoneNumber + ";" + User.Email + ";" + User.Password + ";";
            sw.WriteLine(newString);
            sw.Close();    
        }
        public void RestoreUsers(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            //Continue to read until you reach end of file
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] stringUsers = line.Split(';');
                if (stringUsers.Length > 0)
                {
                    Users newUser = new Users(stringUsers);
                    line = sr.ReadLine();
                }
            }
            //close the file
            sr.Close();
        }
    }
}
