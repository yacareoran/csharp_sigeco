using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTipoContratacion
    {//inicio clase
     //metodo mostrar
        public static DataTable Mostrar()
        {
            DTipoContratacion Obj = new DTipoContratacion();
            return Obj.Mostrar();
        }
    }//fin clase
}
