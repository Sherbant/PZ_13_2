using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capture
{
    public class TextHistory
    {
        private Stack<TextMemento> _mementos = new Stack<TextMemento>();

        public void SaveState(TextMemento memento)
        {
            _mementos.Push(memento);
        }

        public TextMemento? Undo()
        {
            return _mementos.Count > 0 ? _mementos.Pop() : null;
        }
    }

}
