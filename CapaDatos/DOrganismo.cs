using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DOrganismo
    {
        private int _Id_Organismo;
        private string _Organismo;

        public int Id_Organismo
        {
            get
            {
                return _Id_Organismo;
            }

            set
            {
                _Id_Organismo = value;
            }
        }

        public string Organismo
        {
            get
            {
                return _Organismo;
            }

            set
            {
                _Organismo = value;
            }
        }

        public DOrganismo()
        {

        }

        public DOrganismo(int id_organismo, string organismo)
        {
            this.Id_Organismo = id_organismo;
            this.Organismo = organismo;
        }

        //metodo mostrar
        public DataTable Mostrar()
        {//inicio mostrar
            DataTable DtResultado = new DataTable("organismo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_organismos";
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
