using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uts_bst
{

    public class ArbolBinarioBusqueda
    {
        public Nodo Raiz;
        // Constructor

        public void Insertar(int valor)
        // Insertar un valor en el árbol binario de búsqueda
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }

        // Método recursivo para insertar un valor en el árbol binario de búsqueda
        private Nodo InsertarRecursivo(Nodo actual, int valor)
        {
            if (actual == null) return new Nodo(valor);

            if (valor < actual.Valor)
                actual.Izq = InsertarRecursivo(actual.Izq, valor);
            else if (valor > actual.Valor)
                actual.Der = InsertarRecursivo(actual.Der, valor);
            //else
            //{
            //    // Llegamos aquí si valor == actual.Valor
            //    Console.WriteLine($"[AVISO]: El ID {valor} ya existe. No se permiten duplicados.");
            //    // En un sistema real aquí se lanzaría una Excepción:
            //    // throw new InvalidOperationException("ID Duplicado");
            //}
            return actual;
        }
        // Método para buscar un valor en el árbol binario de búsqueda
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(Raiz, valor);
        }
        // Método recursivo para buscar un valor en el árbol binario de búsqueda
        private bool BuscarRecursivo(Nodo actual, int valor)
        {
            if (actual == null) return false;
            if (actual.Valor == valor) return true;

            return valor < actual.Valor
                ? BuscarRecursivo(actual.Izq, valor)
                : BuscarRecursivo(actual.Der, valor);
        }
        // Método para eliminar un valor del árbol binario de búsqueda
        public void Eliminar(int valor)
        {
            Raiz = EliminarRecursivo(Raiz, valor);
        }
        // Método recursivo para eliminar un valor del árbol binario de búsqueda
        private Nodo EliminarRecursivo(Nodo actual, int valor)
        {
            if (actual == null) return actual;

            if (valor < actual.Valor)
                actual.Izq = EliminarRecursivo(actual.Izq, valor);
            else if (valor > actual.Valor)
                actual.Der = EliminarRecursivo(actual.Der, valor);
            else
            {
                if (actual.Izq == null) return actual.Der;
                if (actual.Der == null) return actual.Izq;

                actual.Valor = EncontrarMinimo(actual.Der);
                actual.Der = EliminarRecursivo(actual.Der, actual.Valor);
            }
            return actual;
        }
        // Método para encontrar el valor mínimo en un subárbol
        private int EncontrarMinimo(Nodo actual)
        {
            int min = actual.Valor;
            while (actual.Izq != null)
            {
                min = actual.Izq.Valor;
                actual = actual.Izq;
            }
            return min;
        }
        // Método para imprimir el árbol en orden
        public void ImprimirInorden()
        {
            InordenRecursivo(Raiz);
            Console.WriteLine();
        }
        // Método recursivo para imprimir el árbol en orden
        private void InordenRecursivo(Nodo actual)
        {
            if (actual != null)
            {
                InordenRecursivo(actual.Izq);
                Console.Write(actual.Valor + " ");
                InordenRecursivo(actual.Der);
            }
        }
    }
}
