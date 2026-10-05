using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DCaracterPedido
    {
        private int _Id_Caracter_pedido;
        private string _Caracter_pedido;

        public int Id_Caracter_pedido
        {
            get
            {
                return _Id_Caracter_pedido;
            }

            set
            {
                _Id_Caracter_pedido = value;
            }
        }

        public string Unidad_medida
        {
            get
            {
                return _Caracter_pedido;
            }

            set
            {
                _Caracter_pedido = value;
            }
        }

        public DCaracterPedido()
        {

        }
        public DCaracterPedido(int id_caracter_pedido, string caracter_pedido)
        {
            this.Id_Caracter_pedido = id_caracter_pedido;
            this._Caracter_pedido = caracter_pedido;
        }

        //metodo mostrar
        public DataTable Mostrar()
        {//inicio mostrar
            DataTable DtResultado = new DataTable("caracter_pedido");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_caracter_pedido";
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
