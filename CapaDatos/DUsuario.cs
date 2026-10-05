using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
//using CapaDatos;


namespace CapaDatos
{
    public class DUsuario
    {//inicio clase
        private int _Id_usuario;
        private string _Nombre_usuario;
        //private string _Usuario;
        private string _Password;
        private int _Legajo;
        private int _Dni;
        private int _Roles_id;
        //private int _Id_tipo_usuario;
        private string _Sector;
        private string _Textobuscar;


        #region Propiedades

        public int Id_usuario
        {
            get
            {
                return _Id_usuario;
            }

            set
            {
                _Id_usuario = value;
            }
        }
        public string Nombre_usuario
        {
            get
            {
                return _Nombre_usuario;
            }

            set
            {
                _Nombre_usuario = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        public int Dni
        {
            get
            {
                return _Dni;
            }

            set
            {
                _Dni = value;
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


        public int Roles_id
        {
            get
            {
                return _Roles_id;
            }

            set
            {
                _Roles_id = value;
            }
        }

        public string Sector
        {
            get
            {
                return _Sector;
            }

            set
            {
                _Sector = value;
            }
        }

        public string Textobuscar
        {
            get
            {
                return _Textobuscar;
            }

            set
            {
                _Textobuscar = value;
            }
        }
        #endregion Propiedades

        #region Constructores
        //constructor vacio
        public DUsuario()
        {

        }
        //constructor con parametros
        public DUsuario(int id_usuario, string nombre_usuario, string pasword, int legajo, int dni, int roles_id, string sector, string textobuscar)
        {
            this.Id_usuario = id_usuario;
            this.Nombre_usuario = nombre_usuario;
            //this.Usuario = usuario;
            this.Password = pasword;
            this.Legajo = legajo;
            this.Dni = dni;
            this.Roles_id = roles_id;
            this.Sector = sector;
            this.Textobuscar = textobuscar;
        }

        #endregion Constructores

        /*public DataTable Login(DUsuario Usuario)
        {
            SqlConnection SqlCon = new SqlConnection();
            DataTable DtResultado = new DataTable("usuario");
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sploguin";
               
                SqlParameter ParNombre_usuario = new SqlParameter();
                ParNombre_usuario.SqlDbType = SqlDbType.VarChar;
                ParNombre_usuario.Size = 50;
                ParNombre_usuario.ParameterName = "@nombre_usuario";
                ParNombre_usuario.Value = Usuario.Nombre_usuario;
                SqlCmd.Parameters.Add(ParNombre_usuario);

                SqlParameter ParPass = new SqlParameter();
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 50;
                ParPass.ParameterName = "@pasword";
                ParPass.Value = Usuario.Password;
                SqlCmd.Parameters.Add(ParPass);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);


            }
            catch (Exception)
            {

                DtResultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return DtResultado;
        }*/

        //metogo login para probar el programa

        public DataTable Login(DUsuario Usuario)
        {
            SqlConnection SqlCon = new SqlConnection();
            DataTable DtResultado = new DataTable("usuario");
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "splogin";

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.ParameterName = "@nombre_usuario";
                ParUsuario.Value = Usuario.Nombre_usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPass = new SqlParameter();
                ParPass.SqlDbType = SqlDbType.VarChar;
                ParPass.Size = 50;
                ParPass.ParameterName = "@pasword";
                ParPass.Value = Usuario.Password;
                SqlCmd.Parameters.Add(ParPass);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);


            }
            catch (Exception)
            {

                DtResultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return DtResultado;
        }

        //fin metodo probar programa


        //metodo insertar   
        public string Insertar(DUsuario Usuario)
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
                SqlCmd.CommandText = "spinsertar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros
                SqlParameter ParId_Usuario = new SqlParameter();
                ParId_Usuario.ParameterName = "@legajo";
                ParId_Usuario.SqlDbType = SqlDbType.Int;
                ParId_Usuario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_Usuario);

                SqlParameter ParNombreUsuario = new SqlParameter();
                ParNombreUsuario.ParameterName = "@nombre_usuario";
                ParNombreUsuario.SqlDbType = SqlDbType.VarChar;
                ParNombreUsuario.Size = 50;
                ParNombreUsuario.Value = Usuario.Nombre_usuario;
                SqlCmd.Parameters.Add(ParNombreUsuario);

                /*SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Usuario.Nombre;
                SqlCmd.Parameters.Add(ParNombre);*/

                SqlParameter ParDni = new SqlParameter();
                ParDni.ParameterName = "@dni";
                ParDni.SqlDbType = SqlDbType.Int;
                ParDni.Value = Usuario.Dni;
                SqlCmd.Parameters.Add(ParDni);

                /*SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Usuario.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);*/

                SqlParameter ParPasword = new SqlParameter();
                ParPasword.ParameterName = "@pasword";
                ParPasword.SqlDbType = SqlDbType.VarChar;
                ParPasword.Size = 20;
                ParPasword.Value = Usuario.Password;
                SqlCmd.Parameters.Add(ParPasword);

                SqlParameter ParRolesId = new SqlParameter();
                ParRolesId.ParameterName = "@roles_id";
                ParRolesId.SqlDbType = SqlDbType.Int;
                ParRolesId.Value = Usuario.Roles_id;
                SqlCmd.Parameters.Add(ParRolesId);

                /*SqlParameter ParIdTipoUsuario = new SqlParameter();
                ParIdTipoUsuario.ParameterName = "@id_tipo_usuario";
                ParIdTipoUsuario.SqlDbType = SqlDbType.Int;
                ParIdTipoUsuario.Value = Usuario.Id_tipo_usuario;
                SqlCmd.Parameters.Add(ParIdTipoUsuario);*/


                //ejecutar el codigo
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "EL REGISTRO NO HA SIDO AGREGADO";


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

        }//fin insertar


        //metodo mostrar
        public DataTable Mostrar()
        {//inicio mostrar
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_usuario";
                
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);


            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin mostrar

        //metodo buscar 
        public DataTable Buscar(DUsuario Usuario)
        {//inicio buscar x clave
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spbuscar_usuarios";

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Usuario.Textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin metodo buscar 









        }




}



