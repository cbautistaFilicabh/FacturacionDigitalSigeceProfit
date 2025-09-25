using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.Helpers.Transitions;
using FacturacionDigital_SIGECE.Models.Profit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionDigital_SIGECE.Controls
{
    public partial class LogView : Form
    {
        public LogView(List<EstadoDocumento> log)
        {
            InitializeComponent();
            LoadLog(log);
        }

        private void LoadLog(List<EstadoDocumento> log)
        {
            mainBox.Controls.Clear();

            var reverseList = log.AsEnumerable().Reverse();

            foreach (var item in reverseList)
            {
                FlowLayoutPanel panel = new()
                {
                    AutoSize = true,
                    Width = mainBox.DisplayRectangle.Width - 20,
                    MaximumSize = new Size(mainBox.DisplayRectangle.Width - 20, 0),
                    Name = "panelItem",
                    Margin = new Padding(0, 0, 0, 8)
                };

                BunifuLabel lblFechaAsignacion = new()
                {
                    AutoSize = true,
                    Width = panel.DisplayRectangle.Width,
                    MaximumSize = new Size(panel.DisplayRectangle.Width, 0),
                    MinimumSize = new Size(panel.DisplayRectangle.Width, 0),
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Black,
                    Location = new Point(3, 25),
                    Name = "lblFechaAsignacion",
                    TabStop = false,
                    Text = item.FechaAsignacion.ToString(),
                    TextFormat = BunifuLabel.TextFormattingOptions.Default,
                };

                BunifuLabel lblNumeroFactura = new()
                {
                    AutoSize = true,
                    MaximumSize = new Size(panel.DisplayRectangle.Width, 0),
                    MinimumSize = new Size(panel.DisplayRectangle.Width, 0),
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Black,
                    Location = new Point(3, 135),
                    Name = "lblNumeroFactura",
                    TabStop = false,
                    Text = $"N. Factura Asignado: {item.NumeroFacturaAsignado ?? "-"}",
                    TextFormat = BunifuLabel.TextFormattingOptions.Default
                };

                BunifuLabel lblId = new()
                {
                    AutoSize = true,
                    MaximumSize = new Size(panel.DisplayRectangle.Width, 0),
                    MinimumSize = new Size(panel.DisplayRectangle.Width, 0),
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Black,
                    Location = new Point(3, 25),
                    Name = "lblId",
                    TabStop = false,
                    Text = $"Id: {item.Id}",
                    TextFormat = BunifuLabel.TextFormattingOptions.Default
                };

                BunifuLabel lblAutorizado = new()
                {
                    AutoSize = true,
                    MaximumSize = new Size(panel.DisplayRectangle.Width, 0),
                    MinimumSize = new Size(panel.DisplayRectangle.Width, 0),
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = !item.Autorizado ? Color.Red : Color.Black,
                    Location = new Point(3, 47),
                    Name = "lblAutorizado",
                    TabStop = false,
                    Text = $"Estatus: {(item.Autorizado ? "Procesado" : "No Procesado")}",
                    TextFormat = BunifuLabel.TextFormattingOptions.Default
                };

                BunifuLabel lblNroDoc = new()
                {
                    AutoSize = true,
                    MaximumSize = new Size(panel.DisplayRectangle.Width, 0),
                    MinimumSize = new Size(panel.DisplayRectangle.Width, 0),
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Black,
                    Location = new Point(3, 91),
                    Name = "lblNroDoc",
                    TabStop = false,
                    Text = $"Nro. Documento Asignado: {item.nro_doc ?? "-"}",
                    TextFormat = BunifuLabel.TextFormattingOptions.Default
                };

                BunifuLabel lblSerie = new()
                {
                    AutoSize = true,
                    MaximumSize = new Size(panel.DisplayRectangle.Width, 0),
                    MinimumSize = new Size(panel.DisplayRectangle.Width, 0),
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Black,
                    Location = new Point(3, 113),
                    Name = "lblSerie",
                    TabStop = false,
                    Text = $"Serie: {item.Serie ?? "-"}",
                    TextFormat = BunifuLabel.TextFormattingOptions.Default
                };

                BunifuLabel lblNumeroControl = new()
                {
                    AutoSize = true,
                    MaximumSize = new Size(panel.DisplayRectangle.Width, 0),
                    MinimumSize = new Size(panel.DisplayRectangle.Width, 0),
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Black,
                    Location = new Point(3, 157),
                    Name = "lblNumeroControl",
                    TabStop = false,
                    Text = $"Nro. Control: {item.NumeroControlAsignado ?? "-"}",
                    TextFormat = BunifuLabel.TextFormattingOptions.Default
                };

                BunifuLabel lblComentarios = new()
                {
                    AutoSize = true,
                    MaximumSize = new Size(panel.DisplayRectangle.Width, 0),
                    MinimumSize = new Size(panel.DisplayRectangle.Width, 0),
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Black,
                    Location = new Point(3, 179),
                    Name = "lblComentarios",
                    TabStop = false,
                    Text = $"Detalles: {Environment.NewLine} {item.Comentarios ?? "-"}",
                    TextFormat = BunifuLabel.TextFormattingOptions.Default
                };

                BunifuLabel lblUrlConsulta = new()
                {
                    AutoSize = true,
                    MaximumSize = new Size(panel.DisplayRectangle.Width, 0),
                    MinimumSize = new Size(panel.DisplayRectangle.Width, 0),
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Black,
                    Location = new Point(3, 201),
                    Name = "lblUrlConsulta",

                    TabStop = false,
                    Text = $"URL: {item.URLConsulta ?? "-"}",
                    TextFormat = BunifuLabel.TextFormattingOptions.Default
                };

                BunifuSeparator separator = new()
                {
                    LineThickness = 1,
                    Margin = new Padding(0),
                    Name = "separator",
                    Size = new Size(panel.DisplayRectangle.Width, 14),
                    TabIndex = 0
                };

                panel.Controls.Add(lblFechaAsignacion);
                panel.Controls.Add(lblNroDoc);
                panel.Controls.Add(lblAutorizado);
                //panel.Controls.Add(lblSerie);

                if (item.Autorizado)
                {
                    panel.Controls.Add(lblNumeroFactura);
                    panel.Controls.Add(lblNumeroControl);
                }
                else
                {
                    panel.Controls.Add(lblComentarios);
                }

                //panel.Controls.Add(lblId);
                //panel.Controls.Add(lblUrlConsulta);

                mainBox.Controls.Add(panel);
                mainBox.Controls.Add(separator);

                if (item.Autorizado)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is BunifuLabel lbl)
                        {
                            lbl.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
