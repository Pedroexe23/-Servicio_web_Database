
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Servicio_web_Model.DAL
{
    public class EstacionDAL
    {
        public Estacion_ServerEntities1 entities = new Estacion_ServerEntities1();
        public void agregarestacion(Estacion c)
        {
            entities.Estacion.Add(c);
            try
            {
                entities.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
        }
        public List<Estacion> GetEstacions()
        {
            return entities.Estacion.ToList();
        }

        public void Eliminar(String Rut)
        {
            Estacion estacion= entities.Estacion.Find(Rut);
            entities.Estacion.Remove(estacion);
            entities.SaveChanges();
        }
           
    }
}
