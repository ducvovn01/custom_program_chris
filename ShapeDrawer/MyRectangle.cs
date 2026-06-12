using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle: Shape
    {
        private int _width;
        private int _height;
        public MyRectangle() : base()
        {
            _width = 50;
            _height = 50;
        }
        public MyRectangle(Color color, float x, float y, int width, int height) : base (color)
        {
            _width = width;
            _height = height;
            
        }
        public int Width 
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height 
        {
            get { return _height; }
            set { _height = value; }
        }
        public override void Draw()
        {
            SplashKit.FillRectangle (ShapeColor, X, Y, Width, Height);
            if (Selected)
            {
                DrawOutline();
            }
        }
        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= X) && (pt.X <= X + Width) && (pt.Y >= Y) && (pt.Y <= Y + Height);
        }
        public override void DrawOutline()
        {
            SplashKit.DrawRectangle (Color.Black, X - 5 , Y - 5, Width + 10, Height + 10);
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
        public override void Scale(float factor)
        {
            Width = (int)(Width * factor);
            Height = (int)(Height * factor);
        }
    }
} 