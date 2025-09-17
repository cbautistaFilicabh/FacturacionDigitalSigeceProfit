using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wise.Desktop.Helpers
{
    public static class MessageHelper
    {
        public static void ShowInfo(string msg, string titulo = "Información")
        {
            MessageBox.Show(msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string msg, string titulo = "Error")
        {
            MessageBox.Show(msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarning(string msg, string titulo = "Advertencia")
        {
            MessageBox.Show(msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowSuccess(string msg, string titulo = "Éxito")
        {
            // Si luego se puede Snackbar de Bunifu o similar, aquí lo cambias
            MessageBox.Show(msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
