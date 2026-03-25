namespace ArbolBST.Models
{
    public class NodoBST
    {
        public int Dato;
        public NodoBST Izquierda;
        public NodoBST Derecha;

        public NodoBST(int dato)
        {
            Dato = dato;
            Izquierda = null;
            Derecha = null;
        }
    }
}
