using System.IO;
using SplashKitSDK;


namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        
        private Color _background;
        public Drawing (Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }
        public Drawing () : this (Color.White)
        {
            
        }
        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }
        public void AddShape (Shape s)
        {
            _shapes.Add(s);
        }
        public void RemoveShape (Shape s)
        {
            _shapes.Remove(s);
        }
        public void Draw()
        {
            SplashKit.ClearScreen (_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }
        public void SelectShapeAt (Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt)) {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }
        private List<Shape> _resulted;
        public List<Shape> SelectedShape
        {
            
            get
            {
                _resulted = new List<Shape>();
                foreach (Shape s in _shapes) {
                    if (s.Selected)
                    {
                        _resulted.Add(s);
                    }
                }
                return _resulted;
            }
        }
        public void Save (string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            
            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);

            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
            writer.Close();
        }
        public void Load (string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                
                int count;
                string kind;
                Background = reader.ReadColor();
                count = reader.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    Shape s;
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;

                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;

                        default:
                            throw new InvalidDataException ("Unknown shape kind: " +  kind);

                    }
                    s.LoadFrom(reader);
                    _shapes.Add(s);
                    Console.WriteLine(s.TimeStamp);
                }
            }
            
            finally 
            {
                reader.Close();
            }
        }

        public void RandomizeAllColors()
        {
            foreach (Shape s in _shapes)
            {
                // Gán thuộc tính Color bằng màu ngẫu nhiên chuẩn SplashKit
                s.ShapeColor = SplashKit.RandomColor(); 
            }
        }
        public void ScaleAllShapes(float factor)
        {
            foreach (Shape s in _shapes)
            {
                s.Scale(factor);
            }
        }
    }
}