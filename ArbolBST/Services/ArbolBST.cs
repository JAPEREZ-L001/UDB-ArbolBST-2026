using System.Text;
using ArbolBST.Models;

namespace ArbolBST.Services
{
    /// <summary>
    /// Arbol binario de busqueda. No usa Stack, Queue ni Dictionary (restriccion del enunciado).
    /// El camino de busqueda y el InOrden se construyen con StringBuilder.
    /// </summary>
    public class PosicionNodo
    {
        public int Dato;
        public int X;
        public int Y;
        public int? DatoIzquierda;
        public int? DatoDerecha;
    }

    public class ArbolBST
    {
        private NodoBST _raiz;

        /// <summary>Raiz actual (solo lectura) para integracion con posiciones y dibujo.</summary>
        public NodoBST Raiz => _raiz;

        public int[] CaminoBusqueda;
        public bool Encontrado;

        public bool Insertar(int valor)
        {
            bool insertado;
            _raiz = InsertarRec(_raiz, valor, out insertado);
            return insertado;
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
            var lista = new int[100];
            int index = 0;

            bool ok = BuscarRec(_raiz, valor, sb, lista, ref index);

            CaminoBusqueda = new int[index];
            for (int i = 0; i < index; i++)
                CaminoBusqueda[i] = lista[i];

            Encontrado = ok;
            caminoVisitados = sb.ToString();
            return ok;
        }

        private static bool BuscarRec(NodoBST nodo, int valor, StringBuilder sb, int[] lista, ref int index)
        {
            if (nodo == null)
                return false;

            if (sb.Length > 0)
                sb.Append(", ");

            sb.Append(nodo.Dato);
            lista[index++] = nodo.Dato;

            if (valor == nodo.Dato)
                return true;

            if (valor < nodo.Dato)
                return BuscarRec(nodo.Izquierda, valor, sb, lista, ref index);

            return BuscarRec(nodo.Derecha, valor, sb, lista, ref index);
        }

        /// <summary>Valores en recorrido InOrden separados por coma y espacio (orden ascendente).</summary>
        public string ObtenerInOrdenComoTexto()
        {
            if (_raiz == null)
                return "Árbol vacío";

            var sb = new StringBuilder();
            InOrdenRec(_raiz, sb);
            return sb.ToString();
        }

        private static void InOrdenRec(NodoBST nodo, StringBuilder sb)
        {
            if (nodo == null)
                return;

            InOrdenRec(nodo.Izquierda, sb);

            if (sb.Length > 0)
                sb.Append(", ");

            sb.Append(nodo.Dato);
            InOrdenRec(nodo.Derecha, sb);
        }

        public void Limpiar()
        {
            _raiz = null;
            CaminoBusqueda = null;
            Encontrado = false;
        }

        public PosicionNodo[] CalcularPosiciones(int anchoPanel)
        {
            var lista = new PosicionNodo[100];
            int index = 0;
            int centro = anchoPanel / 2;

            CalcularRec(_raiz, centro, 30, centro / 2, lista, ref index);

            var resultado = new PosicionNodo[index];
            for (int i = 0; i < index; i++)
                resultado[i] = lista[i];

            return resultado;
        }

        private void CalcularRec(NodoBST nodo, int x, int y, int offset, PosicionNodo[] lista, ref int index)
        {
            if (nodo == null)
                return;

            lista[index++] = new PosicionNodo
            {
                Dato = nodo.Dato,
                X = x,
                Y = y,
                DatoIzquierda = nodo.Izquierda?.Dato,
                DatoDerecha = nodo.Derecha?.Dato
            };

            CalcularRec(nodo.Izquierda, x - offset, y + 80, offset / 2, lista, ref index);
            CalcularRec(nodo.Derecha, x + offset, y + 80, offset / 2, lista, ref index);
        }
    }
}
