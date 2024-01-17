using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dotnet_WPF
{
    /// <summary>
    /// Interaction logic for MyPictures.xaml
    /// </summary>
    public partial class MyPictures : Window
    {
        public MyPictures()
        {
            InitializeComponent();
        }
    }

    public class Photo
    {
        public string Source { get; }
        public Photo(string path)
        {
            Source = path;
        }
        public override string ToString() => Source;
    }
}
