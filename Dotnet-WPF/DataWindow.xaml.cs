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
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {

        private bool _isDataDirty;

        public DataWindow() => InitializeComponent();

        private void DocumentTextBox_TextChanged(object sender, TextChangedEventArgs e)
            => _isDataDirty = true;

        private void Window_Closing(object sendr, System.ComponentModel.CancelEventArgs e)
        {
            if (_isDataDirty)
            {
                var result = MessageBox.Show("Document has changed. Close without saving?",
                    "Question", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No) e.Cancel = true;
            }
        }
    }
}
