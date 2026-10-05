using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NBitacora
    {
        //insertar bitacora de huellas
        public static string Insertar_bitacora(int legajo, int accion_id, string observacion)
        {
            DBitacora Obj = new DBitacora();
            Obj.Legajo = legajo;
            Obj.Accion_id = accion_id;
            Obj.Observacion = observacion;
            return Obj.Insertar_bitacora(Obj);
        }
    }
}
