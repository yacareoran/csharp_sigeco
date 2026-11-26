using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NExpedientesPedido
    {
        //metodo insertar que llama a Insertar de la clase DExpedientesPedido
        public static string Insertar(int pedido_id, int expediente_id, DateTime fecha_expedientes_pedido, bool is_activo)
        {
            DExpedientesPedido Obj = new DExpedientesPedido();
            Obj.Pedido_id = pedido_id;
            Obj.Expediente_id = expediente_id;
            Obj.Fecha_expedientes_pedido = fecha_expedientes_pedido;
            Obj.Is_activo = is_activo;
            return Obj.Insertar(Obj);
        }
    }
}
