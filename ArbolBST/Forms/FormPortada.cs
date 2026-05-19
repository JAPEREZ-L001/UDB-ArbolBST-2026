using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ArbolBST.Forms
{
    public partial class FormPortada : Form
    {
        private static readonly Color ColorFondo = Color.FromArgb(11, 22, 38);
        private static readonly Color ColorTarjeta = Color.FromArgb(20, 36, 56);
        private static readonly Color ColorAcento = Color.FromArgb(76, 201, 240);
        private static readonly Color ColorTextoTitulo = Color.White;
        private static readonly Color ColorTextoSuave = Color.FromArgb(170, 190, 210);
        private static readonly Color ColorCarnet = Color.FromArgb(150, 175, 200);
        private static readonly Color ColorBordeTarjeta = Color.FromArgb(45, 70, 100);

        private static readonly (string Nombre, string Carnet)[] Integrantes =
        {
            ("Mario Alejandro Noubleau Callejas", "NC250266"),
            ("Josué Adonaí Pérez López",          "PL250205"),
            ("Paola Elizabeth Carballo Quijada",  "CQ250338"),
            ("Rodrigo Abel Joyar González",       "JG251114"),
            ("Gabriel Ernesto López Breucop",     "LB250311"),
        };

        public FormPortada()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ConstruirPortada();
        }

        private void ConstruirPortada()
        {
            panelFondo.Controls.Clear();

            var contenido = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                BackColor = ColorFondo,
                Padding = new Padding(40, 28, 40, 28),
                AutoSize = false
            };
            contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            contenido.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // encabezado
            contenido.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // titulo proyecto
            contenido.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // materia
            contenido.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // separador
            contenido.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // integrantes label
            contenido.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // grid integrantes
            contenido.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // catedratico
            contenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100f)); // espacio
            contenido.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // boton

            contenido.Controls.Add(CrearEncabezado(), 0, 0);
            contenido.Controls.Add(CrearTituloProyecto(), 0, 1);
            contenido.Controls.Add(CrearMateria(), 0, 2);
            contenido.Controls.Add(CrearSeparador(), 0, 3);
            contenido.Controls.Add(CrearLabelSeccion("Integrantes"), 0, 4);
            contenido.Controls.Add(CrearGridIntegrantes(), 0, 5);
            contenido.Controls.Add(CrearCatedratico(), 0, 6);
            contenido.Controls.Add(new Panel { Dock = DockStyle.Fill, BackColor = ColorFondo }, 0, 7);
            contenido.Controls.Add(CrearBotonIniciar(), 0, 8);

            panelFondo.Controls.Add(contenido);
        }

        private Control CrearEncabezado()
        {
            var fila = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                BackColor = ColorFondo,
                Margin = new Padding(0, 0, 0, 4)
            };
            fila.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            fila.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            fila.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            fila.Controls.Add(CrearLogoUDB(), 0, 0);

            var textos = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = ColorFondo,
                Margin = new Padding(16, 4, 0, 0)
            };
            textos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            textos.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            textos.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            textos.Controls.Add(CrearLabel(
                "UNIVERSIDAD DON BOSCO",
                12f, FontStyle.Bold, ColorTextoTitulo, ContentAlignment.MiddleLeft), 0, 0);

            textos.Controls.Add(CrearLabel(
                "Campus Antiguo Cuscatlán",
                10f, FontStyle.Regular, ColorAcento, ContentAlignment.MiddleLeft), 0, 1);

            fila.Controls.Add(textos, 1, 0);
            return fila;
        }

        private Control CrearLogoUDB()
        {
            var logo = new Panel
            {
                Size = new Size(72, 72),
                BackColor = ColorFondo,
                Margin = new Padding(0)
            };
            logo.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                using (var pen = new Pen(ColorAcento, 3f))
                    g.DrawEllipse(pen, 4, 4, 64, 64);

                using (var font = new Font("Segoe UI", 14f, FontStyle.Bold))
                {
                    string texto = "UDB";
                    var tam = g.MeasureString(texto, font);
                    g.DrawString(texto, font, new SolidBrush(ColorAcento),
                        (logo.Width - tam.Width) / 2f,
                        (logo.Height - tam.Height) / 2f);
                }
            };
            return logo;
        }

        private Control CrearTituloProyecto()
        {
            var titulo = CrearLabel(
                "Simulador de Árbol BST",
                28f, FontStyle.Bold, ColorAcento, ContentAlignment.MiddleCenter);
            titulo.Margin = new Padding(0, 18, 0, 4);
            return titulo;
        }

        private Control CrearMateria()
        {
            var contenedor = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 1,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = ColorFondo,
                Margin = new Padding(0, 0, 0, 8)
            };
            contenedor.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            contenedor.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            contenedor.Controls.Add(CrearLabel(
                "Programación con Estructuras de Datos · Grupo G01T",
                11f, FontStyle.Bold, ColorTextoTitulo, ContentAlignment.MiddleCenter), 0, 0);

            contenedor.Controls.Add(CrearLabel(
                "Ciclo 03 · 12 de mayo de 2026",
                9.5f, FontStyle.Regular, ColorTextoSuave, ContentAlignment.MiddleCenter), 0, 1);

            return contenedor;
        }

        private Control CrearSeparador()
        {
            return new Panel
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = ColorBordeTarjeta,
                Margin = new Padding(0, 16, 0, 16)
            };
        }

        private Control CrearLabelSeccion(string texto)
        {
            var lbl = CrearLabel(texto, 12f, FontStyle.Bold, ColorAcento, ContentAlignment.MiddleLeft);
            lbl.Margin = new Padding(0, 0, 0, 10);
            return lbl;
        }

        private Control CrearGridIntegrantes()
        {
            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = ColorFondo,
                Margin = new Padding(0, 0, 0, 14)
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            int filas = (Integrantes.Length + 1) / 2;
            for (int i = 0; i < filas; i++)
                grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int i = 0; i < Integrantes.Length; i++)
            {
                var tarjeta = CrearTarjetaIntegrante(Integrantes[i].Nombre, Integrantes[i].Carnet);
                tarjeta.Dock = DockStyle.Fill;
                grid.Controls.Add(tarjeta, i % 2, i / 2);

                if (i == Integrantes.Length - 1 && Integrantes.Length % 2 == 1)
                    grid.SetColumnSpan(tarjeta, 2);
            }

            return grid;
        }

        private Control CrearTarjetaIntegrante(string nombre, string carnet)
        {
            var tarjeta = new Panel
            {
                Height = 64,
                BackColor = ColorTarjeta,
                Margin = new Padding(6, 6, 6, 6),
                Padding = new Padding(0)
            };

            var franja = new Panel
            {
                Dock = DockStyle.Left,
                Width = 4,
                BackColor = ColorAcento
            };
            tarjeta.Controls.Add(franja);

            var textos = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                BackColor = ColorTarjeta,
                Padding = new Padding(14, 10, 14, 10)
            };
            textos.RowStyles.Add(new RowStyle(SizeType.Percent, 60f));
            textos.RowStyles.Add(new RowStyle(SizeType.Percent, 40f));

            textos.Controls.Add(CrearLabel(
                nombre, 9.75f, FontStyle.Bold, ColorTextoTitulo, ContentAlignment.MiddleLeft), 0, 0);

            textos.Controls.Add(CrearLabel(
                carnet, 9f, FontStyle.Regular, ColorCarnet, ContentAlignment.MiddleLeft), 0, 1);

            tarjeta.Controls.Add(textos);

            tarjeta.Paint += (s, e) =>
            {
                using (var pen = new Pen(ColorBordeTarjeta))
                    e.Graphics.DrawRectangle(pen, 0, 0, tarjeta.Width - 1, tarjeta.Height - 1);
            };

            return tarjeta;
        }

        private Control CrearCatedratico()
        {
            var contenedor = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 1,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = ColorFondo,
                Margin = new Padding(0, 6, 0, 0)
            };
            contenedor.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            contenedor.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            contenedor.Controls.Add(CrearLabel(
                "Catedrático",
                9.5f, FontStyle.Regular, ColorTextoSuave, ContentAlignment.MiddleCenter), 0, 0);

            contenedor.Controls.Add(CrearLabel(
                "Ing. Rafael Torres Rodríguez",
                11f, FontStyle.Bold, ColorAcento, ContentAlignment.MiddleCenter), 0, 1);

            return contenedor;
        }

        private Control CrearBotonIniciar()
        {
            var boton = new Button
            {
                Text = "Iniciar simulador",
                Size = new Size(320, 48),
                BackColor = ColorAcento,
                ForeColor = ColorFondo,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11.5f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0, 18, 0, 0)
            };
            boton.FlatAppearance.BorderSize = 0;
            boton.Click += BtnIniciar_Click;
            return boton;
        }

        private static Label CrearLabel(string texto, float tamFuente, FontStyle estilo, Color color, ContentAlignment align)
        {
            var anchor = AnchorStyles.None;
            if (align == ContentAlignment.MiddleLeft) anchor = AnchorStyles.Left;
            else if (align == ContentAlignment.MiddleRight) anchor = AnchorStyles.Right;

            return new Label
            {
                Text = texto,
                Font = new Font("Segoe UI", tamFuente, estilo),
                ForeColor = color,
                BackColor = Color.Transparent,
                AutoSize = true,
                TextAlign = align,
                Anchor = anchor,
                Margin = new Padding(0, 2, 0, 2)
            };
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            var simulador = new FormPrincipal();
            simulador.FormClosed += (s2, e2) => Show();
            Hide();
            simulador.Show();
        }
    }
}
