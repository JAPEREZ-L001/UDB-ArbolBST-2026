using ArbolBST.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ArbolBST.Forms
{
    public partial class FormPrincipal : Form
    {
        private readonly ArbolBST.Services.ArbolBST arbol = new ArbolBST.Services.ArbolBST();

        private const int RadioNodo = 22;
        private const int DiametroNodo = RadioNodo * 2;
        private const int AnchoReferenciaLayout = 1000;
        private const float MargenEscala = 32f;

        private static readonly Color ColorNodoDefault = Color.FromArgb(100, 149, 237);
        private static readonly Color ColorNodoCamino = Color.FromArgb(255, 165, 0);
        private static readonly Color ColorNodoEncontrado = Color.FromArgb(46, 139, 87);
        private static readonly Color ColorNodoNoEncontrado = Color.FromArgb(220, 80, 80);
        private static readonly Color ColorLinea = Color.FromArgb(120, 130, 145);

        private static readonly Color ColorMensajeError = Color.FromArgb(180, 50, 50);
        private static readonly Color ColorMensajeExito = Color.FromArgb(30, 130, 70);
        private static readonly Color ColorMensajeNeutral = Color.FromArgb(60, 60, 60);

        private Shortcuts _shortcuts;

        public FormPrincipal()
        {
            InitializeComponent();

            panelArbol.Paint += panelArbol_Paint;
            panelArbol.Resize += (s, e) => panelArbol.Invalidate();
            panelContenedor.Resize += (s, e) => panelArbol.Invalidate();

            btnInsertar.Click += btnInsertar_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnInOrden.Click += btnInOrden_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnSalir.Click += btnSalir_Click;

            RegistrarAtajos();
        }

        private void RegistrarAtajos()
        {
            _shortcuts = new Shortcuts(this)
                .EnDialogo(txtValor, Keys.Enter, () => btnInsertar.PerformClick())
                .EnControl(txtValor, Keys.F3, () => btnBuscar.PerformClick())
                .EnControl(txtValor, Keys.F5, () => btnInOrden.PerformClick())
                .Global(Keys.F2, () => btnInsertar.PerformClick())
                .Global(Keys.F3, () => btnBuscar.PerformClick())
                .Global(Keys.F5, () => btnInOrden.PerformClick())
                .Global(Keys.F9, () => btnLimpiar.PerformClick())
                .Global(Keys.Escape, () => btnLimpiar.PerformClick());

            _shortcuts.Activar();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (_shortcuts != null && _shortcuts.TryProcessDialogKey(keyData, ActiveControl))
                return true;

            return base.ProcessDialogKey(keyData);
        }

        private void panelArbol_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var posiciones = arbol.CalcularPosiciones(AnchoReferenciaLayout);
            if (posiciones == null || posiciones.Length == 0)
                return;

            RectangleF bounds = ObtenerBounds(posiciones);
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return;

            float escala = CalcularEscala(bounds, panelArbol.ClientSize);
            float offsetX = (panelArbol.ClientSize.Width - bounds.Width * escala) / 2f - bounds.Left * escala;
            float offsetY = (panelArbol.ClientSize.Height - bounds.Height * escala) / 2f - bounds.Top * escala;

            g.TranslateTransform(offsetX, offsetY);
            g.ScaleTransform(escala, escala);

            DibujarLineas(g, posiciones);
            DibujarNodos(g, posiciones);
        }

        private static float CalcularEscala(RectangleF bounds, Size area)
        {
            float anchoUtil = Math.Max(1, area.Width - MargenEscala * 2);
            float altoUtil = Math.Max(1, area.Height - MargenEscala * 2);

            float escalaX = anchoUtil / bounds.Width;
            float escalaY = altoUtil / bounds.Height;
            float escala = Math.Min(escalaX, escalaY);

            if (float.IsNaN(escala) || float.IsInfinity(escala) || escala <= 0)
                return 1f;

            return escala;
        }

        private RectangleF ObtenerBounds(PosicionNodo[] nodos)
        {
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            foreach (var n in nodos)
            {
                minX = Math.Min(minX, n.X);
                minY = Math.Min(minY, n.Y);
                maxX = Math.Max(maxX, n.X + DiametroNodo);
                maxY = Math.Max(maxY, n.Y + DiametroNodo);
            }

            return new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }

        private void DibujarLineas(Graphics g, PosicionNodo[] nodos)
        {
            using (var pen = new Pen(ColorLinea, 2f))
            {
                foreach (var n in nodos)
                {
                    int cxPadre = n.X + RadioNodo;
                    int cyPadre = n.Y + DiametroNodo;

                    if (n.DatoIzquierda != null)
                    {
                        var hijo = BuscarNodo(nodos, n.DatoIzquierda.Value);
                        if (hijo != null)
                            g.DrawLine(pen, cxPadre, cyPadre, hijo.X + RadioNodo, hijo.Y);
                    }

                    if (n.DatoDerecha != null)
                    {
                        var hijo = BuscarNodo(nodos, n.DatoDerecha.Value);
                        if (hijo != null)
                            g.DrawLine(pen, cxPadre, cyPadre, hijo.X + RadioNodo, hijo.Y);
                    }
                }
            }
        }

        private void DibujarNodos(Graphics g, PosicionNodo[] nodos)
        {
            using (var font = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (var penBorde = new Pen(Color.FromArgb(50, 60, 80), 1.5f))
            {
                foreach (var n in nodos)
                {
                    Color fill = ObtenerColorNodo(n.Dato);
                    using (var brush = new SolidBrush(fill))
                    {
                        g.FillEllipse(brush, n.X, n.Y, DiametroNodo, DiametroNodo);
                        g.DrawEllipse(penBorde, n.X, n.Y, DiametroNodo, DiametroNodo);
                    }

                    string texto = n.Dato.ToString();
                    var tam = g.MeasureString(texto, font);
                    float tx = n.X + (DiametroNodo - tam.Width) / 2f;
                    float ty = n.Y + (DiametroNodo - tam.Height) / 2f;
                    g.DrawString(texto, font, Brushes.White, tx, ty);
                }
            }
        }

        private Color ObtenerColorNodo(int dato)
        {
            if (arbol.CaminoBusqueda == null || arbol.CaminoBusqueda.Length == 0)
                return ColorNodoDefault;

            if (arbol.Encontrado &&
                arbol.CaminoBusqueda[arbol.CaminoBusqueda.Length - 1] == dato)
                return ColorNodoEncontrado;

            if (Contiene(arbol.CaminoBusqueda, dato))
                return arbol.Encontrado ? ColorNodoCamino : ColorNodoNoEncontrado;

            return ColorNodoDefault;
        }

        private static PosicionNodo BuscarNodo(PosicionNodo[] nodos, int dato)
        {
            foreach (var n in nodos)
                if (n.Dato == dato)
                    return n;
            return null;
        }

        private static bool Contiene(int[] arr, int val)
        {
            if (arr == null) return false;
            foreach (var v in arr)
                if (v == val)
                    return true;
            return false;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!TryReadValor(out int valor))
                return;

            if (!arbol.Insertar(valor))
            {
                MostrarMensaje("Duplicado: " + valor + " ya existe en el árbol.", ColorMensajeError);
                return;
            }

            arbol.CaminoBusqueda = null;
            panelArbol.Invalidate();
            txtResultado.Text = arbol.ObtenerInOrdenComoTexto();
            MostrarMensaje("Insertado: " + valor, ColorMensajeExito);
            txtValor.Clear();
            txtValor.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!TryReadValor(out int valor))
                return;

            bool encontrado = arbol.Buscar(valor, out string camino);
            string etiqueta = encontrado ? "Encontrado" : "No encontrado";
            MostrarMensaje(etiqueta + ". Camino: " + camino,
                encontrado ? ColorMensajeExito : ColorMensajeError);

            panelArbol.Invalidate();
        }

        private void btnInOrden_Click(object sender, EventArgs e)
        {
            txtResultado.Text = arbol.ObtenerInOrdenComoTexto();
            MostrarMensaje("Recorrido InOrden actualizado.", ColorMensajeNeutral);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            arbol.Limpiar();
            panelArbol.Invalidate();
            txtResultado.Clear();
            txtValor.Clear();
            MostrarMensaje("Árbol vaciado.", ColorMensajeNeutral);
            txtValor.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool TryReadValor(out int valor)
        {
            if (string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MostrarMensaje("Ingrese un valor numérico.", ColorMensajeError);
                valor = 0;
                txtValor.Focus();
                return false;
            }

            if (!int.TryParse(txtValor.Text.Trim(), out valor))
            {
                MostrarMensaje("Ingrese un número entero válido.", ColorMensajeError);
                txtValor.Focus();
                return false;
            }

            return true;
        }

        private void MostrarMensaje(string texto, Color color)
        {
            lblMensaje.ForeColor = color;
            lblMensaje.Text = texto;
        }
    }
}
