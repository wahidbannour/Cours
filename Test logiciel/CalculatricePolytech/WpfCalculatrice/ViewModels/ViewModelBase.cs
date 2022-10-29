using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfCalculatrice.ViewModels
{
    internal class ViewModelBase:INotifyPropertyChanged
    {
        
        public ICommand? PropertyChangedCmd { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public ViewModelBase()
        {

        }
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            if (PropertyChangedCmd != null)
            {
                PropertyChangedCmd.Execute(name);
            }
        }
    }
}
