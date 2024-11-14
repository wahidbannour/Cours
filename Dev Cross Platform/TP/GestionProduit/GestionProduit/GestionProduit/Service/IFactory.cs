using System;
using System.Collections.Generic;
using System.Text;

namespace SuiviFactures.Service
{
    /// <summary>
    /// interface to create services
    /// </summary>
    public interface IFactory
    {
        void Add<T,U> ();
        void Remove<U>();
        void Build();
    }
    
}
