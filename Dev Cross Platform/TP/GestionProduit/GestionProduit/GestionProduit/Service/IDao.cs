using GestionProduit.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionProduit.Service
{
    public interface IDaoQueryFournisseur
    {
        Task<List<Fournisseur>> GetAllFournisseursAsync();
        Task<Fournisseur> GetFournisseurByNameAsync(string name);

    }
    public interface IDaoCommandFournisseur
    {
        Task<bool> AddFournisseurAsync(Fournisseur fournisseur);
    }
    public interface IDaoQueryProduct
    { 
        Task<List<Produit>> GetProductByRayonAsync(Rayon rayon);
        Task<List<Produit>> GetProductByFournisseurAsync(Fournisseur fournisseur);
    }

    public interface IDaoCommandProduct
    {
        Task AddProductAsync(Produit produit);
        Task DeleteProductAsync(Produit produit);
        Task UpdateProductAsync(Produit produit);
    }
}