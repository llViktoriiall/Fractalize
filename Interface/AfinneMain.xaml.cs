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
    /// Interaction logic for AfinneMain.xaml
    /// </summary>
    public partial class AfinneMain : Window
    {
        public AfinneMain()
        {
            InitializeComponent();
        }


        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.Show();
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            canvas.Children.Add(l1);
            canvas.Children.Add(l2);
            canvas.Children.Add(l3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x1, x2, x3, y1, y2, y3;
            x1 = Convert.ToInt32(X1.Text) * 10;
            y1 = Convert.ToInt32(Y1.Text) * 10;
            x2 = Convert.ToInt32(X2.Text) * 10;
            y2 = Convert.ToInt32(Y2.Text) * 10;
            x3 = Convert.ToInt32(X3.Text) * 10;
            y3 = Convert.ToInt32(Y3.Text) * 10;
            double[,] matrixChanged = new double[3, 2];
            Polygon triangle = new Polygon();
            Point p1 = new Point(250+x1, 250-y1);
            Point p2 = new Point(250+x2, 250-y2);
            Point p3 = new Point(250+x3, 250-y3);
            triangle.Points.Add(p1);
            triangle.Points.Add(p2);
            triangle.Points.Add(p3);
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Colors.Coral;
            triangle.Stroke = color;
            triangle.StrokeThickness = 1;
            canvas.Children.Add(triangle);


            double[,] matrixDefault = new double[3, 3];
            matrixDefault[0, 0] = p1.X - 250;
            matrixDefault[0, 1] = (p1.Y -250) * (-1.0);
            matrixDefault[0, 2] = 1;
            matrixDefault[1, 0] = p2.X - 250;
            matrixDefault[1, 1] = (p2.Y - 250) * (-1.0);
            matrixDefault[1, 2] = 1;
            matrixDefault[2, 0] = p3.X - 250;
            matrixDefault[2, 1] = (p3.Y - 250)*(-1.0);
            matrixDefault[2, 2] = 1;

            //MOVEMENT TRANSFORMATION

            int t = Convert.ToInt32(value1.Text)*2;
            double[,] matrixMovement = new double[3,3];
            matrixMovement[0, 0] = 1;
            matrixMovement[0, 1] = 0;
            matrixMovement[0, 2] = 0;
            matrixMovement[1, 0] = 0;
            matrixMovement[1, 1] = 1;
            matrixMovement[1, 2] = 0;
            matrixMovement[2, 0] = t;
            matrixMovement[2, 1] = t;
            matrixMovement[2, 2] = 1;

            double[,] matrixNew = new double[3, 3];
            matrixNew[0, 0] = matrixDefault[0, 0] * matrixMovement[0, 0] + matrixDefault[0, 1] * matrixMovement[1, 0] + matrixDefault[0, 2] * matrixMovement[2, 0];
            matrixNew[0, 1] = matrixDefault[0, 0] * matrixMovement[0, 1] + matrixDefault[0, 1] * matrixMovement[1, 1] + matrixDefault[0, 2] * matrixMovement[2, 1];
            matrixNew[0, 2] = matrixDefault[0, 0] * matrixMovement[0, 2] + matrixDefault[0, 1] * matrixMovement[1, 2] + matrixDefault[0, 2] * matrixMovement[2, 2]; 
            matrixNew[1, 0] = matrixDefault[1, 0] * matrixMovement[0, 0] + matrixDefault[1, 1] * matrixMovement[1, 0] + matrixDefault[1, 2] * matrixMovement[2, 0];
            matrixNew[1, 1] = matrixDefault[1, 0] * matrixMovement[0, 1] + matrixDefault[1, 1] * matrixMovement[1, 1] + matrixDefault[1, 2] * matrixMovement[2, 1];
            matrixNew[1, 2] = matrixDefault[1, 0] * matrixMovement[0, 2] + matrixDefault[1, 1] * matrixMovement[1, 2] + matrixDefault[1, 2] * matrixMovement[2, 2]; 
            matrixNew[2, 0] = matrixDefault[2, 0] * matrixMovement[0, 0] + matrixDefault[2, 1] * matrixMovement[1, 0] + matrixDefault[2, 2] * matrixMovement[2, 0];
            matrixNew[2, 1] = matrixDefault[2, 0] * matrixMovement[0, 1] + matrixDefault[2, 1] * matrixMovement[1, 1] + matrixDefault[2, 2] * matrixMovement[2, 1];
            matrixNew[2, 2] = matrixDefault[2, 0] * matrixMovement[0, 2] + matrixDefault[2, 1] * matrixMovement[1, 2] + matrixDefault[2, 2] * matrixMovement[2, 2]; 

            p1.X = matrixNew[0, 0]+250;
            p1.Y = 250 - matrixNew[0, 1];
            p2.X = matrixNew[1, 0]+250;
            p2.Y = 250 -matrixNew[1, 1];
            p3.X = matrixNew[2, 0]+250;
            p3.Y = 250- matrixNew[2, 1];


            Polygon triangle1 = new Polygon();
            triangle1.Stroke = color;
            triangle1.StrokeThickness = 1;

            triangle1.Points.Add(p1);
            triangle1.Points.Add(p2);
            triangle1.Points.Add(p3);
            //canvas.Children.Clear();
            SolidColorBrush color1 = new SolidColorBrush();
            color1.Color = Colors.DarkBlue;
            triangle1.Stroke = color1;
            triangle1.StrokeThickness = 1;
            canvas.Children.Add(triangle1);


            //ROTATE TRANSFORMATION
            matrixDefault[0, 0] = p1.X - 250;
            matrixDefault[0, 1] = (p1.Y - 250) * (-1.0);
            matrixDefault[0, 2] = 1;
            matrixDefault[1, 0] = p2.X - 250;
            matrixDefault[1, 1] = (p2.Y - 250) * (-1.0);
            matrixDefault[1, 2] = 1;
            matrixDefault[2, 0] = p3.X - 250;
            matrixDefault[2, 1] = (p3.Y - 250) * (-1.0);
            matrixDefault[2, 2] = 1;


            double[,] matrixRotate = new double[2, 2];
            matrixRotate[0, 0] = Math.Cos(30.0);
            matrixRotate[0, 1] = Math.Sin(30.0) * -1;
            matrixRotate[1, 0] = Math.Sin(30.0);
            matrixRotate[1, 1] = Math.Cos(30.0);

            matrixNew[0, 0] = matrixDefault[0, 0] * matrixRotate[0, 0] + matrixDefault[0, 1] * matrixRotate[1, 0];
            matrixNew[0, 1] = matrixDefault[0, 0] * matrixRotate[0, 1] + matrixDefault[0, 1] * matrixRotate[1, 1];
            matrixNew[1, 0] = matrixDefault[1, 0] * matrixRotate[0, 0] + matrixDefault[1, 1] * matrixRotate[1, 0];
            matrixNew[1, 1] = matrixDefault[1, 0] * matrixRotate[0, 1] + matrixDefault[1, 1] * matrixRotate[1, 1];
            matrixNew[2, 0] = matrixDefault[2, 0] * matrixRotate[0, 0] + matrixDefault[2, 1] * matrixRotate[1, 0];
            matrixNew[2, 1] = matrixDefault[2, 0] * matrixRotate[0, 1] + matrixDefault[2, 1] * matrixRotate[1, 1];


            p1.X = matrixNew[0, 0] + 250;
            p1.Y = 250 - matrixNew[0, 1];
            p2.X = matrixNew[1, 0] + 250;
            p2.Y = 250 - matrixNew[1, 1];
            p3.X = matrixNew[2, 0] + 250;
            p3.Y = 250 - matrixNew[2, 1];

            Polygon triangle2 = new Polygon();

            SolidColorBrush color2 = new SolidColorBrush();
            color2.Color = Colors.Black;
            triangle2.Stroke = color2;
            triangle2.StrokeThickness = 1;

            triangle2.Points.Add(p1);
            triangle2.Points.Add(p2);
            triangle2.Points.Add(p3);
            canvas.Children.Add(triangle2);
        }

        private void slColorB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
