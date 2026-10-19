using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NExpedientes
    {//inicio clase
        //metodo insertar
        public static string Insertar(int id_expediente, string numero_expediente, string caratula, string fecha_creacion)
        {

            DExpedientes Obj = new DExpedientes();
            Obj.Id_expediente = id_expediente;
            Obj.Numero_expediente = numero_expediente;
            Obj.Caratula = caratula;
            if (fecha_creacion != string.Empty)
            {
                try
                {
                    Obj.Fecha_creacion = Convert.ToDateTime(fecha_creacion);
                }
                catch (Exception)
                {

                    Obj.Fecha_creacion = System.DateTime.Parse("1900-01-01");

                }
            }
            else
            {
                Obj.Fecha_creacion = System.DateTime.Parse("1900-01-01");
            }
                        
            return Obj.Insertar(Obj);
        }
        
        
        //metodo buscar por Id 
        public static DataTable BuscarxId(int id_expediente)
        {
            DExpedientes Obj = new DExpedientes();
            Obj.Id_expediente = id_expediente;
            return Obj.BuscarxId(Obj);
        }
    }//fin clase
}
