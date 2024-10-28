using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class LoanApplication
    {
        public bool Creditworthy { get; set; }
        public bool DocumentsValid { get; set; }
        public List<string> Results { get; } = new List<string>(); 
    }
}
