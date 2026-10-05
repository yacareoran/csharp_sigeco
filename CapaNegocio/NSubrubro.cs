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
    public class NSubrubro
    {
        //metodo buscar
        public static DataTable BuscarSubrubroxRubro(int id_rubro)
        {
            DSubrubro Obj = new DSubrubro();
            Obj.Rubro_id = id_rubro;
            return Obj.BuscarSubrubroxRubro(Obj);
        }
    }
}
