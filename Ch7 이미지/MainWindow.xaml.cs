using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ch7_이미지
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

        private void img_MouseEnter(object sender, MouseEventArgs e)
        {
            img.Source = new BitmapImage(new Uri("https://cdn3.iconfinder.com/data/icons/people-emoji/50/Robot-1024.png"));
        }

        private void img_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}