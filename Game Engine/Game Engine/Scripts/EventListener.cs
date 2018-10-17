using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine
{
    class EventListener
    {
        private List<Action> list;
        public EventListener()
        {
            list = new List<Action>();
        }
        public void AddEvent(Action func)
        {
            list.Add(() => func());
        }
        public void RunEvents()
        {
            foreach (var Event in list)
            {
                Event.Invoke();
            }
        }
    }
}
