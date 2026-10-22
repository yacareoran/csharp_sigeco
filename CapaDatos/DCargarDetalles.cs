using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCargarDetalles
    {//inicio clase
        private int _Id_pedido;
        private decimal _Precio;
        private int _Cantidad;
        private decimal _Subtotal;

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

        public decimal Precio
        {
            get
            {
                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }
        public int Pedido
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return _Subtotal;
            }

            set
            {
                _Subtotal = value;
            }
        }

        //constructor vacio
        public DCargarDetalles()
        {

        }

        //constructor con parametros
        public DCargarDetalles(int id_pedido, decimal precio, int cantidad, decimal subtotal)
        {
            this.Id_pedido = id_pedido;
            this.Precio = precio;
            this._Cantidad = cantidad;
            this.Subtotal = subtotal;

        }

    }//fin clase
}
