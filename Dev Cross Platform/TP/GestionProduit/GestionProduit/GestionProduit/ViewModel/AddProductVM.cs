using GestionProduit.Entity;
using GestionProduit.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionProduit.ViewModel
{
    class AddProductVM : ExtendedBindableObject
    {

        #region DATA
        Produit produit;
        IDaoCommandProduct daoProduct;
        #endregion
        #region Properties
        public Produit Produit
        {
            get { return produit; }
            set { produit = value; RaisePropertyChanged(() => Produit); }
        }
        #endregion
        public ICommand SaveCmd { get; set; }
        public ICommand ModifyCmd { get; set; }
        public ICommand DeleteCmd { get; set; }
        public AddProductVM(IDaoCommandProduct daoCommandProduct)
        {
            daoProduct = daoCommandProduct;
            SaveCmd = new Command(Save, CanSave);
            ModifyCmd = new Command(Modify, CanModify);
            DeleteCmd = new Command(Delete, CanDelete);
        }

        private bool CanSave(object arg)
        {
            return true;
        }
        private bool CanDelete(object arg)
        {
            return true;
        }

        
        private bool CanModify(object arg)
        {
            return true;
        }

        private void Modify(object obj)
        {
            daoProduct.UpdateProductAsync(Produit);
        }
        private void Delete(object obj)
        {
            daoProduct.DeleteProductAsync(Produit);
        }

        private void Save(object obj)
        {
            daoProduct.AddProductAsync(Produit);
        }
    }
}
