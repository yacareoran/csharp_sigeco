using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DUnidadMedida
    {
        private int _Id_unidad_medida;
        private string _Unidad_medida;

        public int Id_unidad_medida
        {
            get
            {
                return _Id_unidad_medida;
            }

            set
            {
                _Id_unidad_medida = value;
            }
        }

        public string Unidad_medida
        {
            get
            {
                return _Unidad_medida;
            }

            set
            {
                _Unidad_medida = value;
            }
        }

        public DUnidadMedida()
        {

        }

        public DUnidadMedida(int id_unidad_medida, string unidad_medida)
        {
            this.Id_unidad_medida = id_unidad_medida;
            this.Unidad_medida = unidad_medida;
        }

        //metodo mostrar
        public DataTable Mostrar()
        {//inicio mostrar
            DataTable DtResultado = new DataTable("unidad_medida");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_unidad_medida";
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
