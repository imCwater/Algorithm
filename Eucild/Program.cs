using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Euclid
{
   
    public partial class MainWindow : Window
    {
        
        private int Euclid(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return Euclid(b, a%b);
        }
    }
}

