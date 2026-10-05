using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DBitacora
    {
        private int _Id_bitacora;
        private int _Legajo;
        private DateTime _Fecha;
        private DateTime _Hora;
        private int _Accion_id;
        private string _Detalle;
        private string _Observacion;

        public int Id_bitacora
        {
            get
            {
                return _Id_bitacora;
            }

            set
            {
                _Id_bitacora = value;
            }
        }

        public int Legajo
        {
            get
            {
                return _Legajo;
            }

            set
            {
                _Legajo = value;
            }
        }


        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public DateTime Hora
        {
            get
            {
                return _Hora;
            }

            set
            {
                _Hora = value;
            }
        }

        public int Accion_id
        {
            get
            {
                return _Accion_id;
            }

            set
            {
                _Accion_id = value;
            }
        }

        public string Detalle
        {
            get
            {
                return _Detalle;
            }

            set
            {
                _Detalle = value;
            }
        }

        public string Observacion
        {
            get
            {
                return _Observacion;
            }

            set
            {
                _Observacion = value;
            }
        }

        public DBitacora() { }

        public DBitacora(int id_bitacora, long clave_personal, long prontuario, int legajo, int dni_usuario, int dedo, DateTime fecha, DateTime hora, int accion_id, string detalle, string observacion)
        {
            this.Id_bitacora = id_bitacora;
            this.Legajo = legajo;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Accion_id = accion_id;
            this.Detalle = detalle;
            this.Observacion = observacion;
        }

        public string Insertar_bitacora(DBitacora Obj)
        {//inicio metodo IHC
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spInsertarBitacora";

                //parametros
                SqlParameter ParLegajo = new SqlParameter();
                ParLegajo.SqlDbType = SqlDbType.Int;
                ParLegajo.ParameterName = "@legajo";
                ParLegajo.Value = Obj.Legajo;
                SqlCmd.Parameters.Add(ParLegajo);


                SqlParameter ParAccion_id = new SqlParameter();
                ParAccion_id.SqlDbType = SqlDbType.Int;
                ParAccion_id.ParameterName = "@accion_id";
                ParAccion_id.Value = Obj.Accion_id;
                SqlCmd.Parameters.Add(ParAccion_id);

               
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.ParameterName = "@observacion";
                ParObservacion.Value = Obj.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Error al Insertar el registro de bitacora";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;




        }//fin metodo IHC
    }
}
