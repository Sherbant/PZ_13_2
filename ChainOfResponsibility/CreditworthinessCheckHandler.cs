using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class CreditworthinessCheckHandler : LoanHandlerBase
    {
        public override void Handle(LoanApplication application)
        {
            if (application.Creditworthy)
            {
                application.Results.Add("Платежеспособность подтверждена.");
                base.Handle(application);
            }
            else
            {
                application.Results.Add("Платежеспособность не подтверждена.");
            }
        }
    }
}
