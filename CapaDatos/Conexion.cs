using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class Conexion
    {
        //Esta clase es el constructor y aqui vamos a crear la cadena de conexion para conectar la base de datos
        //En el servidor de datos Data Source va el nombre del equipo si queremos servidor de red va el numero de ip
        //public static string Cn = "Data Source=DESKTOP-61JDA13\\SQLEXPRESS; Initial Catalog=dbCigeco; Integrated Security=false";
        public static string Cn = Properties.Settings.Default.cn;
    }
}
