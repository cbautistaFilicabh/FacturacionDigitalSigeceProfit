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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LogIn();
        }

        private async void LogIn()
        {
            if (String.IsNullOrEmpty(AppConfig.SessionToken))
            {
                var request = new LoginRequestDto
                {
                    email = AppConfig.Email,
                    password = AppConfig.Password
                };

                var result = await _authService.LoginAsync(request);

                if (result.Success && result.Data != null)
                {
                    MessageHelper.ShowSuccess("Inicio de sesión exitoso.");
                }
            }
        }

        //private void createFactura()
        //{
        //    var data = JsonSerializer.Deserialize<FacturasRequestDto>(txtInput.Text);

        //    var _facturaService = new FacturasService();

        //    var result = _facturaService.CreateAsync(data);

        //    if (result != null)
        //    {
        //        var options = new JsonSerializerOptions { WriteIndented = true };
        //        var jsonString = JsonSerializer.Serialize(result, options);
        //        salida.Text = jsonString;
        //        MessageHelper.ShowSuccess("Factura creada exitosamente.");
        //    }


        //}

        private void send_Click(object sender, EventArgs e)
        {
            //createFactura();
        }
    }
}