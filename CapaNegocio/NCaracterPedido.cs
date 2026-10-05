using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCaracterPedido
    {
        //metodo mostrar
        public static DataTable Mostrar()
        {
            DCaracterPedido Obj = new DCaracterPedido();
            return Obj.Mostrar();
        }
    }
}
