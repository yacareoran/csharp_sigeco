using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DExpedientes
    {//inicio clase
        private int _Id_expediente;
        private string _Numero_expediente;
        private string _Caratula;
        private DateTime _Fecha_creacion;

        public int Id_expediente
        {
            get
            {
                return _Id_expediente;
            }

            set
            {
                _Id_expediente = value;
            }
        }

        public string Numero_expediente
        {
            get
            {
                return _Numero_expediente;
            }

            set
            {
                _Numero_expediente = value;
            }
        }
        public string Caratula
        {
            get
            {
                return _Caratula;
            }

            set
            {
                _Caratula = value;
            }
        }
        public DateTime Fecha_creacion
        {
            get
            {
                return _Fecha_creacion;
            }

            set
            {
                _Fecha_creacion = value;
            }
        }
        public DExpedientes()
        {

        }
        public DExpedientes(int id_expediente, string numero_expediente, string caratula, DateTime fecha_creacion)
        {
            this.Id_expediente = id_expediente;
            this.Numero_expediente = numero_expediente;
            this.Caratula = caratula;
            this.Fecha_creacion = fecha_creacion;
        }
        //metodo insertar   
        public string Insertar(DExpedientes Expedientes)
        {//inicio insertar
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_expedientes";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros
                SqlParameter ParId_Expediente = new SqlParameter();
                ParId_Expediente.ParameterName = "@id_expediente";
                ParId_Expediente.SqlDbType = SqlDbType.Int;
                ParId_Expediente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_Expediente);

                SqlParameter ParNumeroExpediente = new SqlParameter();
                ParNumeroExpediente.ParameterName = "@numero_expediente";
                ParNumeroExpediente.SqlDbType = SqlDbType.VarChar;
                ParNumeroExpediente.Size = 50;
                ParNumeroExpediente.Value = Expedientes.Numero_expediente;
                SqlCmd.Parameters.Add(ParNumeroExpediente);

                SqlParameter ParCaratula = new SqlParameter();
                ParCaratula.ParameterName = "@caratula";
                ParCaratula.SqlDbType = SqlDbType.VarChar;
                ParCaratula.Size = 50;
                ParCaratula.Value = Expedientes.Numero_expediente;
                SqlCmd.Parameters.Add(ParNumeroExpediente);

                SqlParameter ParFecha_Creacion = new SqlParameter();
                ParFecha_Creacion.ParameterName = "@fecha_creacion";
                ParFecha_Creacion.SqlDbType = SqlDbType.VarChar;
                ParFecha_Creacion.Size = 250;
                ParFecha_Creacion.Value = Expedientes.Fecha_creacion;
                SqlCmd.Parameters.Add(ParFecha_Creacion);

                //ejecutar el codigo
                //rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "EL REGISTRO NO HA SIDO AGREGADO";

                var resultado = SqlCmd.ExecuteNonQuery();

                if (resultado == 1)
                {
                    rpta = Convert.ToString(SqlCmd.Parameters["@id_expediente"].Value.ToString());
                }
                else
                {
                    rpta = "no_insertado";
                }
            }
            catch (Exception ex)
            {

                rpta = ex.Message + ex.StackTrace;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }

            }
            return rpta;
        }

        //metodo buscar x Id_pedido
        public DataTable BuscarxId(DExpedientes Expedientes)
        {//inicio buscar
            DataTable DtResultado = new DataTable("expedientes");
            List<DExpedientes> listaExpedientes = new List<DExpedientes>();
            DExpedientes dExpedientesAux = new DExpedientes();
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

        }//fin metodo buscar 
    }//fin clase
}
