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
    public partial class MainWindow_OverlayA : UserControl
    {
        public MainWindow_OverlayA()
        {
            InitializeComponent();

            ImageA.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\Images\city.jpg"));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MainWindow_OverlayA clicked.");

        }


    }
}
