using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using System.Net;

namespace CapaNegocio
{
    public class NSectores
    {
        //metodo buscar
        public static DataTable BuscarSectoresxOrganismo(int organismo_id)
        {
            DSectores Obj = new DSectores();
            Obj.Organismo_id = organismo_id;
            return Obj.BuscarSectoresxOrganismo(Obj);
        }
              
        //metodo mostrar
        public static DataTable Mostrar()
        {
            DSectores Obj = new DSectores();
            return Obj.Mostrar();
        }
        
    }
}
