using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoContratacion
    {//inicio clase
            private int _Id_tipo_contratacion;
            private string _Tipo_contratacion;

            public int Id_tipo_contratacion
            {
                get
                {
                    return _Id_tipo_contratacion;
                }

                set
                {
                    _Id_tipo_contratacion = value;
                }
            }

            public string Tipo_contratacion
            {
                get
                {
                    return _Tipo_contratacion;
                }

                set
                {
                    _Tipo_contratacion = value;
                }
            }
            public DTipoContratacion()
            {

            }
            public DTipoContratacion(int id_tipo_contratacion, string tipo_contratacion)
            {
                this.Id_tipo_contratacion = id_tipo_contratacion;
                this.Tipo_contratacion = tipo_contratacion;
            }
            //metodo mostrar
            public DataTable Mostrar()
            {//inicio mostrar
                DataTable DtResultado = new DataTable("estado");
                SqlConnection SqlCon = new SqlConnection();
                try
                {
                    SqlCon.ConnectionString = Conexion.Cn;
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.CommandText = "sp_MostrarEstados";
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
    }
}//fin clase

