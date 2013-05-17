using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;

namespace GameBasicClasses.BasicClasses
{
    public interface View
    {
        void refresh(Event e);
    }
}
