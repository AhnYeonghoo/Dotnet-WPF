using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;

namespace PopUpPractice
{
    class InheritTheApp : Application
    {
        [STAThread]
        public static void Main()
        {
            InheritTheApp app = new InheritTheApp();
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Window win = new Window();
            win.Title = "Inherit the App";
            win.Show();
        }
        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);

            MessageBoxResult result =
                MessageBox.Show("Do You Want to save your data?",
                MainWindow.Title,
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question,
                MessageBoxResult.Yes);
        }
    }
}
