using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class ViewModelMainWindow : ViewModelBase
    {
        private string _TopButtonContent = "Popup";
        private double _X = 0;
        private double _Y = 0;
        private double _TriangleAngle = 0;
        private double _TriangleX = 0;
        private double _TriangleY = 0;
        private Visibility _PupupVisibility = Visibility.Hidden;
        private Visibility _OverlayB_Visibility = Visibility.Visible;


        public virtual string TopButtonContent
        {
            get 
            { 
                return _TopButtonContent;
            }
            set
            {
                if (_TopButtonContent != value)
                {
                    _TopButtonContent = value;
                    OnPropertyChanged(nameof(TopButtonContent));
                }
            }
        }

        

        public virtual double X
        {
            get { return _X; }
            set
            {
                if (_X != value)
                {
                    _X = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        public virtual double Y
        {
            get { return _Y; }
            set
            {
                if (_Y != value)
                {
                    _Y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        public virtual double TriangleX
        {
            get { return _TriangleX; }
            set
            {
                if (_TriangleX != value)
                {
                    _TriangleX = value;
                    OnPropertyChanged(nameof(TriangleX));
                }
            }
        }

        public virtual double TriangleY
        {
            get { return _TriangleY; }
            set
            {
                if (_TriangleY != value)
                {
                    _TriangleY = value;
                    OnPropertyChanged(nameof(TriangleY));
                }
            }
        }

        public virtual double TriangleAngle
        {
            get { return _TriangleAngle; }
            set
            {
                if (_TriangleAngle != value)
                {
                    _TriangleAngle = value;
                    OnPropertyChanged(nameof(TriangleAngle));
                }
            }
        }

        public virtual Visibility PupupVisibility
        {
            get { return _PupupVisibility; }
            set
            {
                if (_PupupVisibility != value)
                {
                    _PupupVisibility = value;
                    OnPropertyChanged(nameof(PupupVisibility));
                }
            }
        }

        public virtual Visibility OverlayB_Visibility
        {
            get { return _OverlayB_Visibility; }
            set
            {
                if (_OverlayB_Visibility != value)
                {
                    _OverlayB_Visibility = value;
                    OnPropertyChanged(nameof(OverlayB_Visibility));
                }
            }
        }

        
    }
}
