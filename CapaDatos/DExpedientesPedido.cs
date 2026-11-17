using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DExpedientesPedido
    {
        public int Id_expedientes_pedido { get; set; }
        public int Pedido_id { get; set; }
        public int Expediente_id { get; set; }
        public DateTime Fecha_expedientes_pedido { get; set; }
        public bool Is_activo { get; set; }

        public string Insertar(DExpedientesPedido Detalle, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "sp_insertarExpedientePedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("@pedido_id", SqlDbType.Int).Value = Detalle.Pedido_id;
                SqlCmd.Parameters.Add("@expediente_id", SqlDbType.Int).Value = Detalle.Expediente_id;
                SqlCmd.Parameters.Add("@fecha_expedientes_pedido", SqlDbType.Date).Value = Detalle.Fecha_expedientes_pedido;
                SqlCmd.Parameters.Add("@is_activo", SqlDbType.Bit).Value = Detalle.Is_activo;

                SqlCmd.ExecuteNonQuery();
                rpta = "OK";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}