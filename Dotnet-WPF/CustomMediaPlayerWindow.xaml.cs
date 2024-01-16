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
    /// Interaction logic for CustomMediaPlayerWindow.xaml
    /// </summary>
    public partial class CustomMediaPlayerWindow : Window
    {
        public CustomMediaPlayerWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            mediaElement.Play();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            mediaElement.Pause();
        }
    }
}
