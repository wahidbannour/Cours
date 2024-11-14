
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GestionProduit.Entity
{
    public enum TypeMouvement
    {
        Entree,
        Sortie
    }

    public class Rayon
    {
        [PrimaryKey, AutoIncrement]
        public int Code { get; set; }
        public string Libelle { get; set; }
    }
    public class Produit
    {
        [PrimaryKey]
        public string Code { get; set; }
        public string Description { get; set; }
        public float QuantiteActuelle { get; set; }
        public DateTime InitDate { get; set; }

        public List<Mouvement> Mouvements { get; set; } = new List<Mouvement>();
        public Rayon Rayon { get; set; }
    }

    public class Mouvement
    {
        public TypeMouvement Flux { get; set; }
        public float Quantite { get; set; }
        public DateTime DateMouvement { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public DateTime DatePeremption { get; set; }
    }

    public class Fournisseur
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Label { get; set; }
        public string Address { get; set; }
    }
}
