using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    /// Interaction logic for ColorsMain.xaml
    /// </summary>
    public partial class ColorsMain : Window
    {
        public ColorsMain()
        {
            InitializeComponent();
        }

        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.Show();
        }

        bool CMYK = false;
        bool HSV = false;
        private void Button_Click_CMYK(object sender, RoutedEventArgs e)
        {
            SolidColorBrush s1 = new SolidColorBrush();
            s1.Color = System.Windows.Media.Color.FromArgb(255, 28, 35, 43);
            hsvRect.Fill = s1;
            SolidColorBrush ss1 = new SolidColorBrush();
            ss1.Color = System.Windows.Media.Color.FromRgb(255, 255, 255);
            txtHsv.Foreground = ss1;

            SolidColorBrush s = new SolidColorBrush();
            s.Color = System.Windows.Media.Color.FromArgb(255, 243, 103, 70);
            cmykRect.Fill = s;
            SolidColorBrush ss = new SolidColorBrush();
            ss.Color = System.Windows.Media.Color.FromRgb(0,0,0);
            txtCmyk.Foreground = ss;
            CMYK = true;
            HSV = false;
        }


        private void Button_Click_HSV(object sender, RoutedEventArgs e)
        {
            SolidColorBrush s1 = new SolidColorBrush();
            s1.Color = System.Windows.Media.Color.FromArgb(255, 28, 35, 43);
            cmykRect.Fill = s1;
            SolidColorBrush ss1 = new SolidColorBrush();
            ss1.Color = System.Windows.Media.Color.FromRgb(255, 255, 255);
            txtCmyk.Foreground = ss1;

            SolidColorBrush s = new SolidColorBrush();
            s.Color = System.Windows.Media.Color.FromArgb(255, 243, 103, 70);
            hsvRect.Fill = s;
            SolidColorBrush ss = new SolidColorBrush();
            ss.Color = System.Windows.Media.Color.FromRgb(0, 0, 0);
            txtHsv.Foreground = ss;
            CMYK = false;
            HSV = true;
        }

        string file;

        private void Button_Click_Apply(object sender, RoutedEventArgs e)
        {
            if(CMYK)
            {
                ImageSource ims = image1.Source;
                BitmapImage bitmapImage = new BitmapImage();
                Bitmap bmp = (Bitmap)Bitmap.FromFile(file);
                double key = Convert.ToDouble(value1.Text);
                key = key / 100;
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        double cyan, magenta, yellow;
                        int red = bmp.GetPixel(x, y).R, blue = bmp.GetPixel(x, y).B, green = bmp.GetPixel(x, y).G;


                        double redc = red / 255.0;
                        double greenc = green / 255.0;
                        double bluec = blue / 255.0;

                        cyan = (1.0 - redc);
                        magenta = (1.0 - greenc);
                        yellow = (1.0 - bluec);


                        red = Convert.ToInt32(255 * (1 - cyan));
                        green = Convert.ToInt32(255 * (1 - magenta));
                        blue = Convert.ToInt32(255 * (1 - yellow) * key);

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(bmp.GetPixel(x, y).A, red, green, blue));
                    }
                }
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
                image1.Source = bitmapImage;
                canvas1.Children.Clear();
                Canvas.SetLeft(image1, 0);
                Canvas.SetTop(image1, 0);
                canvas1.Children.Add(image1);

            }
            if (HSV)
            {
                ImageSource ims = image1.Source;
                BitmapImage bitmapImage = new BitmapImage();
                Bitmap bmp = (Bitmap)Bitmap.FromFile(file);
                double key = Convert.ToDouble(value1.Text);
                key = key / 100;
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        int red = bmp.GetPixel(x, y).R, blue = bmp.GetPixel(x, y).B, green = bmp.GetPixel(x, y).G;


                        double redc = red / 255.0;
                        double greenc = green / 255.0;
                        double bluec = blue / 255.0;


                        double cmax = Math.Max(redc, Math.Max(greenc, bluec));
                        double cmin = Math.Min(redc, Math.Min(greenc, bluec)); 
                        double diff = cmax - cmin; 
                        double h = -1, s = -1;

                        if (cmax == cmin)
                            h = 0;

                        else if (cmax == redc)
                            h = (60 * (Math.Abs((greenc - bluec)) / diff % 6));

                        else if (cmax == greenc)
                            h = (60 * (Math.Abs((bluec - redc)) / diff + 2));

                        else if (cmax == bluec)
                            h = (60 * (Math.Abs((redc - greenc)) / diff + 4));

                        if (cmax == 0)
                            s = 0;
                        else
                            s = (diff / cmax);

                        double v = cmax;
                        double v1 = key;

                        double c = v * s;
                        double X = c * (1 - Math.Abs((h / 60) % 2 - 1));
                        double m = v - c;

                        double c1 = v1 * s;
                        double X1 = c1 * (1 - Math.Abs((h / 60) % 2 - 1));
                        double m1 = v1 - c1;

                        c = c * 100;
                        m = m * 100;
                        X = X * 100;

                        c1 = c1 * 100;
                        m1 = m1 * 100;
                        X1 = X1 * 100;

                        if (h < 60)
                        {
                            redc = (int)c;
                            greenc = (int)X;
                            bluec = 0;
                        }
                        else if (h >= 60 && h < 120)
                        {
                            redc = (int)X;
                            greenc = (int)c;
                            bluec = 0;
                        }
                        else if (h >= 120 && h < 180)
                        {
                            redc = 0;
                            greenc = (int)c;
                            bluec = (int)X1;
                        }
                        else if (h >= 180 && h < 240)
                        {
                            redc = 0;
                            greenc = (int)X;
                            bluec = (int)c;
                        }
                        else if (h >= 240 && h < 300)
                        {
                            redc = (int)X;
                            greenc = 0;
                            bluec = (int)c1;
                        }
                        else if (h >= 300 && h < 360)
                        {
                            redc = (int)c;
                            greenc = 0;
                            bluec = (int)X1;
                        }
                        blue = (Convert.ToInt32(bluec) + Convert.ToInt32(m1)) * 255;
                        blue = blue / 100;
                        red = (Convert.ToInt32(redc) + Convert.ToInt32(m)) * 255;
                        red = red / 100;
                        green = (Convert.ToInt32(greenc) + Convert.ToInt32(m)) * 255;
                        green = green / 100;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(bmp.GetPixel(x, y).A, red, green, blue));
                    }
                }
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
                image1.Source = bitmapImage;
                canvas1.Children.Clear();
                Canvas.SetLeft(image1, 0);
                Canvas.SetTop(image1, 0);
                canvas1.Children.Add(image1);
            }
        }

        bool opened = false;
        string path = "";

        private void Button_Click_Before(object sender, RoutedEventArgs e)
        {
            this.Button_Click_Open(this, null);
        }

        private void Button_Click_After(object sender, RoutedEventArgs e)
        {
            this.Button_Click_Apply(this,null);
        }

        private void Button_Click_Open(object sender, RoutedEventArgs e)
        {
            if (opened)
            {
                ImageSource ims = image1.Source;
                BitmapImage bitmapImage = new BitmapImage();
                Bitmap bmp = (Bitmap)Bitmap.FromFile(file);
                canvas1.Children.Clear();
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
                image1.Source = bitmapImage;
                Canvas.SetLeft(image1, 0);
                Canvas.SetTop(image1, 0);
                canvas1.Children.Add(image1);
            }
            else
            {
                Microsoft.Win32.OpenFileDialog dl1 = new Microsoft.Win32.OpenFileDialog();
                dl1.FileName = "image";
                dl1.DefaultExt = ".png";
                dl1.Filter = "Image documents (.png)|*.png";
                Nullable<bool> result = dl1.ShowDialog();


                if (result == true)
                {
                    string filename = dl1.FileName;
                    file = dl1.FileName;
                    ImageSource ims = image1.Source;
                    BitmapImage bitmapImage = new BitmapImage();
                    Bitmap bmp = (Bitmap)Bitmap.FromFile(file);
                    canvas1.Children.Clear();
                    MemoryStream ms = new MemoryStream();
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Position = 0;
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                    image1.Source = bitmapImage;
                    Canvas.SetLeft(image1, 0);
                    Canvas.SetTop(image1, 0);
                    canvas1.Children.Add(image1);
                    opened = true;
                }
            }
            
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

                System.IO.File.WriteAllBytes("F:\\ColorModelsResult.png", ms.ToArray());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
