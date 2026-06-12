
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        
        private bool _selected;
        private string _timestamp;
        public Shape (Color color)
        {
            _x = 0;
            _y = 0;
            _color = color;
            _selected = false;
            _timestamp = DateTime.Now.ToString ("yyyy:MM:dd HH:mm:ss");
            
        }
        public Shape () : this (Color.Red)
        {
            
        }
        public float X 
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y 
        {
            get { return _y; }
            set { _y = value; }
        }

        

        public Color ShapeColor 
        {
            get { return _color; }
            set { _color = value; }
        }
        public virtual void Draw ()
        {
            
            if (_selected)
            {
                DrawOutline();
            }
        }
        public virtual bool IsAt(Point2D pt)
        {
            return false;
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
        public string TimeStamp
        {
            get {return _timestamp;}
            set {_timestamp = value;}
        }
        public virtual void DrawOutline()
        {
            
        }
        public virtual void SaveTo (StreamWriter writer)
        {
            writer.WriteColor(ShapeColor);
            writer.WriteLine(X);
            writer.WriteLine(Y);
            writer.WriteLine(TimeStamp);
        }
        public virtual void LoadFrom (StreamReader reader)
        {
            ShapeColor = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
            TimeStamp = reader.ReadLine();
        }

        public abstract void Scale(float factor);
    }
}