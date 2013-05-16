using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBasicClasses.BasicClasses
{
    public class Event
    {
        private Model sender;

        public Event(Model s)
        {
            this.sender = s;
        }

        public Model getSender()
        {
            return sender;
        }
    }
}
