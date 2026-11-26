using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DExpedientes
    {
        // Propiedades completas según tu tabla "expedientes"
        public int Id_expediente { get; set; }
        public string Expediente_interno { get; set; }
        public string Caratula { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public int Sector_iniciador { get; set; }
        public int Sector_destino { get; set; }
        public decimal Monto_total { get; set; }
        public int Usuario_iniciador { get; set; }

        public DExpedientes() { }

        // Método Insertar con Transacción (Cabecera Expediente + Pedidos vinculados)
        public string Insertar(DExpedientes Expediente, List<DExpedientesPedido> DetallesPedidos)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlTransaction SqlTra = SqlCon.BeginTransaction();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "sp_insertarExpedientes";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdExpediente = new SqlParameter();
                ParIdExpediente.ParameterName = "@id_expediente";
                ParIdExpediente.SqlDbType = SqlDbType.Int;
                ParIdExpediente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdExpediente);

                SqlCmd.Parameters.Add("@expediente_interno", SqlDbType.VarChar, 50).Value = Expediente.Expediente_interno;
                SqlCmd.Parameters.Add("@caratula", SqlDbType.VarChar, 250).Value = Expediente.Caratula;
                SqlCmd.Parameters.Add("@fecha_creacion", SqlDbType.Date).Value = Expediente.Fecha_creacion;
                SqlCmd.Parameters.Add("@sector_iniciador", SqlDbType.Int).Value = Expediente.Sector_iniciador;
                SqlCmd.Parameters.Add("@sector_destino", SqlDbType.Int).Value = Expediente.Sector_destino;

                // Parámetro @monto_total con precisión (18, 2) para no perder los centavos
                SqlParameter ParMontoTotal = new SqlParameter("@monto_total", SqlDbType.Decimal);
                ParMontoTotal.Precision = 18;
                ParMontoTotal.Scale = 2;
                ParMontoTotal.Value = Expediente.Monto_total;
                SqlCmd.Parameters.Add(ParMontoTotal);

                SqlCmd.Parameters.Add("@usuario_iniciador", SqlDbType.Int).Value = Expediente.Usuario_iniciador;

                SqlCmd.ExecuteNonQuery();

                Expediente.Id_expediente = Convert.ToInt32(SqlCmd.Parameters["@id_expediente"].Value);
                rpta = "OK";

                // Insertamos cada pedido acumulado en la tabla intermedia expedientes_pedido
                foreach (DExpedientesPedido item in DetallesPedidos)
                {
                    item.Expediente_id = Expediente.Id_expediente;
                    rpta = item.Insertar(item, ref SqlCon, ref SqlTra);
                    if (rpta != "OK")
                    {
                        break;
                    }
                }

                if (rpta == "OK")
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        // Conservamos tu método BuscarxId original
        public DataTable BuscarxId(DExpedientes Expedientes)
        {
            DataTable DtResultado = new DataTable("expedientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sp_buscarExpedientesxId";

                SqlParameter ParIdexpedientes = new SqlParameter();
                ParIdexpedientes.ParameterName = "@id_expediente";
                ParIdexpedientes.SqlDbType = SqlDbType.Int;
                ParIdexpedientes.Value = Expedientes.Id_expediente;
                SqlCmd.Parameters.Add(ParIdexpedientes);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                return null;
            }
            return DtResultado;
        }
    }
}
