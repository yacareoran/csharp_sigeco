using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEstado
    {
        private int _Id_estado;
        private string _Estado;
    
    public int Id_estado
    {
        get
        {
            return _Id_estado;
        }

        set
        {
            _Id_estado = value;
        }
    }

    public string Estado
    {
        get
        {
            return _Estado;
        }

        set
        {
            _Estado = value;
        }
    }
        public DEstado()
        {

        }
        public DEstado(int id_estado, string estado)
        {
            this.Id_estado = id_estado;
            this.Estado = estado;
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
}
