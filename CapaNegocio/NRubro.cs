using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NRubro
    {
        //metodo mostrar
        public static DataTable Mostrar()
        {
            DRubro Obj = new DRubro();
            return Obj.Mostrar();
        }
    }
}
