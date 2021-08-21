using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public partial class MainWindow_PupupA : UserControl
    {
        public MainWindow_PupupA()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Singleton._ViewModelMainWindow.PupupVisibility = Visibility.Collapsed;
        }

        private void LineVisibleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LineVisibleBtn.Content.ToString() == "ON")
            {
                Singleton._ViewModelMainWindow.OverlayB_Visibility = Visibility.Hidden;
                LineVisibleBtn.Content = "OFF";
            }
            else
            {
                Singleton._ViewModelMainWindow.OverlayB_Visibility = Visibility.Visible;
                LineVisibleBtn.Content = "ON";
            }
        }

    }
}
