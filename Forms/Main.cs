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
using FacturacionDigital_SIGECE.Class;
using FacturacionDigital_SIGECE.Models.Profit;

namespace FacturacionDigital_SIGECE.Forms
{
    public partial class Main : Form
    {
        private readonly ProfitService _profitService = new ProfitService();
        List<TypeDocument> Documents = new List<TypeDocument>
        {
            new TypeDocument { Code = "todos", Description = "Todos" },
            new TypeDocument { Code = "fact", Description = "Factura" },
            new TypeDocument { Code = "n/cr", Description = "Nota de Crédito" },
            new TypeDocument { Code = "n/db", Description = "Nota de Débito" }
        };

        public Main()
        {
            InitializeComponent();
            lblTitle.MinimumSize = new Size(topbar.DisplayRectangle.Width, 0);
            SetOptionsDocuments();
            SearchDocuments();
        }

        private void SetOptionsDocuments()
        {
            cmbTypeDoc.DataSource = Documents;
            cmbTypeDoc.DisplayMember = "Description";
            cmbTypeDoc.ValueMember = "Code";
            cmbTypeDoc.SelectedIndex = 0;
        }

        private void SearchDocuments()
        {
            var selectedValue = cmbTypeDoc.SelectedValue;
            string? tipoDoc = selectedValue?.ToString() ?? null;

            var result = _profitService.BuscarDocumentosDigitales(tipoDoc, dateStart.Value, dateEnd.Value);
            dgvDocs.DataSource = result;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var docs = new List<FacturaProfit>();

            foreach (DataGridViewRow row in dgvDocs.SelectedRows)
            {
                string docNum = row.Cells["NroDoc"].Value.ToString() ?? string.Empty;
                var factura = _profitService.BuscarFacturaDigital(docNum);
                if (factura != null)
                {
                    docs.Add(factura);
                }
            }

            var selectedValue = cmbTypeDoc.SelectedValue;
            string? tipoDoc = selectedValue?.ToString() ?? null;
            DocumentosService documentos = new DocumentosService();
            documentos.CreateDocument(tipoDoc, docs);
        }

        private void cmbTypeDoc_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchDocuments();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            lblTitle.MinimumSize = new Size(topbar.DisplayRectangle.Width, 0);
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            SearchDocuments();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            SearchDocuments();
        }
    }
}