using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSectoresOrganismos
    {
        private int _Id_organismo_sectores;
        private int _Organismo_id;
        private int _Sectores_id;
        public int Id_orgsnimo_sectores
        {
            get
            {
                return _Id_organismo_sectores;
            }

            set
            {
                _Id_organismo_sectores = value;
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

        public int Sectores_id
        {
            get
            {
                return _Sectores_id;
            }

            set
            {
                _Sectores_id = value;
            }
        }

        public DSectoresOrganismos()
        {

        }
        //constructor con parametros
        public DSectoresOrganismos(int id_organismo_sectores, int organismo_id, int sectores_id)
        {
            this._Id_organismo_sectores = id_organismo_sectores;
            this.Organismo_id = organismo_id;
            this.Sectores_id = sectores_id;
            
        }
        public int BuscarIdSectoresOrganismos(DSectoresOrganismos sectoresOrganismos)
        {//inicio buscar
            int id_SectoresOrganismos;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sp_ObtenerIdSectoresOrganismos";
                id_SectoresOrganismos = SqlCmd.ExecuteNonQuery();

                SqlParameter ParIdOrganismo = new SqlParameter();
                ParIdOrganismo.ParameterName = "@id_organismo";
                ParIdOrganismo.SqlDbType = SqlDbType.Int;
                ParIdOrganismo.Value = sectoresOrganismos.Organismo_id;
                SqlCmd.Parameters.Add(ParIdOrganismo);

                SqlParameter ParIdSectores = new SqlParameter();
                ParIdSectores.ParameterName = "@id_sectores";
                ParIdSectores.SqlDbType = SqlDbType.Int;
                ParIdSectores.Value = sectoresOrganismos.Sectores_id;
                SqlCmd.Parameters.Add(ParIdSectores);
                              
            }
            catch (Exception)
            {

                return 0;
            }
            return id_SectoresOrganismos;
        }//fin metodo buscar 
    }
}
