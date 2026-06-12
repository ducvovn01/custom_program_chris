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
                if (SplashKit.KeyTyped (KeyCode.TKey))
                {
                    int ShapeNums = SplashKit.Rnd(11) + 5;
                    for (int i = 0; i < ShapeNums; i++)
                    {

                        float RandX = SplashKit.Rnd(800);
                        float RandY = SplashKit.Rnd(600);
                        
                        Color randColor = SplashKit.RandomColor();
                        ShapeKind randomKind = (ShapeKind)SplashKit.Rnd(3);

                        Shape newShape1;


                        switch(randomKind)
                        {
                            case ShapeKind.Circle:
                                newShape1 = new MyCircle();
                                newShape1.X = RandX;
                                newShape1.Y = RandY; 
                                break;
                            case ShapeKind.Rectangle:
                                newShape1 = new MyRectangle();
                                newShape1.X = RandX;
                                newShape1.Y = RandY;
                                break;
                            case ShapeKind.Ellipse:
                                newShape1 = new MyEllipse();
                                newShape1.X = RandX;
                                newShape1.Y = RandY;
                                break;
                            default:
                                newShape1 = new MyLine();
                                newShape1.X = RandX;
                                newShape1.Y = RandY;
                                break;
                        }
                        

                            
                        

                    }
                }
                if (SplashKit.KeyTyped(KeyCode.AKey))
                {
                    float startX = SplashKit.MouseX();
                    float startY = SplashKit.MouseY();

                    Color letterColor = Color.Black;
                    myDrawing.AddShape(new MyLine(letterColor, startX, startY, startX, startY + 80));
                    myDrawing.AddShape(new MyLine(letterColor, startX, startY, startX + 50, startY));
                    myDrawing.AddShape(new MyLine(letterColor, startX, startY + 80, startX + 50, startY + 80));


                
                }
                if (SplashKit.KeyTyped(KeyCode.MKey))
                {
                    myDrawing.RandomizeAllColors();
                }

                if (SplashKit.KeyTyped(KeyCode.DKey))
                {
                    myDrawing.ScaleAllShapes(0.8f);
                }
                
                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
