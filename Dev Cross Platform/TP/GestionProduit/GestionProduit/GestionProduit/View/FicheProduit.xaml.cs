using GestionProduit.Infrastructure;
using GestionProduit.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionProduit.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicheProduit : ContentPage
    {
        public FicheProduit()
        {
            InitializeComponent();
            BindingContext = new AddProductVM(new SqliteDaoCommandProduct());  
        }
    }
}