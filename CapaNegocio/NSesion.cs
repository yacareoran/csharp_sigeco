using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace CapaNegocio
{
    public class NSesion
    {


        //metodos
        //metodo inicio de Sesion
        public static String Inicio(int dni, DateTime inicio, DateTime fin,
            string ip, string equipo)
        {
            DSesion sesion = new CapaDatos.DSesion();
            sesion.Dni_usuario = dni;
            sesion.Inicio = inicio;
            sesion.Fin = fin;
            sesion.Ip = ip;
            sesion.Equipo = equipo;
            return sesion.Inicio_Sesion(sesion);
        }

        //metodo Mostrar
        public static DataTable Mostrar()
        {
            DSesion Obj = new DSesion();
            return Obj.Mostrar();

        }

        //metodo buscar por nombre
        public static DataTable Buscar_x_Usuario(int dni)
        {
            DSesion Obj = new DSesion();
            Obj.Dni_usuario = dni;
            return Obj.Buscar_X_Usuario(Obj);
        }

        //metodo buscar por fecha
        public static DataTable Buscar_x_Fecha(DateTime inicio)
        {
            DSesion Obj = new DSesion();
            Obj.Inicio = inicio;
            return Obj.Buscar_X_Fecha(Obj);
        }

        //metodo fin de sesion
        public static string Fin(int clave)
        {
            DSesion Obj = new DSesion();
            Obj.Clave = clave;
            return Obj.finalizar_sesion(Obj);
        }




    }
}
