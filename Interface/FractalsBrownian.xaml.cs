using System;
using System.Collections.Generic;
using System.Drawing;
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
using Color = System.Windows.Media.Color;

namespace Interface
{
    public partial class FractalsBrownian : Window
    {
        public FractalsBrownian()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FractalsPlasma p = new FractalsPlasma();
            p.Show();
            this.Close();
        }

        Line[] story = new Line[500];
        int count = 0;
        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            if (r1.IsChecked.Value == false && r2.IsChecked.Value == false)
            {
                rectWarning.Visibility = Visibility.Visible;
                warning.Visibility = Visibility.Visible;
                warning.Text = "Warning!\nYou have to choose the option\nof generating.";
            }
            else
            {
                if (txtBox.Text.Length < 1)
                {
                    rectWarning.Visibility = Visibility.Visible;
                    warning.Visibility = Visibility.Visible;
                    warning.Text = "Warning!\nYou have to fill in all of the fields.";
                }
                else
                {
                    rectWarning.Visibility = Visibility.Hidden;
                    warning.Visibility = Visibility.Hidden;
                    if (r1.IsChecked.Value == true)
                    {
                        int seed;
                        int length = 100;
                        seed = Convert.ToInt32(txtBox.Text);
                        Random rnd = new Random(seed);
                        Line line = new Line();
                        line.Stroke = new SolidColorBrush(Colors.Black);
                        line.StrokeThickness = 1;
                        line.StrokeStartLineCap = PenLineCap.Round;
                        line.StrokeEndLineCap = PenLineCap.Round;
                        System.Drawing.Point p1 = new System.Drawing.Point();
                        System.Drawing.Point p2 = new System.Drawing.Point();
                        p2.X = rnd.Next(0, length);
                        p2.Y = rnd.Next(0, length);
                        bool check = true;
                        count = 100;
                        for (int i = 0; i < 100; ++i)
                        {
                            check = true;
                            Line line1 = new Line();
                            line1.Stroke = new SolidColorBrush(Colors.Black);
                            line1.StrokeThickness = 1;
                            line1.StrokeStartLineCap = PenLineCap.Round;
                            line1.StrokeEndLineCap = PenLineCap.Round;
                            p1.X = p2.X;
                            p1.Y = p2.Y;
                            p2.X = rnd.Next(p1.X - length, p1.X + length);
                            p2.Y = rnd.Next(p1.Y - length, p1.Y + length);
                            while (check)
                            {
                                if (p2.X > 500 || p2.X < 0)
                                {
                                    p2.X = rnd.Next(p1.X - length, p1.X + length);
                                }
                                else
                                {
                                    check = false;
                                }
                            }
                            check = true;
                            while (check)
                            {
                                if (p2.Y > 500 || p2.Y < 0)
                                {
                                    p2.Y = rnd.Next(p1.Y - length, p1.Y + length);
                                }
                                else
                                {
                                    check = false;
                                }
                            }
                            line1.X1 = p1.X;
                            line1.Y1 = p1.Y;
                            line1.X2 = p2.X;
                            line1.Y2 = p2.Y;
                            story[i] = line1;
                            canvas2.Children.Add(line1);
                        }
                    }
                    else
                    {
                        if (txtBox_Copy.Text.Length < 1 || txtBox_Copy1.Text.Length < 1 || txtBox_Copy2.Text.Length<1)
                        {
                            rectWarning.Visibility = Visibility.Visible;
                            warning.Visibility = Visibility.Visible;
                            warning.Text = "Warning!\nYou have to fill in all of the fields.";
                        }
                        else
                        {
                            warning.Visibility = Visibility.Hidden;
                            rectWarning.Visibility = Visibility.Hidden;
                            int xc, yc;
                            xc = Convert.ToInt32(txtBox_Copy1.Text);
                            yc = Convert.ToInt32(txtBox_Copy2.Text);
                            int iterations = Convert.ToInt32(txtBox_Copy.Text);
                            int seed;
                            int length = 100;
                            seed = Convert.ToInt32(txtBox.Text);
                            Random rnd = new Random(seed);
                            Line line = new Line();
                            line.Stroke = new SolidColorBrush(Colors.Black);
                            line.StrokeThickness = 1;
                            line.StrokeStartLineCap = PenLineCap.Round;
                            line.StrokeEndLineCap = PenLineCap.Round;
                            System.Drawing.Point p1 = new System.Drawing.Point();
                            System.Drawing.Point p2 = new System.Drawing.Point();
                            p2.X = xc;
                            p2.Y = yc;
                            bool check = true;
                            count = iterations;
                            for (int i = 0; i < iterations; ++i)
                            {
                                check = true;
                                Line line1 = new Line();
                                line1.Stroke = new SolidColorBrush(Colors.Black);
                                line1.StrokeThickness = 1;
                                line1.StrokeStartLineCap = PenLineCap.Round;
                                line1.StrokeEndLineCap = PenLineCap.Round;
                                p1.X = p2.X;
                                p1.Y = p2.Y;
                                p2.X = rnd.Next(p1.X - length, p1.X + length);
                                p2.Y = rnd.Next(p1.Y - length, p1.Y + length);
                                while (check)
                                {
                                    if (p2.X > 500 || p2.X < 0)
                                    {
                                        p2.X = rnd.Next(p1.X - length, p1.X + length);
                                    }
                                    else
                                    {
                                        check = false;
                                    }
                                }
                                check = true;
                                while (check)
                                {
                                    if (p2.Y > 500 || p2.Y < 0)
                                    {
                                        p2.Y = rnd.Next(p1.Y - length, p1.Y + length);
                                    }
                                    else
                                    {
                                        check = false;
                                    }
                                }
                                line1.X1 = p1.X;
                                line1.Y1 = p1.Y;
                                line1.X2 = p2.X;
                                line1.Y2 = p2.Y;
                                story[i] = line1;
                                canvas2.Children.Add(line1);
                            }
                        }                        
                    }
                }
            }           
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            Rect bounds = VisualTreeHelper.GetDescendantBounds(canvas2);
            double dpi = 96d;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default);

            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(canvas2);
                dc.DrawRectangle(vb, null, new Rect(new System.Windows.Point(), bounds.Size));
            }

            rtb.Render(dv);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);
                ms.Close();

                System.IO.File.WriteAllBytes("F:\\FractalBrownian.png", ms.ToArray());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            canvas2.Children.Clear();
        }

        private void RadioButton_Checked_Custom(object sender, RoutedEventArgs e)
        {
            txt1.Visibility = Visibility.Visible;
            txt2.Visibility = Visibility.Visible;
            txtBox_Copy1.Visibility = Visibility.Visible;
            txtBox_Copy2.Visibility = Visibility.Visible;
            txtBox_Copy.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            txt1.Visibility = Visibility.Hidden;
            txt2.Visibility = Visibility.Hidden;
            txtBox_Copy1.Visibility = Visibility.Hidden;
            txtBox_Copy2.Visibility = Visibility.Hidden;
            txtBox_Copy.Visibility = Visibility.Hidden;

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            canvas2.Children.Remove(story[count - 1]);
            count--;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Line line = new Line();
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = 1;
            line.StrokeStartLineCap = PenLineCap.Round;
            line.StrokeEndLineCap = PenLineCap.Round;
            line.X1 = story[count - 1].X1;
            line.Y1 = story[count - 1].Y1;
            line.X2 = story[count - 1].X2;
            line.Y2 = story[count - 1].Y2;
            canvas2.Children.Add(line);
            count++;
        }
    }

}

