using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calculatrice;
using RitegeMonitoring.Helper;

namespace WpfCalculatrice.ViewModels
{
    internal class VmCalculatrice : ViewModelBase
    {
        private CalculSimple calculSimple;
        private string resultat;

        public string Resultat {
            get => resultat;  //get { return resultat; } 
            set { resultat = value;
                OnPropertyChanged(nameof(Resultat));
            }
        }

        public ICommand ChiffreCmd { get; set; }   

        public VmCalculatrice()
        {
            ChiffreCmd = new RelayCommand(SaisieChiffre, IsSaisieChiffreActive);
            calculSimple = new CalculSimple();
            //resultat = "Initialisation de la calculatrice";
        }

        private bool IsSaisieChiffreActive(object obj)
        {
            return true;
        }

        private void SaisieChiffre(object obj)
        {
            int x =  int.Parse((string)obj);
            Resultat += x; 
        }
    }
}
