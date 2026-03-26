using System.Text;
using ArbolBST.Models;

namespace ArbolBST.Services
{
    /// <summary>
    /// Arbol binario de busqueda. No usa Stack, Queue ni Dictionary (restriccion del enunciado).
    /// El camino de busqueda y el InOrden se construyen con StringBuilder.
    /// </summary>

    //Define la posición del nodo, y lo configura con sus respectivos datos
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

        /// <summary>Raiz actual (solo lectura) para integracion con posiciones y dibujo.</summary>
        //La raíz es el primer nodo del árbol. Es el punto de partida para todas las operaciones.
        private NodoBST _raiz;
        public NodoBST Raiz => _raiz;

        //Este método inserta un valor en el árbol. 
        public void Insertar(int valor)
        {
            _raiz = InsertarRec(_raiz, valor);
        }

        //El árbol con este método se organizará automáticamente los valores menos a la izquierda y mayores a la derecha
        private static NodoBST InsertarRec(NodoBST nodo, int valor)
        {
            if (nodo == null)
            {
                return new NodoBST(valor);
            }

            if (valor < nodo.Dato)
            {
                nodo.Izquierda = InsertarRec(nodo.Izquierda, valor);
            }
            else if (valor > nodo.Dato)
            {
                nodo.Derecha = InsertarRec(nodo.Derecha, valor);
            }

            return nodo;
        }

        //Busca un valor dentro del arbol y devuelve dos cosas si lo encuentra amino y recorrido desde la raíz.
        public bool Buscar(int valor, out string caminoVisitados)
        {
            var sb = new StringBuilder();
            var lista = new int[100]; // arreglo fijo (sin List)
            int index = 0;

            bool ok = BuscarRec(_raiz, valor, sb, lista, ref index);

            // guardar camino real
            CaminoBusqueda = new int[index];
            for (int i = 0; i < index; i++)
                CaminoBusqueda[i] = lista[i];

            Encontrado = ok;

            caminoVisitados = sb.ToString();
            return ok;
        }

        //Recursivamente BuscarRec nos ayuda a encontrar un valor de un lado y lo recorre 
        private static bool BuscarRec(NodoBST nodo, int valor, StringBuilder sb, int[] lista, ref int index)
        {
            if (nodo == null) return false;

            if (sb.Length > 0)
                sb.Append(", ");

            sb.Append(nodo.Dato);

            lista[index++] = nodo.Dato;

            if (valor == nodo.Dato) return true;

            if (valor < nodo.Dato)
                return BuscarRec(nodo.Izquierda, valor, sb, lista, ref index);

            return BuscarRec(nodo.Derecha, valor, sb, lista, ref index);
        }

        /// <summary>Valores en recorrido InOrden separados por coma y espacio (orden ascendente).</summary>
        public string ObtenerInOrdenComoTexto()
        {
            // Validación: árbol vacío
            var sb = new StringBuilder();
            InOrdenRec(_raiz, sb);
            return sb.ToString();
        }
        //Primero recorre todo el lado izquierdo antes de procesar el nodo actual

        private static void InOrdenRec(NodoBST nodo, StringBuilder sb)
        {
            //Caso base 
            if (nodo == null)
            {
                return;
            }
            //Izquierda
            InOrdenRec(nodo.Izquierda, sb);

            // Raíz
            if (sb.Length > 0)
            {
                sb.Append(", ");
            }
            // utilizamos StringBuilder para evitar concatenaciones ineficientes de strings

            // Derecha
            sb.Append(nodo.Dato);

            InOrdenRec(nodo.Derecha, sb);
        }

        //Elimina todo el árbol reiniciando la raíz
        public void Limpiar()
        {
            _raiz = null;
        }

        //Guarda estado de busqueda para pintar colores
        public int[] CaminoBusqueda;
        public bool Encontrado;

        //Este método transforma la estructura del árbol en coordenada X e Y para poder dibujarlo en pantalla
        public PosicionNodo[] CalcularPosiciones(int anchoPanel)
        {
            var lista = new PosicionNodo[100];
            int index = 0;

            //La raíz se coloca en el centro del panel lo descubrimos haciendo scroll
            int centro = anchoPanel / 2;

            CalcularRec(_raiz, centro, 30, centro / 2, lista, ref index);

            PosicionNodo[] resultado = new PosicionNodo[index];
            for (int i = 0; i < index; i++)
                resultado[i] = lista[i];

            return resultado;
        }
        //Los nodos se separan horizontalmente según su nivel para evitar que se encimen
        private void CalcularRec(NodoBST nodo, int x, int y, int offset, PosicionNodo[] lista, ref int index)
        {
            if (nodo == null) return;

            lista[index++] = new PosicionNodo
            {
                Dato = nodo.Dato,
                X = x,
                Y = y,
                DatoIzquierda = nodo.Izquierda?.Dato,
                DatoDerecha = nodo.Derecha?.Dato
            };
            //Cada nivel del árbol se dibuja más abajo que el anterior
            CalcularRec(nodo.Izquierda, x - offset, y + 80, offset / 2, lista, ref index);
            CalcularRec(nodo.Derecha, x + offset, y + 80, offset / 2, lista, ref index);
        }
    }
}
