using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSectoresInternos
    {//inicio clase
        private int _Id_sectores_internos;
        private string _Sectores_internos;
       
        public int Id_sectores_internos
        {
            get
            {
                return _Id_sectores_internos;
            }

            set
            {
                _Id_sectores_internos = value;
            }
        }

        public string Sectores_internos
        {
            get
            {
                return _Sectores_internos; 
            }

            set
            {
                _Sectores_internos = value;
            }
        }

        public DSectoresInternos()
        {

        }

        public DSectoresInternos(int id_sectores_internos, string sectores_internos)
        {
            this.Id_sectores_internos = id_sectores_internos;
            this.Sectores_internos = sectores_internos;
        }

       

        //metodo mostrar
        public DataTable Mostrar()
        {//inicio mostrar
            DataTable DtResultado = new DataTable("sectores_internos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spMostrarSectoresInternos";
                //spmostrar_tipo_cliente

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);




            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin mostrar


    }//fin clase
}
