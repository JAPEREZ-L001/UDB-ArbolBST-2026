using ArbolBST.Services;
using ArbolBST.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArbolBST.Forms
{
    //Clase principal del formulario su interfaz gráfica
    public partial class FormPrincipal : Form
    {
        //Instancia que tiene el árbol BST

        private ArbolBST.Services.ArbolBST arbol = new ArbolBST.Services.ArbolBST();


        //Constructor del formulario
        public FormPrincipal()
        {
            //Conexión de eventos distintos los cuales aparecen para que realizen su función pero estan
            //programados en código para facilidad del desarrollo del proyecto

            InitializeComponent();
            panelArbol.Paint += panelArbol_Paint;
            btnInsertar.Click += btnInsertar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnInOrden.Click += btnInOrden_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnSalir.Click += btnSalir_Click;


            panelContenedor.AutoScroll = true;

            //  tamaño grande para permitir scroll
            panelArbol.Size = new Size(2000, 1000);

        }

        //El panelarbol es donde se dibuja todo en este elemento gráfico
        private void panelArbol_Paint(object sender, PaintEventArgs e)
        {
            //Aquí están las configuraciones del panel gráfico 

            var g = e.Graphics;
            int ancho = panelArbol.Width;
            var posiciones = arbol.CalcularPosiciones(panelArbol.Width);
            if (posiciones == null) return;
            DibujarLineas(g, posiciones);
            DibujarNodos(g, posiciones);
        }

        //Función específica para recorrer todos los nodos por menos de líneas gráficas
        private void DibujarLineas(Graphics g, PosicionNodo[] nodos)
        {
            //Recorre todos los nodos 

            foreach (var n in nodos)

            //Si existe  dibuja la línea izquierda, si no la línea derecha
            {
                if (n.DatoIzquierda != null)
                {
                    var hijo = BuscarNodo(nodos, n.DatoIzquierda.Value);
                    if (hijo != null)
                        g.DrawLine(Pens.Black, n.X + 20, n.Y + 40, hijo.X + 20, hijo.Y);
                }
                //Derecho lado dderecho la misma condición

                if (n.DatoDerecha != null)
                {
                    var hijo = BuscarNodo(nodos, n.DatoDerecha.Value);
                    if (hijo != null)
                        g.DrawLine(Pens.Black, n.X + 20, n.Y + 40, hijo.X + 20, hijo.Y);
                }
            }
        }

        //Recorre todos los nodos del árbol para así dibujarlos 
        private void DibujarNodos(Graphics g, PosicionNodo[] nodos)
        {
            foreach (var n in nodos)
            {
                //Color por defecto 
                Brush color = Brushes.LightBlue;

                //Condición si el nodo pertenece al camino recorrido, Naranja si se encontró, rojo si no se encontró
                if (arbol.CaminoBusqueda != null)
                {
                    if (Contiene(arbol.CaminoBusqueda, n.Dato))
                        color = arbol.Encontrado ? Brushes.Orange : Brushes.Red;

                    if (arbol.Encontrado &&
                        n.Dato == arbol.CaminoBusqueda[arbol.CaminoBusqueda.Length - 1])
                        color = Brushes.Green;
                }

                //Estos métodos dibujan el circulo y tamaño del nodo
                g.FillEllipse(color, n.X, n.Y, 40, 40);
                g.DrawEllipse(Pens.Black, n.X, n.Y, 40, 40);

                g.DrawString(n.Dato.ToString(),
                    this.Font, Brushes.Black,
                    n.X + 10, n.Y + 10);
            }
        }

        //Busca el nodo por valor
        private PosicionNodo BuscarNodo(PosicionNodo[] nodos, int dato)
        {
            foreach (var n in nodos)
                if (n.Dato == dato)
                    return n;

            return null;
        }
        //Verificar si el valor está en el arreglo

        private bool Contiene(int[] arr, int val)
        {
            foreach (var v in arr)
                if (v == val)
                    return true;

            return false;
        }

        //Aquí se inserta el número que se desea para construir el árbol

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //Validaciones para solo insertar números
            try
            {
                int valor = int.Parse(txtValor.Text);
                arbol.Insertar(valor);
                arbol.CaminoBusqueda = null;

                panelArbol.Invalidate();
                txtValor.Clear();
            }
            catch
            {
                MessageBox.Show("Ingrese un número válido");
            }
        }

        //Indica si el camino está encontrado para realizar el recorrido hasta el número a dar 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor = int.Parse(txtValor.Text);

                bool encontrado = arbol.Buscar(valor, out string camino);

                MessageBox.Show((encontrado ? "Encontrado" : "No encontrado") + "\nCamino: " + camino);

                panelArbol.Invalidate();
            }
            catch
            {
                MessageBox.Show("Ingrese un número válido");
            }
        }

        //Muestra los valores ordenados 
        private void btnInOrden_Click(object sender, EventArgs e)
        {
            txtResultado.Text = arbol.ObtenerInOrdenComoTexto();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            arbol.Limpiar();
            panelArbol.Invalidate();
            txtResultado.Clear();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Boton para poder salir del programa
        //FIN DEL PROYECTO AQUI

        private void FormPrincipal_Load(object sender, System.EventArgs e)
        {

        }

      
    }
}
