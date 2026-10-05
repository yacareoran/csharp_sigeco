using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DRubro
    {
        private int _Id_rubro;
        private string _Rubro;

        public int Id_rubro
        {
            get
            {
                return _Id_rubro;
            }

            set
            {
                _Id_rubro = value;
            }
        }

        public string Rubro
        {
            get
            {
                return _Rubro;
            }

            set
            {
                _Rubro = value;
            }
        }


        public DRubro()
        {

        }

        public DRubro(int id_rubro, string rubro)
        {
            this.Id_rubro = id_rubro;
            this.Rubro = rubro;
        }

        //metodo mostrar
        public DataTable Mostrar()
        {//inicio mostrar
            DataTable DtResultado = new DataTable("rubro");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_rubros";
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
