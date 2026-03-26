using System.Text;
using ArbolBST.Models;

namespace ArbolBST.Services
{
    /// <summary>
    /// Arbol binario de busqueda. No usa Stack, Queue ni Dictionary (restriccion del enunciado).
    /// El camino de busqueda y el InOrden se construyen con StringBuilder.
    /// </summary>
    /// 
    public class ArbolBST
    {
        private NodoBST _raiz;

        /// <summary>Raiz actual (solo lectura) para integracion con posiciones y dibujo.</summary>
        public NodoBST Raiz => _raiz;

        public bool Insertar(int valor) //Validacion: no insertar duplicados, volverlo a booleano
        {
            bool insertado;
            _raiz = InsertarRec(_raiz, valor, out insertado);
            return insertad o;
        }

        private static NodoBST InsertarRec(NodoBST nodo, int valor, out bool insertado)
        {
            if (nodo == null)
            {
                insertado = true;
                return new NodoBST(valor);
            }

            if (valor < nodo.Dato)
            {
                nodo.Izquierda = InsertarRec(nodo.Izquierda, valor, out insertado);
            }
            else if (valor > nodo.Dato)
            {
                nodo.Derecha = InsertarRec(nodo.Derecha, valor, out insertado);
            }
            else
            {
                //duplicado
                insertado = false;
            }

                return nodo;
        }

        /// <summary>
        /// Busca un valor. Devuelve si existe y el camino de nodos visitados (valores separados por coma y espacio).
        /// </summary>
        public bool Buscar(int valor, out string caminoVisitados)
        {
            var sb = new StringBuilder();
            bool ok = BuscarRec(_raiz, valor, sb);
            caminoVisitados = sb.ToString();
            return ok;
        }

        private static bool BuscarRec(NodoBST nodo, int valor, StringBuilder sb)
        {
            if (nodo == null)
            {
                return false;
            }

            if (sb.Length > 0)
            {
                sb.Append(", ");
            }

            sb.Append(nodo.Dato);

            if (valor == nodo.Dato)
            {
                return true;
            }

            if (valor < nodo.Dato)
            {
                return BuscarRec(nodo.Izquierda, valor, sb);
            }

            return BuscarRec(nodo.Derecha, valor, sb);
        }

        /// <summary>Valores en recorrido InOrden separados por coma y espacio (orden ascendente).</summary>
        public string ObtenerInOrdenComoTexto() // método para InOrden
        {
            if(_raiz == null) //Validacion de arbol vacio
                return "Árbol vacío"

            var sb = new StringBuilder();
            InOrdenRec(_raiz, sb);
            return sb.ToString();
        }

        private static void InOrdenRec(NodoBST nodo, StringBuilder sb) 
        {
            if (nodo == null)
            {
                return;
            }

            InOrdenRec(nodo.Izquierda, sb);

            if (sb.Length > 0)
            {
                sb.Append(", ");
            }

            sb.Append(nodo.Dato);

            InOrdenRec(nodo.Derecha, sb);
        }

        public void Limpiar()
        {
            _raiz = null;
        }
        //esto es solo para que git funcione xd
    }
}
