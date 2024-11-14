using System;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionProduit
{
    public partial class App : Application
    {
        public App()
        {
            
            InitializeComponent();
            //try
            //{
                ResourceManager rm = new ResourceManager("FactureResource",
                                                        typeof(App).Assembly);
                var globalSetting = new GlobalSetting(rm);//new DaoAjouterFactureSqlite(),

                MainPage = new NavigationPage(new MainPage())
                {
                    BarBackgroundColor = Color.Blue,
                    BarTextColor = Color.White
                };
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
             
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
