using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;


namespace CapaNegocio
{
    public class NUsuario
    {
        /*public static DataTable Login(string nombre_usuario, string pasword)
        {
            DUsuario Obj = new DUsuario();
            Obj.Nombre_usuario = nombre_usuario;
            Obj.Password = pasword;

            return Obj.Login(Obj);
        }*/

        public static DataTable Login(string nombre_usuario, string pasword)
        {
            DUsuario Obj = new DUsuario();
            Obj.Nombre_usuario = nombre_usuario;
            Obj.Password = pasword;
            

            return Obj.Login(Obj);
        }


        //metodo Mostrar que llama al metodo Mostrar de la clase DCliente

        public static DataTable Mostrar()
        {
            DUsuario Obj = new DUsuario();
            return Obj.Mostrar();
        }

        //metodo Buscar que llama al metodo Buscar de la clase DCliente

        public static DataTable Buscar(string textobuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.Textobuscar = textobuscar;
            return Obj.Buscar(Obj);
        }


    }
}
