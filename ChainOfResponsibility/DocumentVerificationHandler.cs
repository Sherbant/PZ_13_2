using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class DocumentVerificationHandler : LoanHandlerBase
    {
        public override void Handle(LoanApplication application)
        {
            if (application.DocumentsValid)
            {
                application.Results.Add("Документы проверены.");
                base.Handle(application);
            }
            else
            {
                application.Results.Add("Некорректные документы.");
            }
        }
    }
}
