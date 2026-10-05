using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace CapaDatos
{
    public class DPedidoCompra
    {//inicio de clase
        private int _Num_transaccion;
        private string _Pedido;
        private string _Extracto;
        private string _Fecha_pedido;
        private int _Usuario_id;
        private int _Caracter_pedido_id;
        private string _Nombre_usuario;
        private int _Id_usuario;
        private string _Sector;
        private string _Caracter_pedido;
        private int _Id_caracter_pedido;
        private int _Id_organismo;
        private string _Organismo;

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

        public string Extracto
        {
            get
            {
                return _Extracto;
            }

            set
            {
                _Extracto = value;
            }
        }
        public string FechaPedido
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

        public int Usuario_id
        {
            get
            {
                return _Usuario_id;
            }

            set
            {
                _Usuario_id = value;
            }
        }

        public int Caracter_pedido_id
        {
            get
            {
                return _Caracter_pedido_id;
            }

            set
            {
                _Caracter_pedido_id = value;
            }
        }

        public string Nombre_usuario
        {
            get
            {
                return _Nombre_usuario;
            }

            set
            {
                _Nombre_usuario = value;
            }
        }

        public int Id_usuario
        {
            get
            {
                return _Id_usuario;
            }

            set
            {
                _Id_usuario = value;
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

        public string Caracter_pedido
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

        public int Id_caracter_pedido
        {
            get
            {
                return _Id_caracter_pedido;
            }

            set
            {
                _Id_caracter_pedido = value;
            }
        }

        public int Id_organismo
        {
            get
            {
                return _Id_organismo;
            }

            set
            {
                _Id_organismo = value;
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
    }//fin clase
}
