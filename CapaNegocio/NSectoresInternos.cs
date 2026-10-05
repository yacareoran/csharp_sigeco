using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NSectoresInternos
    {//inicio clase
     //metodo mostrar
        public static DataTable Mostrar()
        {
            DSectoresInternos Obj = new DSectoresInternos();
            return Obj.Mostrar();
        }
    }//fin clase
}
