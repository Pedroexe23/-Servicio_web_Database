//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicio_web_Model.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Puntocarga
    {
        public int ID { get; set; }
        public int Tipo { get; set; }
        public int Capacidadmaxima { get; set; }
        public System.DateTime Fechavencimiento { get; set; }
        public string Punto_rut { get; set; }
    
        public virtual Estacion Estacion { get; set; }
    }
}
