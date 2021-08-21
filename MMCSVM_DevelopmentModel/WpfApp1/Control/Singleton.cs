using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public static class Singleton
    {
        public static ViewModelMainWindow _ViewModelMainWindow = new ViewModelMainWindow();
        public static ViewModelChildWindow _ViewModelChildWindow = new ViewModelChildWindow();

        static Singleton()
        {
            _ViewModelMainWindow = new ViewModelMainWindow();
            _ViewModelChildWindow = new ViewModelChildWindow();

        }

    }
}
