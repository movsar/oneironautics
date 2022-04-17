using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Models
{
    internal class WindowActions
    {
        public Action CLose { get; }

        public WindowActions(Action closeAction) { 
            CLose = closeAction;
        }
    }
}
