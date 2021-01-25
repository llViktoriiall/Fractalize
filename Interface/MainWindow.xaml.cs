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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FractalsMain f = new FractalsMain();
            f.Show();
            this.Close();
        }
        private void Button_Click_Colors(object sender, RoutedEventArgs e)
        {
            ColorsMain f = new ColorsMain();
            f.Show();
            this.Close();
        }

        private void Button_Click_Triangle(object sender, RoutedEventArgs e)
        {
            AfinneMain f = new AfinneMain();
            f.Show();
            this.Close();
        }
    }
}
