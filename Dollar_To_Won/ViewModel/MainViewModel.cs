using Dollar_To_Won.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dollar_To_Won.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private MainModel myModel = null;

        public MainViewModel()
        {
            myModel = new MainModel();
        }

        public string Dollar
        {
            get
            {
                if (string.IsNullOrEmpty(myModel.Dollar))
                {
                    Won = "0";
                }
                else
                {
                    int num = -1;
                    if (int.TryParse(myModel.Dollar, out num))
                    {
                        int result = num * 1160;
                        Won = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Please Insert Number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        Dollar = "";
                        Won = "0";
                    }
                }
                return myModel.Dollar;
            }
            set
            {
                if (myModel.Dollar != value)
                {
                    myModel.Dollar = value;
                    OnPropertyChanged("Dollar");
                }
            }
        }

        public string Won
        {
            get
            {
                return myModel.Won;
            }
            set
            {
                myModel.Won = value;
                OnPropertyChanged("Won");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }

}