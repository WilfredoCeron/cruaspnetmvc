//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Registro.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class alm_alumno
    {
        public int alm_id { get; set; }
        public string alm_codigo { get; set; }
        public string alm_nombre { get; set; }
        public Nullable<int> alm_edad { get; set; }
        public string alm_sexo { get; set; }
        public Nullable<int> alm_id_grd { get; set; }
        public string alm_descripcion { get; set; }
    
        public virtual grd_grado grd_grado { get; set; }
    }
}
