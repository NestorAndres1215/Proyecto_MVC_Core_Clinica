using System;
using System.Collections.Generic;

#nullable disable

namespace AppMVC_Core_BDCLINICA.Models
{
    public partial class Medico
    {
        public Medico()
        {
            Cita = new HashSet<Cita>();
        }

        public string Codmed { get; set; }
        public string Codesp { get; set; }
        public string Nommed { get; set; }
        public int? AnioColegio { get; set; }
        public string Coddis { get; set; }
        public int? Estado { get; set; }

        public virtual Distrito CoddisNavigation { get; set; }
        public virtual Especialidad CodespNavigation { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
