using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NDetalle
    {
        //metodo insertar que llama a Insertar de la clase DDetalle
        public static string Insertar(string detalle, int cantidad, int unidad_medida_id, decimal precio, int pedido_id, int renglon, int rubro_id, int subrubro_id)
        {
            DDetalle Obj = new DDetalle();
            Obj.Detalle = detalle;
            Obj.Cantidad = cantidad;
            Obj.Unidad_medida_id = unidad_medida_id;
            Obj.Precio = precio;
            Obj.Pedido_id = pedido_id;
            Obj.Renglon = renglon;
            Obj.Rubro_id = rubro_id;
            Obj.Subrubro_id = subrubro_id;
            return Obj.Insertar(Obj);
        }

        //metodo retornar costo total 
        public static decimal BuscarCostoTotal(int id_pedido)
        {
            DDetalle Obj = new DDetalle();
            Obj.Pedido_id = id_pedido;
            //decimal costoTotal;
            return Obj.BuscarCostoTotal(Obj);
            //return BuscarCostoTotal(Obj.Pedido_id);


        }
        //metodo buscar por id_pedido
        public static DataTable BuscarCantidadPrecio(int pedido_id)
        {
            DDetalle Obj = new DDetalle();
            Obj.Pedido_id = pedido_id;
            return Obj.BuscarCantidadPrecio(Obj);
        }

        //metodo buscar todos los campos de detalles por id_pedido
        public static DataTable BuscarDetalles(int pedido_id)
        {
            DDetalle Obj = new DDetalle();
            Obj.Pedido_id = pedido_id;
            return Obj.BuscarDetalles(Obj);
        }

        //metodo editar que llama a Editar de la clase DDetlle
        public static string EditarDetallexPedido(int id_pedido, string detalle, int cantidad, decimal precio)
        {
            DDetalle Obj = new DDetalle();
            Obj.Pedido_id = id_pedido;
            Obj.Detalle = detalle;
            Obj.Cantidad = cantidad;
            Obj.Precio = precio;
            return Obj.EditarDetallexPedido(Obj);
        }

        //metodo editar que llama a Editar de la clase DDetlle
        public static string EditarDetallexIdPedido(int id_detalle, string detalle, int cantidad, decimal precio)
        {
            DDetalle Obj = new DDetalle();
            Obj.Id_detalle = id_detalle;
            Obj.Detalle = detalle;
            Obj.Cantidad = cantidad;
            Obj.Precio = precio;
            return Obj.EditarDetallexPedido(Obj);
        }

        //metodo editar que llama a Editar de la clase DDetlle
        //public static string EditarDetallexIdDetalle(int id_detalle, string detalle, int cantidad, decimal precio)
        public static string EditarDetallexIdDetalle(int id_detalle, string detalle, int cantidad, decimal precio)
        {
            DDetalle Obj = new DDetalle();
            Obj.Id_detalle = id_detalle;
            Obj.Detalle = detalle;
            Obj.Cantidad = cantidad;
            Obj.Precio = precio;
            return Obj.EditarDetallexIdDetalle(Obj);
        }

    }
}
