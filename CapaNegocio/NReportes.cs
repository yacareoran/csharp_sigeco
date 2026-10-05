using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NReportes
    {
        //Retornar Planilla Rendicion
        public DataTable RetornarReportesPedido()
        {
            DataTable dtResultado = new DataTable();
            DReportes dReportes = new DReportes();
            try
            {
                //dtResultado = dReportes.RetornarReportesPedido(int id_pedido);
                //DPedido Obj = new DPedido();
                //Obj.Id_pedido = id_pedido;
                //return Obj.BuscarxId(Obj);
            }
            catch
            {
                dtResultado = null;
            }
            return dtResultado;
        }

        //metodo buscar por Id 
        public static DataTable BuscarxId(int id_pedido)
        {
            DReportes Obj = new DReportes();
            Obj.Id_pedido = id_pedido;
            return Obj.BuscarxId(Obj);
        }

        //metodo buscar por Id
    }
}

