using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritege.Helpers.Interface
{
    public interface IView
    {
        IViewModel ViewModel
        {
            get;
            set;
        }
        Boolean CanQuit
        {
            get;
            set;
        }

        void Show();
       void Close();
      
    }
}
