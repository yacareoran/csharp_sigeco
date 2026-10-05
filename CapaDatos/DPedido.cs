using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using CapaDatos;


namespace CapaDatos
{
    public class DPedido
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
        private int _Origen_id;
        private int _Sectores_id;
        private int _Organismo_id;
        private int _Sectores_internos_id;
        private string _Sectores_internos;

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

        public int Origen_id
        {
            get
            {
                return _Origen_id;
            }

            set
            {
                _Origen_id = value;
            }
        }
        public int Sectores_id
        {
            get
            {
                return _Sectores_id;
            }

            set
            {
                _Sectores_id = value;
            }
        }
        public int Organismo_id
        {
            get
            {
                return _Organismo_id;
            }

            set
            {
                _Organismo_id = value;
            }
        }
        public int Sectores_internos_id
        {
            get
            {
                return _Sectores_internos_id;
            }

            set
            {
                _Sectores_internos_id = value;
            }
        }
        public string Sectores_internos
        {
            get
            {
                return _Sectores_internos;
            }

            set
            {
                _Sectores_internos = value;
            }
        }
        //constructor vacio
        public DPedido()
        {

        }
        //constructor con parametros
        public DPedido(int id_pedido, string pedido, DateTime fecha_pedido, int num_seguimiento, int usuario_id, int num_transaccion, int caracter_pedido_id, int estado_pedido_id, int destino_id, int emisor_id, string extracto, decimal costo_total, int anio_actual, DateTime fecha_inicio, DateTime fecha_fin, int origen_id, string expediente_interno, string expediente_externo, string numero_nota, string sector, string caracter_pedido, int estado_id, string estado, string textobuscar, int sectores_id, int organismo_id, int sectores_internos_id, string sectores_internos)
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
            this.Origen_id = origen_id;
            this.Expediente_interno = expediente_interno;
            this.Expediente_externo = expediente_externo;
            this.Numero_nota = numero_nota;
            this.Sector = sector;
            this.Caracter_pedido = caracter_pedido;
            this.Estado_id = estado_id;
            this.Estado = estado;
            this.Textobuscar = textobuscar;
            this.Sectores_id = sectores_id;
            this.Organismo_id = organismo_id;
            this.Sectores_internos_id = sectores_internos_id;
            this.Sectores_internos = sectores_internos;
        }

        //metodo insertar   
        public string Insertar(DPedido Pedido)
        {//inicio insertar
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_pedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros
                SqlParameter ParId_Pedido = new SqlParameter();
                ParId_Pedido.ParameterName = "@id_pedido";
                ParId_Pedido.SqlDbType = SqlDbType.Int;
                ParId_Pedido.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_Pedido);

                SqlParameter ParPedido = new SqlParameter();
                ParPedido.ParameterName = "@pedido";
                ParPedido.SqlDbType = SqlDbType.VarChar;
                ParPedido.Size = 250;
                ParPedido.Value = Pedido.Pedido;
                SqlCmd.Parameters.Add(ParPedido);

                SqlParameter ParFecha_Pedido = new SqlParameter();
                ParFecha_Pedido.ParameterName = "@fecha_pedido";
                ParFecha_Pedido.SqlDbType = SqlDbType.VarChar;
                ParFecha_Pedido.Size = 50;
                ParFecha_Pedido.Value = Pedido.Fecha_pedido;
                SqlCmd.Parameters.Add(ParFecha_Pedido);

                SqlParameter ParNumSeguimiento = new SqlParameter();
                ParNumSeguimiento.ParameterName = "@num_seguimiento";
                ParNumSeguimiento.SqlDbType = SqlDbType.Int;
                ParNumSeguimiento.Value = Pedido.Num_seguimiento;
                SqlCmd.Parameters.Add(ParNumSeguimiento);

                SqlParameter ParUsuarioId = new SqlParameter();
                ParUsuarioId.ParameterName = "@usuario_id";
                ParUsuarioId.SqlDbType = SqlDbType.Int;
                ParUsuarioId.Value = Pedido.Usuario_id;
                SqlCmd.Parameters.Add(ParUsuarioId);

                SqlParameter ParNumTransaccion = new SqlParameter();
                ParNumTransaccion.ParameterName = "@num_transaccion";
                ParNumTransaccion.SqlDbType = SqlDbType.Int;
                ParNumTransaccion.Value = Pedido.Num_transaccion;
                SqlCmd.Parameters.Add(ParNumTransaccion);

                SqlParameter ParCaracterPedidoId = new SqlParameter();
                ParCaracterPedidoId.ParameterName = "@caracter_pedido_id";
                ParCaracterPedidoId.SqlDbType = SqlDbType.Int;
                ParCaracterPedidoId.Value = Pedido.Caracter_pedido_id;
                SqlCmd.Parameters.Add(ParCaracterPedidoId);

                SqlParameter ParEstadoPedidoId = new SqlParameter();
                ParEstadoPedidoId.ParameterName = "@estado_pedido_id";
                ParEstadoPedidoId.SqlDbType = SqlDbType.Int;
                ParEstadoPedidoId.Value = Pedido.Estado_pedido_id;
                SqlCmd.Parameters.Add(ParEstadoPedidoId);

                SqlParameter ParDestinoId = new SqlParameter();
                ParDestinoId.ParameterName = "@destino_id";
                ParDestinoId.SqlDbType = SqlDbType.Int;
                ParDestinoId.Value = Pedido.Destino_id;
                SqlCmd.Parameters.Add(ParDestinoId);

                SqlParameter ParEmisorId = new SqlParameter();
                ParEmisorId.ParameterName = "@emisor_id";
                ParEmisorId.SqlDbType = SqlDbType.Int;
                ParEmisorId.Value = Pedido.Emisor_id;
                SqlCmd.Parameters.Add(ParEmisorId);

                SqlParameter ParExtracto = new SqlParameter();
                ParExtracto.ParameterName = "@extracto";
                ParExtracto.SqlDbType = SqlDbType.VarChar;
                ParExtracto.Size = 250;
                ParExtracto.Value = Pedido.Extracto;
                SqlCmd.Parameters.Add(ParExtracto);

                SqlParameter ParOrigenId = new SqlParameter();
                ParOrigenId.ParameterName = "@origen_id";
                ParOrigenId.SqlDbType = SqlDbType.Int;
                ParOrigenId.Value = Pedido.Usuario_id;
                SqlCmd.Parameters.Add(ParOrigenId);

                SqlParameter ParSectoresId = new SqlParameter();
                ParSectoresId.ParameterName = "@sectores_id";
                ParSectoresId.SqlDbType = SqlDbType.Int;
                ParSectoresId.Value = Pedido.Sectores_id;
                SqlCmd.Parameters.Add(ParSectoresId);

                SqlParameter ParOrganismoId = new SqlParameter();
                ParOrganismoId.ParameterName = "@organismo_id";
                ParOrganismoId.SqlDbType = SqlDbType.Int;
                ParOrganismoId.Value = Pedido.Organismo_id;
                SqlCmd.Parameters.Add(ParOrganismoId);

                SqlParameter ParSectoresInternosId = new SqlParameter();
                ParSectoresInternosId.ParameterName = "@sectores_internos_id";
                ParSectoresInternosId.SqlDbType = SqlDbType.Int;
                ParSectoresInternosId.Value = Pedido.Sectores_internos_id;
                SqlCmd.Parameters.Add(ParSectoresInternosId);


                //ejecutar el codigo
                //rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "EL REGISTRO NO HA SIDO AGREGADO";

                var resultado = SqlCmd.ExecuteNonQuery();

                if (resultado == 1)
                {
                    rpta = Convert.ToString(SqlCmd.Parameters["@id_pedido"].Value.ToString());
                }
                else
                {
                    rpta = "no_insertado";
                }






            }
            catch (Exception ex)
            {

                rpta = ex.Message + ex.StackTrace;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }

            }
            return rpta;

        }//fin insertar

        //metodo buscar 
        public DataTable BuscarxTransaccion(DPedido Pedido)
        {//inicio buscar
            DataTable DtResultado = new DataTable("pedido");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_pedidos"; 

                SqlParameter ParNumeroTransaccion = new SqlParameter();
                ParNumeroTransaccion.ParameterName = "@num_transaccion";
                ParNumeroTransaccion.SqlDbType = SqlDbType.Int;
                ParNumeroTransaccion.Value = Pedido.Num_transaccion;
                SqlCmd.Parameters.Add(ParNumeroTransaccion);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin metodo buscar 

        //metodo buscar x Id_pedido
        public DataTable BuscarxId(DPedido Pedido)
        {//inicio buscar
            DataTable DtResultado = new DataTable("pedido");
            List<DPedido> listaPedido = new List<DPedido>();
            DPedido dPedidoAux = new DPedido();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sp_buscarPedidoxId";

                SqlParameter ParIdpedido = new SqlParameter();
                ParIdpedido.ParameterName = "@id_pedido";
                ParIdpedido.SqlDbType = SqlDbType.Int;
                ParIdpedido.Value = Pedido.Id_pedido;
                SqlCmd.Parameters.Add(ParIdpedido);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

                
            }
            catch (Exception)
            {

                return null;
            }

            return DtResultado;

        }//fin metodo buscar 

        //metodo buscar 
        public DataTable BuscarConcepto(DPedido Pedido)
        {//inicio buscar
            DataTable DtResultado = new DataTable("pedido");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spbuscar_pedido_concepto";

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 255;
                ParTextoBuscar.Value = Pedido.Textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin metodo buscar 


        //metodo editar
        /*public string EditarPedido(DPedido Pedido)
        {//inicio editar
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_editarPedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros
                SqlParameter ParId_Pedido = new SqlParameter();
                ParId_Pedido.ParameterName = "@id_pedido";
                ParId_Pedido.SqlDbType = SqlDbType.Int;
                ParId_Pedido.Value = Pedido.Id_pedido;
                SqlCmd.Parameters.Add(ParId_Pedido);

                SqlParameter ParPedido = new SqlParameter();
                ParPedido.ParameterName = "@pedido";
                ParPedido.SqlDbType = SqlDbType.VarChar;
                ParPedido.Value = Pedido.Pedido;
                SqlCmd.Parameters.Add(ParPedido);

                SqlParameter ParEstadoId = new SqlParameter();
                ParEstadoId.ParameterName = "@estado_id";
                ParEstadoId.SqlDbType = SqlDbType.Int;
                ParEstadoId.Value = Pedido.Estado_id;
                SqlCmd.Parameters.Add(ParEstadoId);

                SqlParameter ParCaracterPedidoId = new SqlParameter();
                ParCaracterPedidoId.ParameterName = "@caracter_pedido_id";
                ParCaracterPedidoId.SqlDbType = SqlDbType.Int;
                ParCaracterPedidoId.Value = Pedido.Caracter_pedido_id;
                SqlCmd.Parameters.Add(ParCaracterPedidoId);




                //ejecutar el codigo
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "HA FALLADO LA EDICION DEL REGISTRO";



            }
            catch (Exception ex)
            {

                rpta = ex.Message + ex.StackTrace;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }

            }
            return rpta;
        }//fin editar
        */

        //metodo editar 
        public string EditarPedido(DPedido Pedido)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_editarPedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // Parámetros
                SqlCmd.Parameters.Add("@id_pedido", SqlDbType.Int).Value = Pedido.Id_pedido;
                SqlCmd.Parameters.Add("@pedido", SqlDbType.VarChar, 250).Value = Pedido.Pedido;
                SqlCmd.Parameters.Add("@estado_id", SqlDbType.Int).Value = Pedido.Estado_id;
                SqlCmd.Parameters.Add("@caracter_pedido_id", SqlDbType.Int).Value = Pedido.Caracter_pedido_id;

                



            // ... (Tus parámetros anteriores se quedan exactamente igual)

            // 1. Ejecutamos el procedimiento almacenado directamente
            SqlCmd.ExecuteNonQuery();

            // 2. Si llegó a esta línea sin saltar al catch, la base de datos ya se actualizó con éxito.
            rpta = "OK"; 
        }
            catch (Exception ex)
            {
                // Si algo real falla (llave foránea, desconexión, etc.), saltará aquí
                rpta = ex.Message;
            }
            finally
        {
        if (SqlCon.State == ConnectionState.Open)
        {
            SqlCon.Close();
        }
     }
        return rpta;
     }

    //fin metodo editar


        public DataTable BuscarxFechas(DPedido Pedido)
        {//inicio buscar
            DataTable DtResultado = new DataTable("pedido");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sp_BuscarPedidosPorFechas";

                SqlParameter ParFecha_Inicio = new SqlParameter();
                ParFecha_Inicio.ParameterName = "@fecha_inicio";
                ParFecha_Inicio.SqlDbType = SqlDbType.VarChar;
                ParFecha_Inicio.Size = 50;
                ParFecha_Inicio.Value = Pedido.Fecha_inicio;
                SqlCmd.Parameters.Add(ParFecha_Inicio);

                SqlParameter ParFecha_Fin = new SqlParameter();
                ParFecha_Fin.ParameterName = "@fecha_fin";
                ParFecha_Fin.SqlDbType = SqlDbType.VarChar;
                ParFecha_Fin.Size = 50;
                ParFecha_Fin.Value = Pedido.Fecha_fin;
                SqlCmd.Parameters.Add(ParFecha_Fin);

                SqlParameter ParSectores_Internos_Id = new SqlParameter();
                ParSectores_Internos_Id.ParameterName = "@sectores_internos_id";
                ParSectores_Internos_Id.SqlDbType = SqlDbType.Int;
                ParSectores_Internos_Id.Value = Pedido.Sectores_internos_id;
                SqlCmd.Parameters.Add(ParSectores_Internos_Id);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin metodo buscar 

        //metodo obtener año actual 
        public int BuscarAnioActual()
        {//inicio buscar
            //DataTable DtResultado = new DataTable("pedido");
            int anio;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spObtenerAnioActual";
                anio = SqlCmd.ExecuteNonQuery();
              
            }
            catch (Exception)
            {

                return 0;
            }
            return anio;
        }//fin metodo buscar 

        //Obtener maximo valor de numero de transaccion

        public int BuscarNumeroTransaccionn()
        {//inicio buscar
            int num_transaccion;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "ObtenerTransaccionMaxima";
                num_transaccion = SqlCmd.ExecuteNonQuery();
               
            }
            catch (Exception)
            {

                return 1000;
            }
            return num_transaccion;
        }//fin metodo buscar 

        //inicio de procedimeitno de prueba
        public int BuscarNumeroTransaccion()
        {
            int num_transaccion = 0;
            using (SqlConnection SqlCon = new SqlConnection(Conexion.Cn)) // El 'using' cierra la conexión solo
            {
                try
                {
                    SqlCommand SqlCmd = new SqlCommand("ObtenerTransaccionMaxima", SqlCon);
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    // 1. IMPORTANTE: Declarar el parámetro de salida
                    SqlParameter parMax = new SqlParameter();
                    parMax.ParameterName = "@MaxNumero";
                    parMax.SqlDbType = SqlDbType.Int;
                    parMax.Direction = ParameterDirection.Output; // <--- Esto es clave
                    SqlCmd.Parameters.Add(parMax);

                    SqlCon.Open(); // 2. Abrir la conexión
                    SqlCmd.ExecuteNonQuery(); // 3. Ejecutar el SP

                    // 4. Recuperar el valor que el SP puso en el parámetro
                    num_transaccion = Convert.ToInt32(SqlCmd.Parameters["@MaxNumero"].Value);
                }
                catch (Exception ex)
                {
                    // Debug: Podés poner MessageBox.Show(ex.Message) para ver el error real
                    return 1000;
                }
            }
            return num_transaccion;
        }

        //fin procedimeinto de prueba
    }

}
