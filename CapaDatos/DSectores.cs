using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DSectores
    {

        private int _Id_sector;
        private string _Sector;
        private int _Organismo_id;
        
        public int Id_sector
        {
            get
            {
                return _Id_sector;
            }

            set
            {
                _Id_sector = value;
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

        public int Organismo_id
        {
            get
            {
                return _Organismo_id;
            }

            set
            {
                _Organismo_id = value;
            }
        }

        public DSectores()
        {

        }

        public DSectores(int id_sector, string sector, int organismo_id)
        {
            this.Id_sector = id_sector;
            this.Sector = sector;
            this.Organismo_id = organismo_id;
        }

        //metodo buscar por id_organismo
        public DataTable BuscarSectoresxOrganismo(DSectores Sectores)
        {//inicio buscar x clave
            DataTable DtResultado = new DataTable("sectores");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spbuscar_sectores";

                SqlParameter ParOrganismoId = new SqlParameter();
                ParOrganismoId.ParameterName = "@organismo_id";
                ParOrganismoId.SqlDbType = SqlDbType.Int;
                ParOrganismoId.Value = Sectores.Organismo_id;
                SqlCmd.Parameters.Add(ParOrganismoId);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin metodo buscar por dni

        //metodo mostrar
        public DataTable Mostrar()
        {//inicio mostrar
            DataTable DtResultado = new DataTable("sectores");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spMostrarSectores";
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
