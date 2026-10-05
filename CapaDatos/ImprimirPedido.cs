using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ImprimirPedido
    {
        private int _Id_pedido;
        private string _Pedido;
        private DateTime _Fecha_pedido;
        private int _Num_seguimiento;
        private int _Usuario_id;
        private int _Num_transaccion;
        private int _Caracter_pedido_id;
        private int _Estado_pedido_id;
        private int _Destino_id;
        private int _Emisor_id;
        private string _Extracto;
        private string _Expediente_interno;
        private string _Expediente_externo;
        private string _Numero_nota;
        private string _Sector;
        private string _Caracter_pedido;
        private int _Estado_id;
        private string _Estado;
        private decimal _Costo_total;
        private string _Textobuscar;
        private int _Anio_actual;
        private DateTime _Fecha_inicio;
        private DateTime _Fecha_fin;
        public int caracter_pedido_id { get; set; }
        public DCaracterPedido caracter_pedido { get; set; }

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

        public int Num_seguimiento
        {
            get
            {
                return _Num_seguimiento;
            }

            set
            {
                _Num_seguimiento = value;
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

        public int Estado_pedido_id
        {
            get
            {
                return _Estado_pedido_id;
            }

            set
            {
                _Estado_pedido_id = value;
            }
        }

        public int Destino_id
        {
            get
            {
                return _Destino_id;
            }

            set
            {
                _Destino_id = value;
            }
        }

        public int Emisor_id
        {
            get
            {
                return _Emisor_id;
            }

            set
            {
                _Emisor_id = value;
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

        public string Expediente_interno
        {
            get
            {
                return _Expediente_interno;
            }

            set
            {
                _Expediente_interno = value;
            }
        }

        public string Expediente_externo
        {
            get
            {
                return _Expediente_externo;
            }

            set
            {
                _Expediente_externo = value;
            }
        }

        public string Numero_nota
        {
            get
            {
                return _Numero_nota;
            }

            set
            {
                _Numero_nota = value;
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

        public int Estado_id
        {
            get
            {
                return _Estado_id;
            }

            set
            {
                _Estado_id = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }

        public decimal Costo_total
        {
            get
            {
                return _Costo_total;
            }

            set
            {
                _Costo_total = value;
            }
        }
        public int Anio_actual
        {
            get
            {
                return _Anio_actual;
            }

            set
            {
                _Anio_actual = value;
            }
        }

        public string Textobuscar
        {
            get
            {
                return _Textobuscar;
            }

            set
            {
                _Textobuscar = value;
            }
        }

        public DateTime Fecha_inicio
        {
            get
            {
                return _Fecha_inicio;
            }

            set
            {
                _Fecha_inicio = value;
            }
        }

        public DateTime Fecha_fin
        {
            get
            {
                return _Fecha_fin;
            }

            set
            {
                _Fecha_fin = value;
            }
        }

        //constructor vacio
        public ImprimirPedido()
        {

        }
        //constructor con parametros
        public ImprimirPedido(int id_pedido, string pedido, DateTime fecha_pedido, int num_seguimiento, int usuario_id, int num_transaccion, int caracter_pedido_id, int estado_pedido_id, int destino_id, int emisor_id, string extracto, decimal costo_total, int anio_actual, DateTime fecha_inicio, DateTime fecha_fin)
        {
            this.Id_pedido = id_pedido;
            this.Pedido = pedido;
            this.Fecha_pedido = fecha_pedido;
            this.Num_seguimiento = num_seguimiento;
            this.Usuario_id = usuario_id;
            this.Num_transaccion = num_transaccion;
            this.Caracter_pedido_id = caracter_pedido_id;
            this.Estado_pedido_id = estado_pedido_id;
            this.Destino_id = destino_id;
            this.Emisor_id = emisor_id;
            this.Extracto = extracto;
            this.Costo_total = costo_total;
            this.Anio_actual = anio_actual;
            this.Fecha_inicio = fecha_inicio;
            this.Fecha_fin = fecha_fin;

        }
    }
}
