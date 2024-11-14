using GestionProduit.Infrastructure;
using SQLite;
using System;
using System.IO;
using System.Resources;

namespace GestionProduit
{
    public class GlobalSetting
    {
        public GlobalSetting( ResourceManager resource)
        {
            Resource = resource;
            DataContext = new DataBaseContext();
        }
        public SQLiteAsyncConnection Database { get; }
        public static DataBaseContext DataContext { get; private set; }
        public static ResourceManager Resource { get; private set; }
        public const string DatabaseFilename = "GPP.db3";//Gestion de Produits pour Pharmacie

        public const SQLite.SQLiteOpenFlags Flags =
                                                    // open the database in read/write mode
                                                    SQLite.SQLiteOpenFlags.ReadWrite |
                                                    // create the database if it doesn't exist
                                                    SQLite.SQLiteOpenFlags.Create |
                                                    // enable multi-threaded database access
                                                    SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }    
    }

    

}
