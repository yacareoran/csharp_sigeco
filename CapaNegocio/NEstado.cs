using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NEstado
    {
        //metodo mostrar
        public static DataTable Mostrar()
        {
            DEstado Obj = new DEstado();
            return Obj.Mostrar();
        }
    }
}
