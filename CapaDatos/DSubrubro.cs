using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DSubrubro
    {
        private int _Id_subrubro;
        private string _Subrubro;
        private int _Rubro_id;

        public int Id_subrubro
        {
            get
            {
                return _Id_subrubro;
            }

            set
            {
                _Id_subrubro = value;
            }
        }

        public string Subrubro
        {
            get
            {
                return _Subrubro;
            }

            set
            {
                _Subrubro = value;
            }
        }

        public int Rubro_id
        {
            get
            {
                return _Rubro_id;
            }

            set
            {
                _Rubro_id = value;
            }
        }



        public DSubrubro()
        {

        }

        public DSubrubro(int id_subrubro, string subrubro, int rubro_id)
        {
            this.Id_subrubro = id_subrubro;
            this.Subrubro = subrubro;
            this.Rubro_id = rubro_id;
        }

        //metodo buscar por id_rubro
        public DataTable BuscarSubrubroxRubro(DSubrubro Subrubro)
        {//inicio buscar x clave
            DataTable DtResultado = new DataTable("subrubro");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spbuscar_subrubros";

                SqlParameter ParIdRubro = new SqlParameter();
                ParIdRubro.ParameterName = "@id_rubro";
                ParIdRubro.SqlDbType = SqlDbType.Int;
                ParIdRubro.Value = Subrubro.Rubro_id;
                SqlCmd.Parameters.Add(ParIdRubro);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin metodo buscar por dni
    }

  

}
