using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Loan
    {
        private string sLoanNumber;
        public string LoanNumber
        { get { return  sLoanNumber; } set { sLoanNumber = value; } }

        private DateTime datFrom;
        public DateTime From
            { get { return datFrom; } set { datFrom = value; } }

        private DateTime datTo;
        public DateTime To
            { get { return datTo; } set { datTo = value; } }

        private Users uUser;
        public Users User
            { get { return uUser; } set { uUser = value; } }

        private Documents docDocument;
        public Documents Document
        { get { return docDocument; } set { docDocument = value; } }

        public Loan(string sLoanNumber, DateTime datFrom, DateTime datTo, Users uUser, Documents docDocument)
        {
            this.LoanNumber = sLoanNumber;
            this.From = datFrom;
            this.To = datTo;
            this.User = uUser;
            this.Document = docDocument;
        }
        public override string ToString()
        {
            return string.Format("Numero:{0}\nDal:{1}\nAl:{2}\nStato:{3}\nUtente:\n{4}\nDocumento:\n{5}",
                this.LoanNumber,
                this.From,
                this.To,
                this.Document.Status,
                this.User.ToString(),
                this.Document.ToString()); 
        }
    }
}
