using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritege.Helpers.Interface
{
    public interface IViewModel :IDisposable 
    {
        void Sauvegarder();
        bool TryToQuit();
       
    }
}
