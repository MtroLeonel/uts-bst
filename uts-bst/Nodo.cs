using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uts_bst
{
   
    public class Nodo
    {
        public int Valor;
        public Nodo Izq;
        public Nodo Der;

        public Nodo(int valor)
        {
            Valor = valor;
            Izq = null;
            Der = null;
        }
    }
}
