using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Dvd : Documents
    {
        private int iDuration;
        public int Duration
            { get { return iDuration; } set { iDuration = value; } }

        public Dvd(string sCode, string sTitle, int iYears, string sCategory, int iDuration) : base(sCode, sTitle, iYears, sCategory)
        {
            this.Duration = iDuration;
        }
        public override string ToString()
        {
            return string.Format("{0}\nDurata:{1}", base.ToString(), this.Duration);
        }
    }
}
