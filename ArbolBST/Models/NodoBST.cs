namespace ArbolBST.Models
{
    //Esta es la clase que representa un nodo del árbol binario de búsqueda
    public class NodoBST
    {
        //Valor que almacena el dato

        public int Dato;

        //Referencia a los hijos izquierdos (valores menores), e hijos derechos (valores mayores)

        public NodoBST Izquierda;
        public NodoBST Derecha;

        //Constructor: Se ejecuta cuando se crea un nuevo nodo
        public NodoBST(int dato)
        {
            Dato = dato;

            //Al inicio la clase no tiene hijos

            Izquierda = null;
            Derecha = null;
        }
    }
}
