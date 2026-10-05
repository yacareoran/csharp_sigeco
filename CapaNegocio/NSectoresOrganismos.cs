using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NSectoresOrganismos
    {
        //metodo retornar numero de transaccion 
        public static int BuscarIdSectoresOrganismos(int organismo_id, int sectores_id)
        {
            DSectoresOrganismos Obj = new DSectoresOrganismos();
            Obj.Organismo_id = organismo_id;
            Obj.Sectores_id = sectores_id;
            
            return Obj.BuscarIdSectoresOrganismos(Obj);
        }
    }
}
