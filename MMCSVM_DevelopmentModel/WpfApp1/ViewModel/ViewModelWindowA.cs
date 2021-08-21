using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class ViewModelChildWindow : ViewModelBase
    {
        private double _Test = 0;

        public virtual double Test
        {
            get { return _Test; }
            set
            {
                if (_Test != value)
                {
                    _Test = value;
                    OnPropertyChanged(nameof(Test));
                }
            }
        }

    }

}
