using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// </summary>
    public partial class ChildWindow_OvelayB : UserControl
    {
        private Timer aTimer;

        public ChildWindow_OvelayB()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ChildWindow_OvelayB clicked.");

        }

        private void Popup_Click(object sender, RoutedEventArgs e)
        {
            if (Singleton._ViewModelMainWindow.PupupVisibility == Visibility.Visible)
            {
                Singleton._ViewModelMainWindow.PupupVisibility = Visibility.Collapsed;
            }
            else
            {
                Singleton._ViewModelMainWindow.PupupVisibility = Visibility.Visible;
            }
        }
    }
}
