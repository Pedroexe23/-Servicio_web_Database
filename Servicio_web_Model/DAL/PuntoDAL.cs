
using Servicio_web_Model.DTO;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DAL
{
    public class PuntoDAL
    {
        Estacion_ServerEntities1 entities = new Estacion_ServerEntities1();
        public void CrearPunto(Puntocarga p)
        {
            entities.Puntocarga.Add(p);
            entities.SaveChanges();


        }
        public void editar(Puntocarga p)
        {
            var Connection = ConfigurationManager.ConnectionStrings["EstacionSQL"].ConnectionString;
            using (SqlConnection sql = new SqlConnection(Connection))
            {
                sql.Open();
                string cadena = " update PuntoCarga set Capacidadmaxima=" + p.Capacidadmaxima + ", Fechavencimiento='" + p.Fechavencimiento + "',Tipo=" + p.Tipo + " where ID=" + p.ID + "  and Punto_rut='" + p.Punto_rut + "';";
                SqlCommand command = new SqlCommand(cadena, sql);
                int cant = command.ExecuteNonQuery();
                sql.Close();
            }
        }
        public List<Puntocarga> GetPuntoCargas()
        {
            return entities.Puntocarga.ToList();
        }

    }
}
