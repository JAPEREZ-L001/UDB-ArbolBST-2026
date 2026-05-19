using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArbolBST.Forms
{
    /// <summary>
    /// Registra atajos de teclado para un formulario WinForms.
    /// </summary>
    public sealed class Shortcuts
    {
        private readonly Form _form;
        private readonly Dictionary<Keys, Action> _atajosGlobales = new Dictionary<Keys, Action>();
        private readonly List<AtajoControl> _atajosPorControl = new List<AtajoControl>();
        private readonly List<AtajoDialogo> _atajosDialogo = new List<AtajoDialogo>();
        private bool _ejecutando;

        private sealed class AtajoControl
        {
            public Control Control;
            public Keys Tecla;
            public Action Accion;
        }

        private sealed class AtajoDialogo
        {
            public Control Control;
            public Keys Tecla;
            public Action Accion;
        }

        public Shortcuts(Form form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
        }

        /// <summary>Atajo en KeyDown de un control (F2, F3, etc.). No usar Enter aquí.</summary>
        public Shortcuts EnControl(Control control, Keys tecla, Action accion)
        {
            _atajosPorControl.Add(new AtajoControl
            {
                Control = control,
                Tecla = tecla,
                Accion = accion
            });
            return this;
        }

        /// <summary>
        /// Atajo que intercepta Enter antes del botón por defecto del formulario.
        /// Llamar TryProcessDialogKey desde ProcessDialogKey del formulario.
        /// </summary>
        public Shortcuts EnDialogo(Control control, Keys tecla, Action accion)
        {
            _atajosDialogo.Add(new AtajoDialogo
            {
                Control = control,
                Tecla = tecla,
                Accion = accion
            });
            return this;
        }

        /// <summary>Atajo a nivel de formulario (requiere KeyPreview).</summary>
        public Shortcuts Global(Keys tecla, Action accion)
        {
            _atajosGlobales[tecla] = accion;
            return this;
        }

        public void Activar()
        {
            _form.AcceptButton = null;
            _form.KeyPreview = true;
            _form.KeyDown += Form_KeyDown;

            foreach (var atajo in _atajosPorControl)
                atajo.Control.KeyDown += Control_KeyDown;
        }

        /// <summary>
        /// Intercepta teclas de diálogo (p. ej. Enter) para evitar doble ejecución.
        /// </summary>
        public bool TryProcessDialogKey(Keys keyData, Control activeControl)
        {
            if (activeControl == null)
                return false;

            Keys tecla = keyData & Keys.KeyCode;

            foreach (var atajo in _atajosDialogo)
            {
                if (atajo.Tecla == tecla && EsMismoControlOFoco(atajo.Control, activeControl))
                {
                    Ejecutar(atajo.Accion);
                    return true;
                }
            }

            return false;
        }

        private static bool EsMismoControlOFoco(Control registrado, Control activo)
        {
            if (registrado == activo)
                return true;

            return registrado.Contains(activo);
        }

        private void Ejecutar(Action accion)
        {
            if (_ejecutando)
                return;

            _ejecutando = true;
            try
            {
                accion();
            }
            finally
            {
                _ejecutando = false;
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                return;

            if (_atajosGlobales.TryGetValue(e.KeyCode, out Action accion))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Ejecutar(accion);
            }
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                return;

            var control = sender as Control;
            if (control == null)
                return;

            foreach (var atajo in _atajosPorControl)
            {
                if (atajo.Control == control && atajo.Tecla == e.KeyCode)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    Ejecutar(atajo.Accion);
                    return;
                }
            }
        }
    }
}
