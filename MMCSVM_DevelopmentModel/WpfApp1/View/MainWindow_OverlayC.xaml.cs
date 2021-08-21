using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class MainWindow_OverlayC : UserControl
    {
        private Timer aTimer;


        public MainWindow_OverlayC()
        {
            InitializeComponent();

            CreatePointList();
            CreateAngleList();

            SetTimer();

            Resources["TriangleButton_Background"] = Colors.Orange;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MainWindow_OverlayC clicked.");
        }

        private void TriangleButton_Click(object sender, RoutedEventArgs e)
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

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Move();

        }


        private int _ColorChange = 1;
        private void ColorChange_Click(object sender, RoutedEventArgs e)
        {
            if (_ColorChange == 1)
            {
                Resources["TriangleButton_Background"] = Colors.White;
                _ColorChange++;
            }
            else if (_ColorChange == 2)
            {
                Resources["TriangleButton_Background"] = Colors.Green;
                _ColorChange++;
            }
            else if (_ColorChange == 3)
            {
                Resources["TriangleButton_Background"] = Colors.Orange;
                _ColorChange++;
            }
            else if (_ColorChange == 4)
            {
                Resources["TriangleButton_Background"] = Colors.Red;
                _ColorChange = 1;
            }
        }


        private void SetTimer()
        {
            aTimer = new Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }


        private bool first = true;
        private bool Reverse = false;
        private int PointCount = 0;
        private void Move()
        {
            try
            {
                if (PointList.Count <= PointCount)
                {
                    if (Reverse == false)
                    {
                        Reverse = true;
                        PointCount--;
                    }
                }
                else if (PointCount < 0)
                {
                    if (Reverse == true)
                    {
                        Reverse = false;
                        PointCount++;
                    }
                }


                Dispatcher.Invoke((Action)(() =>
                {
                    try
                    {
                        if (Reverse)
                        {
                            Singleton._ViewModelMainWindow.TriangleAngle = AngleList[PointCount] + 180;
                        }
                        else
                        {
                            Singleton._ViewModelMainWindow.TriangleAngle = AngleList[PointCount];
                        }

                        Canvas.SetLeft(TriangleButtonA, PointList[PointCount].X);
                        Canvas.SetTop(TriangleButtonA, PointList[PointCount].Y);

                        if (Reverse)
                        {
                            PointCount--;
                        }
                        else
                        {
                            PointCount++;
                        }

                        if (first)
                        {
                            TriangleButtonA.Visibility = Visibility.Visible;
                            first = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        var a = ex.Message;
                    }
                }));
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }

        private List<Point> PointList = new List<Point>();
        public void CreatePointList()
        {
            // Line2
            PointList.Add(new Point(5000, 1500));
            PointList.Add(new Point(4900, 1400));
            PointList.Add(new Point(4800, 1300));
            PointList.Add(new Point(4700, 1200));
            PointList.Add(new Point(4600, 1100));
            PointList.Add(new Point(4500, 1000));
            PointList.Add(new Point(4400,  900));
            PointList.Add(new Point(4300,  800));
            PointList.Add(new Point(4200,  700));
            PointList.Add(new Point(4100,  600));
            PointList.Add(new Point(4000,  500));

            // Line3
            PointList.Add(new Point(4000, 500));
            PointList.Add(new Point(3900, 500));
            PointList.Add(new Point(3800, 500));
            PointList.Add(new Point(3700, 500));
            PointList.Add(new Point(3600, 500));
            PointList.Add(new Point(3500, 500));
            PointList.Add(new Point(3400, 500));
            PointList.Add(new Point(3300, 500));
            PointList.Add(new Point(3200, 500));
            PointList.Add(new Point(3100, 500));
            PointList.Add(new Point(3000, 500));

            // Line4
            PointList.Add(new Point(3000,  500));
            PointList.Add(new Point(2900,  600));
            PointList.Add(new Point(2800,  700));
            PointList.Add(new Point(2700,  800));
            PointList.Add(new Point(2600,  900));
            PointList.Add(new Point(2500, 1000));
            PointList.Add(new Point(2400, 1100));
            PointList.Add(new Point(2300, 1200));
            PointList.Add(new Point(2200, 1300));
            PointList.Add(new Point(2100, 1400));
            PointList.Add(new Point(2000, 1500));

        }

        private List<double> AngleList = new List<double>();
        public void CreateAngleList()
        {
            // Line2
            AngleList.Add(-45);
            AngleList.Add(-45);
            AngleList.Add(-45);
            AngleList.Add(-45);
            AngleList.Add(-45);
            AngleList.Add(-45);
            AngleList.Add(-45);
            AngleList.Add(-45);
            AngleList.Add(-45);
            AngleList.Add(-45);
            AngleList.Add(-45);

            // Line3
            AngleList.Add(-90);
            AngleList.Add(-90);
            AngleList.Add(-90);
            AngleList.Add(-90);
            AngleList.Add(-90);
            AngleList.Add(-90);
            AngleList.Add(-90);
            AngleList.Add(-90);
            AngleList.Add(-90);
            AngleList.Add(-90);
            AngleList.Add(-90);

            // Line4
            AngleList.Add(-135);
            AngleList.Add(-135);
            AngleList.Add(-135);
            AngleList.Add(-135);
            AngleList.Add(-135);
            AngleList.Add(-135);
            AngleList.Add(-135);
            AngleList.Add(-135);
            AngleList.Add(-135);
            AngleList.Add(-135);
            AngleList.Add(-135);

        }

    }
}
