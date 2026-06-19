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
            new TypeDocument { Code = "fact", Description = AppConfig.versionProfit2k8 ? "Pedidos" : "Factura" },
            new TypeDocument { Code = "n/cr", Description = AppConfig.versionProfit2k8 ? "Devoluciones" : "N/CR" },
            new TypeDocument { Code = "n/db", Description = AppConfig.versionProfit2k8 ? "N/DB de Pedidos" : "N/DB" },
            new TypeDocument { Code = "ivan", Description = "Ret. IVA a Fact."},
            new TypeDocument { Code = "ivap", Description = "Ret. IVA a N/CR"},
            new TypeDocument { Code = "islr", Description = "Ret. ISLR"}

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
            string? tipoDoc = selectedValue?.ToString();

            DateTime dDesde = dateStart.Value;
            DateTime dHasta = dateEnd.Value;

            var result = _profitService.BuscarDocumentosDigitales(tipoDoc, dDesde, dHasta);

            dgvDocs.AutoGenerateColumns = true;
            dgvDocs.DataSource = result.Select(doc =>
            {
                doc.Estado = bool.TryParse(doc.Estado, out bool estadoBool) ? (estadoBool ? "Procesado" : "Sin procesar") : doc.Estado;
                return doc;
            }).ToList();
        }

        private async void PrintDocument()
        {
            try
            {
                var documentosSeleccionados = DocumentosHelper.GetSelectedDocs(dgvDocs);

                // Filtrar documentos ya procesados
                var procesados = documentosSeleccionados
                    .Where(d =>
                    {
                        var row = dgvDocs.SelectedRows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => r.Cells["NroDoc"].Value?.ToString() == d.NroDoc
                                              && r.Cells["TipoDoc"].Value?.ToString() == d.TipoDoc);
                        return row?.Cells["Estado"].Value?.ToString() == "Procesado";
                    })
                    .ToList();

                if (procesados.Count == documentosSeleccionados.Count)
                {
                    MessageBox.Show("Los documentos seleccionados ya fueron procesados.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (procesados.Count > 0)
                {
                    var nros = string.Join(", ", procesados.Select(d => d.NroDoc));
                    MessageBox.Show($"Los siguientes documentos ya fueron procesados y serán omitidos:\n{nros}",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                documentosSeleccionados = documentosSeleccionados
                    .Except(procesados)
                    .ToList();

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

                string tipoSeleccionado = tiposSeleccionados.First();

                using var loadingForm = new Loading();
                loadingForm.Show();
                loadingForm.Refresh();

                DocumentosService documentos = new DocumentosService();

                if (tipoSeleccionado.ToUpperInvariant() is "IVAN" or "IVAP" or "ISLR")
                {
                    // ── Retenciones IVA / ISLR ──────────────────────────────────
                    var retenciones = new List<List<Models.Profit.RetencionProfit>>();
                    foreach (var doc in documentosSeleccionados)
                    {
                        var filas = _profitService.BuscarRetencion(doc.TipoDoc, doc.NroDoc);
                        if (filas?.Count > 0)
                            retenciones.Add(filas);
                    }
                    await documentos.CreateRetenciones(retenciones, tipoSeleccionado);
                }
                else
                {
                    // ── Facturas / Notas de Débito / Notas de Crédito ───────────
                    var docs = new List<Models.Profit.DocumentoProfit>();
                    foreach (var doc in documentosSeleccionados)
                    {
                        var documentoProfit = _profitService.BuscarDocDigital(doc.TipoDoc, doc.NroDoc);
                        if (documentoProfit != null)
                            docs.Add(documentoProfit);
                    }
                    await documentos.CreateDocument(docs);
                }

                SearchDocuments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar documentos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TableSettings()
        {
            if (dgvDocs.Columns.Count == 0)
                return;

            dgvDocs.Columns["TipoDoc"].Visible = false;
            dgvDocs.Columns["MontoBaseImponible"].Visible = false;
            dgvDocs.Columns["MontoIva"].Visible = false;

            dgvDocs.Columns["NroDoc"].HeaderText = "# Doc";
            dgvDocs.Columns["TipoDocAux"].HeaderText = "Tipo Doc.";
            dgvDocs.Columns["Estado"].HeaderText = "Estado";
            dgvDocs.Columns["FechaEmision"].HeaderText = "Emision";
            dgvDocs.Columns["ControlAsignado"].HeaderText = "# Control";
            dgvDocs.Columns["FechaEnvio"].HeaderText = "Fecha Envío";
            dgvDocs.Columns["Rif"].HeaderText = "RIF";
            dgvDocs.Columns["RazonSocial"].HeaderText = "Razón Social";
            dgvDocs.Columns["Moneda"].HeaderText = "Moneda";
            dgvDocs.Columns["Tasa"].HeaderText = "Tasa Cambio";
            dgvDocs.Columns["MontoTotalDocumento"].HeaderText = "Total Doc.";

            dgvDocs.Columns["NroDoc"].Name = "NroDoc";
            dgvDocs.Columns["TipoDocAux"].Name = "TipoDocAux";
            dgvDocs.Columns["Estado"].Name = "Estado";
            dgvDocs.Columns["FechaEmision"].Name = "FechaEmision";
            dgvDocs.Columns["ControlAsignado"].Name = "ControlAsignado";
            dgvDocs.Columns["FechaEnvio"].Name = "FechaEnvio";
            dgvDocs.Columns["Rif"].Name = "Rif";
            dgvDocs.Columns["RazonSocial"].Name = "RazonSocial";
            dgvDocs.Columns["Moneda"].Name = "Moneda";
            dgvDocs.Columns["Tasa"].Name = "Tasa";
            dgvDocs.Columns["MontoTotalDocumento"].Name = "MontoTotalDocumento";

            foreach (DataGridViewColumn col in dgvDocs.Columns)
            {
                col.Resizable = DataGridViewTriState.True;

                if (col.ValueType == typeof(int) ||
                    col.ValueType == typeof(long) ||
                    col.ValueType == typeof(float) ||
                    col.ValueType == typeof(double) ||
                    col.ValueType == typeof(decimal))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.DefaultCellStyle.Format = "N2";
                }
                else
                {
                    if (col.Name == "NroDoc")
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            ApplyStableColumnLayout();
        }

        private void ApplyStableColumnLayout()
        {
            dgvDocs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDocs.ScrollBars = ScrollBars.Both;

            SetFixedColumnWidth("viewLog", 34);
            SetFixedColumnWidth("NroDoc", 110);
            SetFixedColumnWidth("TipoDocAux", 110);
            SetFixedColumnWidth("Estado", 120);
            SetFixedColumnWidth("FechaEmision", 110);
            SetFixedColumnWidth("ControlAsignado", 110);
            SetFixedColumnWidth("FechaEnvio", 110);
            SetFixedColumnWidth("Rif", 130);
            SetFixedColumnWidth("Moneda", 80);
            SetFixedColumnWidth("Tasa", 105);
            SetFixedColumnWidth("MontoTotalDocumento", 130);

            var razonSocial = GetVisibleColumn("RazonSocial");
            if (razonSocial == null)
                return;

            int fixedWidth = 0;
            foreach (DataGridViewColumn col in dgvDocs.Columns)
            {
                if (!col.Visible || col.Name == "RazonSocial")
                    continue;

                fixedWidth += col.Width;
            }

            int availableWidth = dgvDocs.ClientSize.Width - fixedWidth - 24;
            int targetWidth = Math.Max(220, availableWidth);

            razonSocial.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            razonSocial.MinimumWidth = 220;
            razonSocial.Width = targetWidth;
        }

        private DataGridViewColumn? GetVisibleColumn(string name)
        {
            if (!dgvDocs.Columns.Contains(name))
                return null;

            var column = dgvDocs.Columns[name];
            if (column == null)
                return null;

            return column.Visible ? column : null;
        }

        private void SetFixedColumnWidth(string name, int width)
        {
            var column = GetVisibleColumn(name);
            if (column == null)
                return;

            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.MinimumWidth = width;
            column.Width = width;
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
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
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
            TableSettings();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            SearchDocuments();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            SearchDocuments();
        }

        private void dgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var column = dgvDocs.Columns[e.ColumnIndex];
            if (column.Name != "Estado")
                return;

            string estado = e.Value?.ToString()?.Trim() ?? string.Empty;

            e.CellStyle.SelectionForeColor = Color.White;

            if (estado.Equals("Procesado", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = Color.FromArgb(223, 240, 216);
                e.CellStyle.ForeColor = Color.FromArgb(47, 111, 58);
                e.CellStyle.SelectionBackColor = Color.FromArgb(76, 175, 80);
                return;
            }

            if (estado.Equals("Sin procesar", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 243, 205);
                e.CellStyle.ForeColor = Color.FromArgb(133, 100, 4);
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 193, 7);
                return;
            }

            e.CellStyle.BackColor = Color.FromArgb(233, 236, 239);
            e.CellStyle.ForeColor = Color.FromArgb(73, 80, 87);
            e.CellStyle.SelectionBackColor = Color.FromArgb(108, 117, 125);
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

        private void dgvDocs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!dgvDocs.IsHandleCreated) return;
            TableSettings();
        }
    }
}