using System;
using System.Collections.Generic;

namespace Proyecto_AppFinanzas.Models
{
    public partial class Gasto
    {
        public int IdGastos { get; set; }
        public int? IdUsuario { get; set; }
        public float? Monto { get; set; }
        public int? Tipo { get; set; }
        public DateOnly? Fecha { get; set; }
        public bool? Notificacion { get; set; }
        public bool? Automatico { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual TipoGasto TipoGasto { get; set; }
    }
}
