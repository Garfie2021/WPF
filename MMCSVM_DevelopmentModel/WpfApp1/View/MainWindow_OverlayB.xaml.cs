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
    public partial class MainWindow_OverlayB : UserControl
    {
        private List<Line> _LineList = new List<Line>();
        private List<Button> _RoundButtonList = new List<Button>();
        

        //public event UC_Button1Click();

        public MainWindow_OverlayB()
        {
            InitializeComponent();

            TestDataShow_Line();
            TestDataShow_RoundButton();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("MainWindow_OverlayB clicked.");
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{((Button)sender).Content} Round button clicked.");
        }


        private void TestDataShow_Line()
        {
            var color = new Color() { R = 119, G = 95, B = 255, A = 255 };
            var solidColorBrush = new SolidColorBrush(color);
            const int strokeThickness = 20;

            _LineList.Add(new Line() { Name = "Line2", X1 = 4000, X2 = 5000, Y1 =  500, Y2 = 1500, ToolTip = "2", 
                StrokeThickness = strokeThickness, Stroke = solidColorBrush });

            _LineList.Add(new Line() { Name = "Line3", X1 = 3000, X2 = 4000, Y1 =  500, Y2 =  500, ToolTip = "3", 
                StrokeThickness = strokeThickness, Stroke = solidColorBrush });

            _LineList.Add(new Line() { Name = "Line4", X1 = 2000, X2 = 3000, Y1 = 1500, Y2 =  500, ToolTip = "4", 
                StrokeThickness = strokeThickness, Stroke = solidColorBrush });

            foreach (var item in _LineList)
            {
                CanvasB.Children.Add(item);
            }
        }

        private void TestDataShow_RoundButton()
        {
            var controlTemplate = FindResource("RoundButtonA") as ControlTemplate;
            var b = this.Template.Resources["RoundButtonA"];

            _RoundButtonList.Add(new Button() { Name = "RoundButton1", Template = controlTemplate, Width = 176, Height = 176, Content = "1", 
                Visibility = Visibility.Visible, FontSize = 100, FontWeight = FontWeights.Medium });

            _RoundButtonList.Add(new Button() { Name = "RoundButton2", Template = controlTemplate, Width = 176, Height = 176, Content = "2", 
                Visibility = Visibility.Visible, FontSize = 100, FontWeight = FontWeights.Medium });

            _RoundButtonList[0].Click += Btn_Click;
            _RoundButtonList[1].Click += Btn_Click;

            var myRotateTransform = new RotateTransform();
            myRotateTransform.Angle = 0;
            myRotateTransform.CenterX = _RoundButtonList[0].Width / 2;
            myRotateTransform.CenterY = _RoundButtonList[0].Height / 2;
            var myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(myRotateTransform);

            foreach (var item in _RoundButtonList)
            {
                CanvasB.Children.Add(item);

                // レイヤ全体を回転させた分の回転角度を、ボタンオブジェクトの回転角度を戻すことで、文字列の表示だけ0度に戻す。
                item.RenderTransform = myTransformGroup;
            }

            Canvas.SetLeft(_RoundButtonList[0], 5000 - myRotateTransform.CenterX);
            Canvas.SetTop(_RoundButtonList[0],  1500 - myRotateTransform.CenterY);

            Canvas.SetLeft(_RoundButtonList[1], 2000 - myRotateTransform.CenterX);
            Canvas.SetTop(_RoundButtonList[1],  1500 - myRotateTransform.CenterY);


        }


    }
}
