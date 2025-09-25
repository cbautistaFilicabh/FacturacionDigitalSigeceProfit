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
using FacturacionDigital_SIGECE.Controls;
using FacturacionDigital_SIGECE.Helpers;

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

            DateTime dDesde = dateStart.Value;
            DateTime dHasta = dateEnd.Value;

            var result = _profitService.BuscarDocumentosDigitales(tipoDoc, dDesde, dHasta);

            dgvDocs.DataSource = result.Select(doc =>
            {
                doc.Estado = bool.TryParse(doc.Estado, out bool estadoBool) ? (estadoBool ? "Procesado" : "Sin procesar") : doc.Estado;
                return doc;
            }).ToList();

            TableColumnsSize();
        }

        private void PrintDocument()
        {
            try
            {
                var docs = new List<DocumentoProfit>();
                var documentosSeleccionados = DocumentosHelper.GetSelectedDocs(dgvDocs);

                var tiposSeleccionados = documentosSeleccionados
                    .Select(d => d.TipoDoc)
                    .Distinct()
                    .ToList();

                if (tiposSeleccionados.Count > 1)
                {
                    MessageBox.Show("No se pueden procesar documentos de distintos tipos. Selecciona solo un tipo de documento.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (var doc in documentosSeleccionados)
                {
                    var documentoProfit = _profitService.BuscarDocDigital(doc.TipoDoc, doc.NroDoc);
                    if (documentoProfit != null)
                        docs.Add(documentoProfit);
                }

                string tipoSeleccionado = tiposSeleccionados.First();

                DocumentosService documentos = new DocumentosService();
                documentos.CreateDocument(docs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar documentos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TableColumnsSize()
        {
            int sum = 0;
            foreach (DataGridViewColumn col in dgvDocs.Columns)
            {
                if (col.Visible)
                    sum += col.Width;
            }

            dgvDocs.AutoSizeColumnsMode = sum > DisplayRectangle.Width - 20 ? DataGridViewAutoSizeColumnsMode.ColumnHeader : DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var documentosSeleccionados = DocumentosHelper.GetSelectedDocs(dgvDocs);
            if (!documentosSeleccionados.Any())
                return;

            var numberdocs = documentosSeleccionados.Select(d => d.NroDoc).ToList();
            string tipoDoc = documentosSeleccionados.First().TipoDoc;
            bool documentoAutorizado = false;

            foreach (var doc in documentosSeleccionados)
            {
                var estados = _profitService.ListarEstadoDocumento(doc.TipoDoc, doc.NroDoc);
                if (estados != null && estados.Any(e => e.Autorizado))
                {
                    documentoAutorizado = true;
                    break;
                }
            }

            if (documentoAutorizado)
            {
                MessageBox.Show("Este documento ya está procesado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                "¿Está seguro que desea imprimir el documento: " + string.Join(", ", numberdocs),
                "Atención",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                PrintDocument();
            }
        }

        private void cmbTypeDoc_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchDocuments();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            lblTitle.MinimumSize = new Size(topbar.DisplayRectangle.Width, 0);
            TableColumnsSize();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            SearchDocuments();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            SearchDocuments();
        }

        private void dgvDocs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var column = dgvDocs.Columns[e.ColumnIndex];
                if (column.Name == "viewLog")
                {
                    e.PaintBackground(e.CellBounds, true);

                    Image? icon = Properties.Resources.visibility_50_light;

                    if (icon != null)
                    {
                        int iconSize = 22; // Tamaño fijo
                        int iconX = e.CellBounds.X + (e.CellBounds.Width - iconSize) / 2;
                        int iconY = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;
                        Rectangle iconRect = new Rectangle(iconX, iconY, iconSize, iconSize);
                        e.Graphics.DrawImage(icon, iconRect);
                    }

                    e.Handled = true;
                    column.MinimumWidth = 30;
                }
            }


        }

        private void dgvDocs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var colName = dgvDocs.Columns[e.ColumnIndex].Name;

            if (colName == "viewLog")
            {
                var numDoc = dgvDocs.Rows[e.RowIndex].Cells["NroDoc"].Value?.ToString() ?? string.Empty;
                var typeDoc = dgvDocs.Rows[e.RowIndex].Cells["TipoDoc"].Value?.ToString() ?? string.Empty;

                var result = _profitService.ListarEstadoDocumento(typeDoc, numDoc);

                if (result != null && result.Count > 0)
                {
                    LogView logView = new LogView(result);
                    logView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontraron registros para el documento seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;

        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            SearchDocuments();
        }
    }
}