using FacturacionDigital_SIGECE.Models.Facturas;
using FacturacionDigital_SIGECE.Services;
using FacturacionDigital_SIGECE.Services.Common;
using FacturacionDigital_SIGECE.AppUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wise.Desktop.Helpers;
using WISE.Models.Auth;

namespace FacturacionDigital_SIGECE.Forms
{
    public partial class Main : Form
    {
        private AuthService _authService = new AuthService();
        public Main()
        {
            InitializeComponent();

        }

        private void createFactura()
        {

        }

        private void send_Click(object sender, EventArgs e)
        {
            //createFactura();
        }
    }
}