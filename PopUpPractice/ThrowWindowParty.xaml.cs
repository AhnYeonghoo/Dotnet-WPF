﻿using System;
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

namespace PopUpPractice
{
    /// <summary>
    /// ThrowWindowParty.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ThrowWindowParty : Application
    {
        [STAThread]
        public static void Mainsss()
        {
            ThrowWindowParty app = new ThrowWindowParty();
            app.InitializeComponent();
        }



        protected override void OnStartup(StartupEventArgs args)
        {
            Window winMain = new Window();
            winMain.Title = "Main Window";
            winMain.MouseDown += WindowOnMouseDown;
            winMain.Show();

            for (int i = 0; i < 2; i++)
            {
                Window win = new Window();
                win.Title = "Extra Window No." + (i + 1);
                win.Show();
            }
        }

        void WindowOnMouseDown(object sender, MouseButtonEventArgs args)
        {
            Window win = new Window();
            win.Title = "Model Dialog Box";
            win.ShowDialog();
        }
        
    }
}
