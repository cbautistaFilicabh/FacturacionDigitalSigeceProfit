using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionDigital_SIGECE.Models
{
    public class GravamenDto
    {
        [Required]
        [MaxLength(20)]
        public required decimal baseImponible { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal alicuota { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal montoAlicuota { get; set; }
    }
}
