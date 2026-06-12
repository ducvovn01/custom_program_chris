
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyEllipse : Shape
    {
        private int _widthE;
        private int _heightE;

        public MyEllipse () : base()
        {
            _widthE = 60;
            _heightE = 80;
        }
        public MyEllipse (Color color, float x, float y, int widthE, int heightE) : base (color)
        {
            _widthE = widthE;
            _heightE = heightE;
        }

        public int WidthE
        {
            get {return _widthE;}
            set {_widthE = value;}
        }
        public int HeightE
        {
            get {return _heightE;}
            set {_heightE = value;}
        }

        public override void Draw ()
        {
            SplashKit.FillEllipse (ShapeColor, X, Y, WidthE, HeightE);
            if (Selected)
            {
                DrawOutline();
            }
        }
        public override bool IsAt (Point2D pt)
        {
            double cx = X + WidthE /2.0;
            double cy = Y + HeightE / 2.0;
            double a = WidthE / 2.0;
            double b = HeightE / 2.0;

            if (a <= 0 || b <= 0) 
            {
                return false;
            }

            double dx = (double)pt.X - cx;
            double dy = (double)pt.Y - cy;
            double result = (dx * dx) / (a * a) + (dy * dy) / (b * b);
            return result <= 1.0f;
        }
        public override void DrawOutline()
        {
            SplashKit.DrawEllipse (Color.Black, X - 5 , Y - 5, WidthE + 10, HeightE + 10);
        }
    }
}