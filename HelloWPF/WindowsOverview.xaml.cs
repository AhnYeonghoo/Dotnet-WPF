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

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for WindowsOverview.xaml
    /// </summary>
    public partial class WindowsOverview : Window
    {
        public WindowsOverview() =>
            InitializeComponent();

        private void fileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool _isDataDirth;
        private void DocumentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isDataDirth = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBoxResult.No;
            if (_isDataDirth)
            {
                result = MessageBox.Show("Document has changed. Close without saving?",
                    "Question",
                    MessageBoxButton.YesNo); 
            }

            if (result == MessageBoxResult.No) e.Cancel = true;
        }
    }
}
