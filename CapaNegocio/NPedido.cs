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
        // Método insertar optimizado para la capa de negocio
        public static string Insertar(int id_pedido, string pedido, string fecha_pedido, int num_seguimiento, int usuario_id, int num_transaccion, int caracter_pedido_id, int estado_pedido_id, int destino_id, int emisor_id, string extracto, int sectores_id, int organismo_id, int sectores_internos_id)
        {
            DPedido Obj = new DPedido();
            Obj.Id_pedido = id_pedido;
            Obj.Pedido = pedido;

            // Control de fecha seguro: evita caídas por formatos regionales del servidor
            if (!string.IsNullOrWhiteSpace(fecha_pedido))
            {
                // Intenta convertir la fecha usando el formato del sistema actual
                if (DateTime.TryParse(fecha_pedido, out DateTime fechaConvertida))
                {
                    Obj.Fecha_pedido = fechaConvertida;
                }
                else
                {
                    // Fecha por defecto si el formato enviado es inválido
                    Obj.Fecha_pedido = new DateTime(1900, 1, 1);
                }
            }
            else
            {
                // Fecha por defecto si viene vacío o nulo
                Obj.Fecha_pedido = new DateTime(1900, 1, 1);
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

            // Envía el objeto limpio hacia la capa de datos
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

        // Método buscar detalles por id_pedido corregido
        public static decimal ObtenerTotalPedido(DPedido objPedido)
        {
            // 1. Creamos el objeto de la capa de datos (rompiendo la ambigüedad)
            DPedido objetoDatos = new DPedido();

            // 2. Llamamos al método a través de la instancia creada
            DataTable dt = objetoDatos.BuscarDetallesxId(objPedido);

            decimal totalGeneral = 0;

            // 3. Recorremos las filas para calcular la suma del subtotal
            foreach (DataRow fila in dt.Rows)
            {
                if (fila["subtotal"] != DBNull.Value)
                {
                    totalGeneral += Convert.ToDecimal(fila["subtotal"]);
                }
            }

            return totalGeneral;
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


        //metodo buscar por Nota de Pedido
        public static DataTable BuscarNotaPedido(string textobuscar)
        {
            DPedido Obj = new DPedido();
            Obj.Textobuscar = textobuscar;
            return Obj.BuscarNotaPedido(Obj);
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

        // Método asignar número de nota (Capa de Negocio)
        public static string AsignarNumeroNotaPedido(int id_pedido, string numero_nota)
        {
            // 1. Instanciamos el objeto de la Capa de Datos
            DPedido Obj = new DPedido();

            // 2. Le asignamos los valores que vienen desde la Presentación
            Obj.Id_pedido = id_pedido;
            Obj.Numero_nota = numero_nota;

            // CORRECCIÓN: Llamamos al método específico para la nota, no al Editar general
            return Obj.AsignarNumeroNotaPedido(Obj);
        }
        // Fin método asignar número de nota


        //metodo retornar numero maximo para expedientes
        public static int BuscarMaximoNumeroExpediente()
        {
            DPedido Obj = new DPedido();
            //Obj.Textobuscar = textobuscar;
            int num_transaccion;
            return Obj.BuscarMaximoNumeroExpediente();
        }
    }
}

