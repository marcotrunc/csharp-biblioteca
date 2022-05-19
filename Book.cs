using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Book : Documents
    {
        private int iNumPage;
        public int NumPage
        { get { return iNumPage; } set { iNumPage = value; } }

        public Book(string sCode, string sTitle, int iYears, string sCategory, int iNumPage) : base(sCode, sTitle, iYears, sCategory)
        {
            this.NumPage = iNumPage;       
        }
        public override string ToString()
        {
            return string.Format("{0}\nNumeroPagine:{1}", base.ToString(), this.NumPage);
        }

    }
}
