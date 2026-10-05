using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSesion
    {
        private int _clave;
        private int _dni_usuario;
        private DateTime _inicio;
        private DateTime _fin;
        private string _ip;
        private string _equipo;
        private DateTime _fecha_buscar;

        public int Clave
        {
            get
            {
                return _clave;
            }

            set
            {
                _clave = value;
            }
        }

        public int Dni_usuario
        {
            get
            {
                return _dni_usuario;
            }

            set
            {
                _dni_usuario = value;
            }
        }

        public DateTime Inicio
        {
            get
            {
                return _inicio;
            }

            set
            {
                _inicio = value;
            }
        }

        public DateTime Fin
        {
            get
            {
                return _fin;
            }

            set
            {
                _fin = value;
            }
        }

        public string Ip
        {
            get
            {
                return _ip;
            }

            set
            {
                _ip = value;
            }
        }

        public string Equipo
        {
            get
            {
                return _equipo;
            }

            set
            {
                _equipo = value;
            }
        }

        public DateTime Fecha_buscar
        {
            get
            {
                return _fecha_buscar;
            }

            set
            {
                _fecha_buscar = value;
            }
        }

        //constructores
        //constructor vacio
        public DSesion() { }
        //constructor con parametros
        public DSesion(int clave, int dni, DateTime inicio, DateTime fin, string ip, string equipo)
        {
            this.Clave = clave;
            this.Dni_usuario = dni;
            this.Inicio = inicio;
            this.Fin = fin;
            this.Ip = ip;
            this.Equipo = equipo;
        }

        //metodos
        public string Inicio_Sesion(DSesion Sesion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spinsertar_sesion";

                SqlParameter ParClave = new SqlParameter();
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.ParameterName = "@clave";
                ParClave.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParClave);

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;
                //ParId.Value = Convert.ToInt32(ParClave);
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParDni = new SqlParameter();
                ParDni.SqlDbType = SqlDbType.Int;
                ParDni.ParameterName = "@dni_usuario";
                ParDni.Value = Sesion.Dni_usuario;
                SqlCmd.Parameters.Add(ParDni);

                SqlParameter ParInicio = new SqlParameter();
                ParInicio.SqlDbType = SqlDbType.DateTime;
                ParInicio.ParameterName = "@inicio";
                ParInicio.Value = Sesion.Inicio;
                SqlCmd.Parameters.Add(ParInicio);

                SqlParameter ParFin = new SqlParameter();
                ParFin.ParameterName = "@fin";
                ParFin.SqlDbType = SqlDbType.DateTime;
                ParFin.Value = Sesion.Fin;
                SqlCmd.Parameters.Add(ParFin);

                SqlParameter ParIp = new SqlParameter();
                ParIp.ParameterName = "@ip";
                ParIp.SqlDbType = SqlDbType.VarChar;
                ParIp.Size = 50;
                ParIp.Value = Sesion.Ip;
                SqlCmd.Parameters.Add(ParIp);

                SqlParameter ParEquipo = new SqlParameter();
                ParEquipo.ParameterName = "@equipo";
                ParEquipo.SqlDbType = SqlDbType.VarChar;
                ParEquipo.Size = 50;
                ParEquipo.Value = Sesion.Equipo;
                SqlCmd.Parameters.Add(ParEquipo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "ERROR";

                if (rpta.Equals("OK"))
                {
                    rpta = Convert.ToString(SqlCmd.Parameters["@id"].Value.ToString());
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

        //metodo Mostrar
        public DataTable Mostrar()
        {//inicio mostrar
            DataTable DtResultado = new DataTable("sesiones");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_sesiones";

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);


            }
            catch (Exception)
            {

                DtResultado = null;
            }
            return DtResultado;


        }//fin mostrar

        //metodo buscar sesion por usuario
        public DataTable Buscar_X_Usuario(DSesion Sesion)
        {
            DataTable DtResultado = new DataTable("sesiones");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spbuscar_sesionxusuario";

                SqlParameter ParDni = new SqlParameter();
                ParDni.SqlDbType = SqlDbType.Int;
                ParDni.ParameterName = "dni_usuario";
                ParDni.Value = Sesion.Dni_usuario;
                SqlCmd.Parameters.Add(ParDni);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {

                DtResultado = null;
            }
            return DtResultado;
        }//fin buscar x usuario

        //metodo buscar por fecha
        public DataTable Buscar_X_Fecha(DSesion Sesion)
        {//inicio buscar por fecha
            SqlConnection SqlCon = new SqlConnection();
            DataTable DtResultado = new DataTable("sesiones");

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spbuscar_sesionxfecha";

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.ParameterName = "@fecha_buscar";
                ParFecha.Value = Sesion.Fecha_buscar;
                SqlCmd.Parameters.Add(ParFecha);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);




            }
            catch (Exception)
            {

                DtResultado = null;
            }

            return DtResultado;


        }//fin buscar por fecha

        //metodo finalizar sesion
        public string finalizar_sesion(DSesion Sesion)
        {//inicio metodo finalizar

            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spfinalizar_sesion";

                SqlParameter ParClave = new SqlParameter();
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.ParameterName = "@clave";
                ParClave.Value = Sesion.Clave;
                SqlCmd.Parameters.Add(ParClave);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "ERROR AL FINALIZAR LA SESION";

            }
            catch (Exception e)
            {

                rpta = e.Message;
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
    }
}
