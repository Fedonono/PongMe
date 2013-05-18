using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBasicClasses.MVC
{
    public interface View
    {
        void refresh(Event e);
    }
}
