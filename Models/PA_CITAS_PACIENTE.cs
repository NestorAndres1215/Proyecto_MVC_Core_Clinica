using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations; // Key

namespace AppMVC_Core_BDCLINICA.Models
{
    public class PA_CITAS_PACIENTE
    {
        [Key]
        public int nrocita { get; set; }
        public DateTime fecha { get; set; }
        public string codmed { get; set; }
        public string nommed { get; set; }
        public string nomesp { get; set; }
        public decimal pago { get; set; }
    }
}
