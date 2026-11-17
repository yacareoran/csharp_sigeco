using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public class NExpedientes
    {
        public static string Insertar(string expediente_interno, string caratula, DateTime fecha_creacion,
                                      int sector_iniciador, int sector_destino, decimal monto_total,
                                      int usuario_iniciador, DataTable dtPedidos)
        {
            DExpedientes Obj = new DExpedientes();
            Obj.Expediente_interno = expediente_interno;
            Obj.Caratula = caratula;
            Obj.Fecha_creacion = fecha_creacion;
            Obj.Sector_iniciador = sector_iniciador;
            Obj.Sector_destino = sector_destino;
            Obj.Monto_total = monto_total;
            Obj.Usuario_iniciador = usuario_iniciador;

            List<DExpedientesPedido> detalles = new List<DExpedientesPedido>();
            foreach (DataRow row in dtPedidos.Rows)
            {
                DExpedientesPedido detalle = new DExpedientesPedido();
                detalle.Pedido_id = Convert.ToInt32(row["pedido_id"]);
                detalle.Fecha_expedientes_pedido = fecha_creacion;
                detalle.Is_activo = true; // Lo marcamos activo por defecto al crearlo
                detalles.Add(detalle);
            }

            return Obj.Insertar(Obj, detalles);
        }
    }
}
