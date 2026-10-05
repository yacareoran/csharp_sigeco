using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NPedido
    {
        //metodo insertar
        public static string Insertar(int id_pedido, string pedido, string fecha_pedido, int num_seguimiento, int usuario_id, int num_transaccion, int caracter_pedido_id, int estado_pedido_id, int destino_id, int emisor_id, string extracto, int sectores_id, int organismo_id, int sectores_internos_id)
        {
           
            DPedido Obj = new DPedido();
            Obj.Id_pedido = id_pedido;
            Obj.Pedido = pedido;
            if (fecha_pedido != string.Empty)
            {
                try
                {
                    Obj.Fecha_pedido = Convert.ToDateTime(fecha_pedido);
                }
                catch (Exception)
                {

                    Obj.Fecha_pedido = System.DateTime.Parse("1900-01-01");

                }
            }
            else
            {
                Obj.Fecha_pedido = System.DateTime.Parse("1900-01-01");
            }
            
            Obj.Num_seguimiento = num_seguimiento;
            Obj.Usuario_id = usuario_id;
            Obj.Num_transaccion = num_transaccion;
            Obj.Caracter_pedido_id = caracter_pedido_id;
            Obj.Estado_pedido_id = estado_pedido_id;
            Obj.Destino_id = destino_id;
            Obj.Emisor_id = emisor_id;
            Obj.Extracto = extracto;
            Obj.Sectores_id = sectores_id;
            Obj.Organismo_id = organismo_id;
            Obj.Sectores_internos_id = sectores_internos_id;
            return Obj.Insertar(Obj);
        }

        //metodo editar
        public static string EditarPedido(int id_pedido, string pedido, int estado_id, int caracter_pedido_id)
        {
            DPedido Obj = new DPedido();
            Obj.Id_pedido = id_pedido;
            Obj.Pedido = pedido;
            Obj.Estado_id = estado_id;
            Obj.Caracter_pedido_id = caracter_pedido_id;
            return Obj.EditarPedido(Obj);
        }


        //metodo buscar por transaccion
        public static DataTable BuscarxTransaccion(int num_transaccion)
        {
            DPedido Obj = new DPedido();
            Obj.Num_transaccion = num_transaccion;
            return Obj.BuscarxTransaccion(Obj);
        }

        //metodo buscar por concepto

        //metodo buscar por Id 
        public static DataTable BuscarxId(int id_pedido)
        {
            DPedido Obj = new DPedido();
            Obj.Id_pedido = id_pedido;
            return Obj.BuscarxId(Obj);
        }

        //metodo buscar por Id

        //metodo buscar 
        public static DataTable BuscarConcepto(string textobuscar)
        {
            DPedido Obj = new DPedido();
            Obj.Textobuscar = textobuscar;
            return Obj.BuscarConcepto(Obj);
        }

        //metodo buscar por fechas 
        public static DataTable BuscarxFechas(string fecha_inicio, string fecha_fin, int sectores_internos_id)
        {
            DPedido Obj = new DPedido();
            if (fecha_inicio != string.Empty)
            {
                try
                {
                    Obj.Fecha_inicio = Convert.ToDateTime(fecha_inicio);
                }
                catch (Exception)
                {

                    Obj.Fecha_fin = System.DateTime.Parse("1900-01-01");

                }
            }
            else
            {
                Obj.Fecha_fin = System.DateTime.Parse("1900-01-01");
            }
            if (fecha_fin != string.Empty)
            {
                try
                {
                    Obj.Fecha_fin = Convert.ToDateTime(fecha_fin);
                }
                catch (Exception)
                {

                    Obj.Fecha_fin = System.DateTime.Parse("1900-01-01");

                }
            }
            else
            {
                Obj.Fecha_fin = System.DateTime.Parse("1900-01-01");
            }
            Obj.Sectores_internos_id = sectores_internos_id;
            return Obj.BuscarxFechas(Obj);

        }

        //metodo retornar año 
        public static int BuscarAnioActual()
        {
            //DPedido Obj = new DPedido();
            //Obj.Textobuscar = textobuscar;
            int anio;
            return BuscarAnioActual();
        }

        //metodo retornar numero de transaccion 
        public static int BuscarNumeroTransaccion()
        {
            DPedido Obj = new DPedido();
            //Obj.Textobuscar = textobuscar;
            int num_transaccion;
            return Obj.BuscarNumeroTransaccion();
        }
    }
}

