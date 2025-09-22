using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionDigital_SIGECE.Models.Profit
{
    public class EstadoDocumento
    {
        public int Id { get; set; }

        public bool Autorizado { get; set; }

        public string? co_tipo_doc { get; set; }

        public string? nro_doc { get; set; }

        public string? Serie { get; set; }

        public string? NumeroFacturaAsignado { get; set; }

        public string? NumeroControlAsignado { get; set; }

        public string? Comentarios { get; set; }

        public DateTime? FechaAsignacion { get; set; }

        public string? URLConsulta { get; set; }
    }
}