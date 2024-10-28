using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capture
{
    public class TextMemento
    {
        public string TextState { get; private set; }

        public TextMemento(string textState)
        {
            TextState = textState;
        }
    }

}
