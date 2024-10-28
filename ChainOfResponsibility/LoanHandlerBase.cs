using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public abstract class LoanHandlerBase : ILoanHandler
    {
        protected ILoanHandler _nextHandler;

        public void SetNext(ILoanHandler handler)
        {
            _nextHandler = handler;
        }

        public virtual void Handle(LoanApplication application)
        {
            _nextHandler?.Handle(application);
        }
    }
}
