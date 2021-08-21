using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;

namespace WpfApp1
{

    /// <summary>
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int _Width = 6400;
        private const int _Height = 3750;

        private const int _Width_OneTime = 1280;
        private const int _Height_OneTime = 750;

        private int _ExpansionRate = 1;     // 100%(1) ～500%(5)

        const string ComboBoxA_Item1 = "Child window";
        const string ComboBoxA_Item2 = "ChildWindow ShowDialog";
        const string ComboBoxA_Item3 = "ChildWindow Show";


        public MainWindow()
        {
            InitializeComponent();

            ComboBoxA.Items.Add(ComboBoxA_Item1);
            ComboBoxA.Items.Add(ComboBoxA_Item2);
            ComboBoxA.Items.Add(ComboBoxA_Item3);


            ViewboxOverlayA.DataContext = Singleton._ViewModelMainWindow;
            ViewboxOverlayB.DataContext = Singleton._ViewModelMainWindow;
            ViewboxOverlayC.DataContext = Singleton._ViewModelMainWindow;

            Resize(1, false);

            scrollViewer.ScrollToVerticalOffset(int.MaxValue);
            scrollViewer.ScrollToHorizo​​ntalOffset(int.MaxValue);
        }


        private void Canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                //Double Click時

                Maximam();
            }
        }

        Point scrollMousePoint = new Point();
        double _HorizontalOffset = 1;
        double _VerticalOffset = 1;
        private void scrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            scrollMousePoint = e.GetPosition(scrollViewer);
            _HorizontalOffset = scrollViewer.HorizontalOffset;
            _VerticalOffset = scrollViewer.VerticalOffset;
            scrollViewer.CaptureMouse();
        }

        private void scrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (scrollViewer.IsMouseCaptured)
            {
                scrollViewer.ScrollToHorizontalOffset(_HorizontalOffset + (scrollMousePoint.X - e.GetPosition(scrollViewer).X));
                scrollViewer.ScrollToVerticalOffset(_VerticalOffset + (scrollMousePoint.Y - e.GetPosition(scrollViewer).Y));
            }
        }

        private void scrollViewer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            scrollViewer.ReleaseMouseCapture();
        }

        private void scrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                Shrink();
            }
            else
            {
                Expansion();
            }
        }


        private void scrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            Singleton._ViewModelMainWindow.X = e.HorizontalOffset * -1;
            Singleton._ViewModelMainWindow.Y = e.VerticalOffset * -1;
        }


        private void MainWindowLayer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MainWindow clicked.");
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ComboBoxA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
            {
                return;
            }

            var content = e.AddedItems[0].ToString();

            var childWindow = new ChildWindow();

            switch (content)
            {
                case ComboBoxA_Item1:
                    break;

                case ComboBoxA_Item2:
                    ComboBoxA.SelectedIndex = 0;

                    childWindow.ShowDialog();

                    break;

                case ComboBoxA_Item3:
                    ComboBoxA.SelectedIndex = 0;

                    childWindow.Show();

                    break;
            }
        }



        private void Button1_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// 拡大
        /// </summary>
        private void Enlargement_Click(object sender, RoutedEventArgs e)
        {
            Expansion();
        }

        /// <summary>
        /// 縮小
        /// </summary>
        private void Reduction_Click(object sender, RoutedEventArgs e)
        {
            Shrink();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MainWindow clicked");

        }

        private void Minimam_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximam_Click(object sender, RoutedEventArgs e)
        {
            Maximam();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Expansion()
        {
            if (_ExpansionRate > 4)
            {
                return;
            }

            _ExpansionRate++;

            Resize(_ExpansionRate, true);
        }

        private void Shrink()
        {
            if (_ExpansionRate < 2)
            {
                return;
            }

            _ExpansionRate--;

            Resize(_ExpansionRate, true);
        }

        private void Resize(int expansionRate, bool animation)
        {
            TextBlockExpansionRate.Text = (expansionRate * 100).ToString() + "%";

            var width = _Width_OneTime * expansionRate;
            var height = _Height_OneTime * expansionRate;

            if (animation)
            {
                Animation(ViewboxOverlayA, new PropertyPath(WidthProperty), ViewboxOverlayA.Width, width);
                Animation(ViewboxOverlayA, new PropertyPath(HeightProperty), ViewboxOverlayA.Height, height);
                Animation(ViewboxOverlayB, new PropertyPath(WidthProperty), ViewboxOverlayB.Width, width);
                Animation(ViewboxOverlayB, new PropertyPath(HeightProperty), ViewboxOverlayB.Height, height);
                Animation(ViewboxOverlayC, new PropertyPath(WidthProperty), ViewboxOverlayC.Width, width);
                Animation(ViewboxOverlayC, new PropertyPath(HeightProperty), ViewboxOverlayC.Height, height);
            }
            else
            {
                ViewboxOverlayA.Width = width;
                ViewboxOverlayA.Height = height;
                ViewboxOverlayB.Width = width;
                ViewboxOverlayB.Height = height;
                ViewboxOverlayC.Width = width;
                ViewboxOverlayC.Height = height;
            }
        }

        private void Animation(FrameworkElement element, PropertyPath propertyPath, double from, double to)
        {
            var doubleAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromMilliseconds(500))
            };

            Storyboard.SetTargetName(doubleAnimation, element.Name);
            Storyboard.SetTargetProperty(doubleAnimation, propertyPath);

            var storyboard = new Storyboard();
            storyboard.Children.Add(doubleAnimation);

            storyboard.Begin(element);
        }

        private void Maximam()
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

    }
}