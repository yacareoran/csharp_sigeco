using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCargarPedidos
    {//inicio clase
        private int _Id_pedido;
        private int _Num_transaccion;
        private string _Pedido;
        private DateTime _Fecha_pedido;

        public int Id_pedido
        {
            get
            {
                return _Id_pedido;
            }

            set
            {
                _Id_pedido = value;
            }
        }

        public int Num_transaccion
        {
            get
            {
                return _Num_transaccion;
            }

            set
            {
                _Num_transaccion = value;
            }
        }
        public string Pedido
        {
            get
            {
                return _Pedido;
            }

            set
            {
                _Pedido = value;
            }
        }

        public DateTime Fecha_pedido
        {
            get
            {
                return _Fecha_pedido;
            }

            set
            {
                _Fecha_pedido = value;
            }
        }
        
        //constructor vacio
        public DCargarPedidos()
        {

        }

        //constructor con parametros
        public DCargarPedidos(int id_pedido, int num_transaccion, string pedido, DateTime fecha_pedido)
        {
            this.Id_pedido = id_pedido;
            this.Pedido = pedido;
            this.Fecha_pedido = fecha_pedido;
            this.Num_transaccion = num_transaccion;
            
        }

    }//fin clase
}
