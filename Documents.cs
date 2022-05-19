using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public enum Status { available, inLoan };
    public class Documents
    {
        private string sCode;
        public string Code { get { return sCode; } set { sCode = value; } }
        private string sTitle;
        public string Title { get { return sTitle; } set { sTitle = value; } }  
        private int iYears;
        public int Years { get { return iYears; } set { iYears = value; } }  
        private string sCategory;
        public string Category { get { return sCategory; } set { sCategory = value; } } 

        private Shelf shShelf;
        public Shelf Shelf
        { get { return shShelf; } set { shShelf = value; } }

        public Status Status { get; set; }
        
        
        private List<Auth> authors;
        public List<Auth> Authors
            { get { return authors; } set { authors = value; } }    
        public Documents(string sCode, string sTitle, int iYears, string sCategory)
        {
            this.Code = sCode;
            this.Title = sTitle;
            this.Years = iYears;
            this.Category = sCategory;
            this.Authors = new List<Auth>();
            this.Status = Status.available;
        }

        public override string ToString()
        {
            return string.Format("Codice:{0}\nTitolo:{1}\nSettore:{2}\nStato:{3}\nScaffale numero:{4}",
                this.Code,
                this.Title,
                this.Category,
                this.Status,
                this.Shelf.Number);
        }
        public void SetAvailable()
        {
            this.Status = Status.available;
        }

        public void setInLoan()
        {
            this.Status = Status.inLoan;
        }

    }
}
