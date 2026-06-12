using System.IO;

using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line,
            Ellipse
        }
        public static void Main()
        {
            Window window = new Window ("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;
            do
            {
                SplashKit.ProcessEvents();


                SplashKit.ClearScreen();
                if (SplashKit.MouseClicked (MouseButton.LeftButton))
                {
                    if (kindToAdd == ShapeKind.Line)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            MyLine newLine = new MyLine();
                            newLine.X = SplashKit.MouseX();
                            newLine.Y = SplashKit.MouseY() + (i*20);
                            newLine.EndX = newLine.X + 100;
                            newLine.EndY = newLine.Y + 100;

                            myDrawing.AddShape(newLine);
                        }
                    }
                    else
                    {
                        Shape newShape;
                        switch (kindToAdd)
                        {
                            case ShapeKind.Circle:
                                newShape = new MyCircle();
                                newShape.X = SplashKit.MouseX();
                                newShape.Y = SplashKit.MouseY();
                                break;
                            case ShapeKind.Ellipse:
                                newShape = new MyEllipse();
                                newShape.X = SplashKit.MouseX();
                                newShape.Y = SplashKit.MouseY();
                                break;
                            default:
                                newShape = new MyRectangle();
                                newShape.X = SplashKit.MouseX();
                                newShape.Y = SplashKit.MouseY();
                                break;
                        }
                        myDrawing.AddShape(newShape);
                    }
                    
                
                }
                if (SplashKit.KeyTyped (KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }
                if (SplashKit.MouseClicked (MouseButton.RightButton))
                {
                    myDrawing.SelectShapeAt (SplashKit.MousePosition());
                }
                if (SplashKit.KeyTyped (KeyCode.DeleteKey))
                {
                    foreach (Shape shape in myDrawing.SelectedShape)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }
                if (SplashKit.KeyTyped (KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped (KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped (KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                if (SplashKit.KeyTyped (KeyCode.EKey))
                {
                    kindToAdd = ShapeKind.Ellipse;
                }
                if (SplashKit.KeyTyped (KeyCode.SKey))
                {
                    myDrawing.Save("TestDrawing.txt");
                }
                if (SplashKit.KeyTyped (KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("Test2.txt");
                    } catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }

                }
                
                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
