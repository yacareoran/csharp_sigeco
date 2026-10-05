using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NUnidadMedida
    {

        //metodo mostrar
        public static DataTable Mostrar()
        {
            DUnidadMedida Obj = new DUnidadMedida();
            return Obj.Mostrar();
        }

    }
}
