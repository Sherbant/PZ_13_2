using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public interface ILoanHandler
    {
        void SetNext(ILoanHandler handler);
        void Handle(LoanApplication application);
    }
}
