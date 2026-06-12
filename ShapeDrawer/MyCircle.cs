using System.IO;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyCircle: Shape
    {
        private int _radius;
        public MyCircle() : base()
        {
            _radius = 50;
        }
        public MyCircle (Color color, float x, float y, int radius)
        {
            X = x;
            Y = y;
            _radius = radius;
        }
        public int Radius
        {
            get {return _radius;}
            set {_radius = value;}
        }
        public override void Draw()
        {
            
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle (ShapeColor, X, Y, _radius);
        }
        public override bool IsAt(Point2D pt)
        {
            double dx = pt.X - X;
            double dy = pt.Y - Y;

            double distanceSquared = (dx * dx) + (dy * dy);
            double radiusSquared = _radius * _radius;

            return distanceSquared <= radiusSquared;
        }
        public override void DrawOutline()
        {
            SplashKit.DrawCircle (Color.Black, X , Y, _radius + 5);
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
        public override void Scale(float factor)
        {
            Radius = (int)(Radius * factor);
        }
    }
}