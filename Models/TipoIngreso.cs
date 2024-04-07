using System;
using System.Collections.Generic;

namespace Proyecto_AppFinanzas.Models
{
    public partial class TipoIngreso
    {
        public int Id { get; set; }
        public int? Tipo { get; set; }

        public virtual Ingreso IdNavigation { get; set; }
    }
}
