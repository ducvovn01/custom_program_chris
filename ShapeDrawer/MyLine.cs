
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        
        private float _endX;
        private float _endY;

        public MyLine() : base ()
        {
            
        }
        public MyLine (Color color, float startX, float startY, float endX, float endY) : base (color)
        {
            
            
            _endX = endX;
            _endY = endY;
        }

        public float EndX {
            get {return _endX;}
            set {_endX = value;}
        }
        public float EndY {
            get {return _endY;}
            set {_endY = value;}
        }

        public override void Draw()
        {
            SplashKit.DrawLine(Color.Red, X, Y, EndX, EndY);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Red, X, Y, 5);
            SplashKit.FillCircle(Color.Red, _endX, _endY, 5);
        }
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY));
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }

        public float FEndX { get; set; }
        public float FEndY { get; set; }

        public override void Scale(float factor)
        {
            // Tính toán khoảng cách mới dựa trên tỉ lệ factor
            EndX = X + (FEndX - X) * factor;
            EndY = Y + (FEndY - Y) * factor;
        }
    }
}