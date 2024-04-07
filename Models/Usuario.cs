using System;
using System.Collections.Generic;

namespace Proyecto_AppFinanzas.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Gastos = new HashSet<Gasto>();
            Ingresos = new HashSet<Ingreso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public bool? Validado { get; set; }
        public int? Codigo { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<Gasto> Gastos { get; set; }
        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
