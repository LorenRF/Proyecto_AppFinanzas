using System;
using System.Collections.Generic;

namespace Proyecto_AppFinanzas.Models
{
    public partial class TipoGasto
    {
        public int Id { get; set; }
        public int? Tipo { get; set; }

        public virtual Gasto IdNavigation { get; set; }
    }
}
