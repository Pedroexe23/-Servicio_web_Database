
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio_web_Model.DAL
{
    public class RegionDAL
    {
        public Estacion_ServerEntities1 entities = new Estacion_ServerEntities1();

        public List<Region> GetRegiones()
        {
            return entities.Region.ToList();
        }
    }
}
