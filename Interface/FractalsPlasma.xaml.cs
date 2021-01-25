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
using System.Windows.Shapes;

namespace Interface
{
    /// <summary>
    /// Interaction logic for FractalsPlasma.xaml
    /// </summary>
    public partial class FractalsPlasma : Window
    {
        public FractalsPlasma()
        {
            InitializeComponent();
        }
        bool clearness = true;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FractalsBrownian m = new FractalsBrownian();
            m.Show();
            this.Close();
        }
         public Color ComputeColor(double c)
        {
            double Red = 0;
            double Green = 0;
            double Blue = 0;
            if (c < 0.5)
            {
                Red = c * 2;
            }
            else
            {
                Red = (1.0 - c) * 2;
            }

            if (c >= 0.3 && c < 0.8)
            {
                Green = (c - 0.3) * 2;
            }
            else if (c < 0.3)
            {
                Green = (0.3 - c) * 2;
            }
            else
            {
                Green = (1.3 - c) * 2;
            }

            if (c >= 0.5)
            {
                Blue = (c - 0.5) * 2;
            }
            else
            {
                Blue = (0.5 - c) * 2;
            }

            Red = Math.Round(Red * 255, 0);
            Green = Math.Round(Green * 255, 0);
            Blue = Math.Round(Blue * 255, 0); 
            return Color.FromArgb(255, Convert.ToByte(Red), Convert.ToByte(Green), Convert.ToByte(Blue));
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            text.Visibility = Visibility.Visible;
            txtBox_Copy1.Visibility = Visibility.Visible;
            txtBox_Copy2.Visibility = Visibility.Visible;
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            if(r1.IsChecked.Value == true|| r2.IsChecked.Value == true)
            {
                if(txtBox.Text.Length < 1)
                {
                    rectWarning.Visibility = Visibility.Visible;
                    warning.Text = "Warning!\nYou have to fill in all of the fields.";
                }
                else
                {
                    if(r1.IsChecked.Value == true)
                    {
                        text.Visibility = Visibility.Hidden;
                        txtBox_Copy1.Visibility = Visibility.Hidden;
                        txtBox_Copy2.Visibility = Visibility.Hidden;

                        int seed;
                        seed = Convert.ToInt32(txtBox.Text);
                        Plazma p = new Plazma();
                        p.setRnd(seed);
                        double[,] points = new double[100 + 1, 100 + 1];
                        points = p.Generate(100, 100, 1);
                        Viewbox v = new Viewbox();
                        Rect rec = new Rect();
                        for (int x = 0; x < 100; x++)
                        {
                            for (int y = 0; y < 100; y++)
                            {
                                Path myPath1 = new Path();
                                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                                GeometryGroup myGeometryGroup1 = new GeometryGroup();
                                RectangleGeometry myRectangleGeometry1 = new RectangleGeometry();
                                mySolidColorBrush.Color = ComputeColor(points[x, y]);
                                myPath1.Stroke = mySolidColorBrush;
                                myPath1.StrokeThickness = 5;
                                rec.Width = 15;
                                rec.Height = 15;
                                rec.X = x * 5;
                                rec.Y = y * 5;
                                myRectangleGeometry1.Rect = rec;
                                myGeometryGroup1.Children.Add(myRectangleGeometry1);
                                myPath1.Data = myGeometryGroup1;
                                Canvas.SetLeft(myPath1, canvas1.Width / 8);
                                Canvas.SetTop(myPath1, canvas1.Height / 8);
                                canvas1.Children.Add(myPath1);
                            }
                        }
                    }
                    else
                    {
                        if(txtBox_Copy1.Text.Length<1||txtBox_Copy2.Text.Length<1)
                        {
                            rectWarning.Visibility = Visibility.Visible;
                            warning.Text = "Warning!\nYou have to choose the option\n of generating.";
                        }
                        else
                        {
                            int xc, yc;
                            xc = Convert.ToInt32(txtBox_Copy1.Text);
                            yc = Convert.ToInt32(txtBox_Copy2.Text);
                            if(xc > 50)
                            {
                                xc = 50;
                            }
                            if (yc > 50)
                            {
                                yc = 50;
                            }
                            if (xc < -50)
                            {
                                xc = -50;
                            }
                            if (yc < -50)
                            {
                                yc = -50;
                            }
                            int seed;
                            seed = Convert.ToInt32(txtBox.Text);
                            Plazma p = new Plazma();
                            p.setRnd(seed);
                            double[,] points = new double[100 + 1, 100 + 1];
                            points = p.Generate(100, 100, 1);
                            Viewbox v = new Viewbox();
                            Rect rec = new Rect();
                            for (int x = 0; x < 100; x++)
                            {
                                for (int y = 0; y < 100; y++)
                                {
                                    Path myPath1 = new Path();
                                    SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                                    GeometryGroup myGeometryGroup1 = new GeometryGroup();
                                    RectangleGeometry myRectangleGeometry1 = new RectangleGeometry();
                                    mySolidColorBrush.Color = ComputeColor(points[x, y]);
                                    myPath1.Stroke = mySolidColorBrush;
                                    myPath1.StrokeThickness = 5;
                                    rec.Width = 15;
                                    rec.Height = 15;
                                    rec.X = x * 5;
                                    rec.Y = y * 5;
                                    myRectangleGeometry1.Rect = rec;
                                    myGeometryGroup1.Children.Add(myRectangleGeometry1);
                                    myPath1.Data = myGeometryGroup1;
                                    Canvas.SetLeft(myPath1, canvas1.Width / 8+xc);
                                    Canvas.SetTop(myPath1, canvas1.Height / 8-yc);
                                    canvas1.Children.Add(myPath1);
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                rectWarning.Visibility = Visibility.Visible;
                warning.Text = "Warning!\nYou have to choose the option\n of generating.";
            }

        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            Rect bounds = VisualTreeHelper.GetDescendantBounds(canvas1);
            double dpi = 96d;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default);

            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(canvas1);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }

            rtb.Render(dv);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);
                ms.Close();

                System.IO.File.WriteAllBytes("F:\\FractalPlasma.png", ms.ToArray());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    class Plazma
    {
        Random rnd;
        public void setRnd(int seed)
        {
            rnd = new Random(seed);
        }
        double gRoughness;
        double gBigSize;
        public double[,] Generate(int iWidth, int iHeight, double iRoughness)
        {
            double c1 = 0, c2 = 0, c3 = 0, c4 = 0;
            double[,] points = new double[iWidth + 1, iHeight + 1];

            c1 = rnd.NextDouble();
            c2 = rnd.NextDouble();
            c3 = rnd.NextDouble();
            c4 = rnd.NextDouble();
            gRoughness = iRoughness;
            gBigSize = iWidth + iHeight;
            DivideGrid(ref points, 0, 0, iWidth, iHeight, c1, c2, c3, c4);
            return points;
        }
        public void DivideGrid(ref double[,] points, double x, double y, double width, double height, double c1, double c2, double c3, double c4)
        {
            double Edge1, Edge2, Edge3, Edge4, Middle;

            double newWidth = Math.Floor(width / 2);
            double newHeight = Math.Floor(height / 2);

            if (width > 1 || height > 1)
            {
                Middle = ((c1 + c2 + c3 + c4) / 4) + Displace(newWidth + newHeight);    
                Edge1 = ((c1 + c2) / 2);    
                Edge2 = ((c2 + c3) / 2);
                Edge3 = ((c3 + c4) / 2);
                Edge4 = ((c4 + c1) / 2);

                Middle = Rectify(Middle);
                Edge1 = Rectify(Edge1);
                Edge2 = Rectify(Edge2);
                Edge3 = Rectify(Edge3);
                Edge4 = Rectify(Edge4);

                DivideGrid(ref points, x, y, newWidth, newHeight, c1, Edge1, Middle, Edge4);
                DivideGrid(ref points, x + newWidth, y, width - newWidth, newHeight, Edge1, c2, Edge2, Middle);
                DivideGrid(ref points, x + newWidth, y + newHeight, width - newWidth, height - newHeight, Middle, Edge2, c3, Edge3);
                DivideGrid(ref points, x, y + newHeight, newWidth, height - newHeight, Edge4, Middle, Edge3, c4);
            }
            else   
            {
                double c = (c1 + c2 + c3 + c4) / 4;

                points[(int)(x), (int)(y)] = c;
                if (width == 2)
                {
                    points[(int)(x + 1), (int)(y)] = c;
                }
                if (height == 2)
                {
                    points[(int)(x), (int)(y + 1)] = c;
                }
                if ((width == 2) && (height == 2))
                {
                    points[(int)(x + 1), (int)(y + 1)] = c;
                }
            }
        }
        public double Rectify(double iNum)
        {
            if (iNum < 0)
            {
                iNum = 0;
            }
            else if (iNum > 1.0)
            {
                iNum = 1.0;
            }
            return iNum;
        }
        private double Displace(double SmallSize)
        {

            double Max = SmallSize / gBigSize * gRoughness;
            return (rnd.NextDouble() - 0.5) * Max;
        }
    }
    static class Blender
    {
        public static System.Windows.Media.Color Blend(this System.Drawing.Color color, Color backColor, double amount)
        {
            byte r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            byte g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            byte b = (byte)((color.B * amount) + backColor.B * (1 - amount));
            return System.Windows.Media.Color.FromArgb(255, r, g, b);
        }
    }
}
