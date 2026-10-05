using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Collections;
//using CapaDatos;

namespace CapaDatos
{
    public class DDetalle
    {
        private int _Id_detalle;
        private string _Detalle;
        private int _Cantidad;
        private int _Unidad_medida_id;
        private decimal _Precio;
        private int _Pedido_id;
        private string _Textobuscar;
        private int _Renglon;
        private string _Rubro;
        private int _Rubro_id;
        private string _Subrubro;
        private int _Subrubro_id;

        public int Id_detalle
        {
            get
            {
                return _Id_detalle;
            }

            set
            {
                _Id_detalle = value;
            }
        }

        public string Detalle
        {
            get
            {
                return _Detalle;
            }

            set
            {
                _Detalle = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public int Unidad_medida_id
        {
            get
            {
                return _Unidad_medida_id;
            }

            set
            {
                _Unidad_medida_id = value;
            }
        }

        public decimal Precio
        {
            get
            {
                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }

        public int Pedido_id
        {
            get
            {
                return _Pedido_id;
            }

            set
            {
                _Pedido_id = value;
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
        public int Renglon
        {
            get
            {
                return _Renglon;
            }

            set
            {
                _Renglon = value;
            }
        }
        public string Rubro
        {
            get
            {
                return _Rubro;
            }

            set
            {
                _Rubro = value;
            }
        }

        public int Rubro_id
        {
            get
            {
                return _Rubro_id;
            }

            set
            {
                _Rubro_id = value;
            }
        }
        public string Subrubro
        {
            get
            {
                return _Subrubro;
            }

            set
            {
                _Subrubro = value;
            }
        }
        public int Subrubro_id
        {
            get
            {
                return _Subrubro_id;
            }

            set
            {
                _Subrubro_id = value;
            }
        }

        //constructor vacio
        public DDetalle()
        {

        }
        //constructor con parametros
        public DDetalle(int id_detalle, string detalle, int cantidad, int unidad_medida_id, decimal precio, int pedido_id, string textobuscar, int renglon, string rubro, int rubro_id, string subrubro, int subrubro_id)
        {
            this.Id_detalle = id_detalle;
            this.Detalle = detalle;
            this.Cantidad = cantidad;
            this.Unidad_medida_id = unidad_medida_id;
            this.Precio = precio;
            this.Pedido_id = pedido_id;
            this.Textobuscar = textobuscar;
            this.Renglon = renglon;
            this.Rubro = rubro;
            this.Rubro_id = rubro_id;
            this.Subrubro = subrubro;
            this.Subrubro_id = subrubro_id;
        }

        //metodo insertar   
        public string Insertar(DDetalle Detalle)
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
                SqlCmd.CommandText = "spinsertar_detalle";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros
                SqlParameter ParId_Detalle = new SqlParameter();
                ParId_Detalle.ParameterName = "@id_detalle";
                ParId_Detalle.SqlDbType = SqlDbType.Int;
                ParId_Detalle.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId_Detalle);

                SqlParameter ParDetalle = new SqlParameter();
                ParDetalle.ParameterName = "@detalle";
                ParDetalle.SqlDbType = SqlDbType.VarChar;
                ParDetalle.Value = Detalle.Detalle;
                SqlCmd.Parameters.Add(ParDetalle);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParUnidadMedidaId = new SqlParameter();
                ParUnidadMedidaId.ParameterName = "@unidad_medida_id";
                ParUnidadMedidaId.SqlDbType = SqlDbType.Int;
                ParUnidadMedidaId.Value = Detalle.Unidad_medida_id;
                SqlCmd.Parameters.Add(ParUnidadMedidaId);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = Detalle.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParPedidoId = new SqlParameter();
                ParPedidoId.ParameterName = "@pedido_id";
                ParPedidoId.SqlDbType = SqlDbType.Int;
                ParPedidoId.Value = Detalle.Pedido_id;
                SqlCmd.Parameters.Add(ParPedidoId);

                //Se agrega porque la clumna rnglon de Detalle
                SqlParameter ParRenglon = new SqlParameter();
                ParRenglon.ParameterName = "@renglon";
                ParRenglon.SqlDbType = SqlDbType.Int;
                ParRenglon.Value = Detalle.Renglon;
                SqlCmd.Parameters.Add(ParRenglon);
                
                //Se agrega porque la clumna rubro de Detalle
                SqlParameter ParRubro_id = new SqlParameter();
                ParRubro_id.ParameterName = "@rubro_id";
                ParRubro_id.SqlDbType = SqlDbType.Int;
                ParRubro_id.Value = Detalle.Rubro_id;
                SqlCmd.Parameters.Add(ParRubro_id);

                //Se agrega porque la clumna subrubro de Detalle
                SqlParameter ParSubrubro_id = new SqlParameter();
                ParSubrubro_id.ParameterName = "@subrubro_id";
                ParSubrubro_id.SqlDbType = SqlDbType.Int;
                ParSubrubro_id.Value = Detalle.Subrubro_id;
                SqlCmd.Parameters.Add(ParSubrubro_id);


                //ejecutar el codigo
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "EL REGISTRO NO HA SIDO AGREGADO";


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

        //metodo editar
        public string EditarDetallexPedido(DDetalle Detalle)
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
                SqlCmd.CommandText = "sp_editarDetallexPedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros
                SqlParameter ParId_Pedido = new SqlParameter();
                ParId_Pedido.ParameterName = "@id_pedido";
                ParId_Pedido.SqlDbType = SqlDbType.Int;
                ParId_Pedido.Value = Detalle.Pedido_id;
                SqlCmd.Parameters.Add(ParId_Pedido);

                SqlParameter ParDetalle = new SqlParameter();
                ParDetalle.ParameterName = "@detalle";
                ParDetalle.SqlDbType = SqlDbType.VarChar;
                ParDetalle.Value = Detalle.Detalle;
                SqlCmd.Parameters.Add(ParDetalle);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = Detalle.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                //Se agrega porque la clumna rubro de Detalle
                SqlParameter ParRubro = new SqlParameter();
                ParRubro.ParameterName = "@rubro";
                ParRubro.SqlDbType = SqlDbType.Int;
                ParRubro.Value = Detalle.Rubro;
                SqlCmd.Parameters.Add(ParRubro);

                //Se agrega porque la clumna subrubro de Detalle
                SqlParameter ParSubrubro = new SqlParameter();
                ParSubrubro.ParameterName = "@subrubro";
                ParSubrubro.SqlDbType = SqlDbType.Int;
                ParSubrubro.Value = Detalle.Subrubro;
                SqlCmd.Parameters.Add(ParSubrubro);


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

        //metodo editar por id_detalle
        public string EditarDetallexIdDetalle(DDetalle Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_editarDetallexIdDetalle";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // 1. CORREGIDO: Ahora es de entrada (Input) y le pasamos el valor del ID
                SqlParameter ParId_Detalle = new SqlParameter();
                ParId_Detalle.ParameterName = "@id_detalle";
                ParId_Detalle.SqlDbType = SqlDbType.Int;
                ParId_Detalle.Direction = ParameterDirection.Input; // Entrada
                ParId_Detalle.Value = Detalle.Id_detalle; // <-- Asegurate de que tu objeto tenga esta propiedad
                SqlCmd.Parameters.Add(ParId_Detalle);

                SqlParameter ParDetalle = new SqlParameter();
                ParDetalle.ParameterName = "@detalle";
                ParDetalle.Size = 250;
                ParDetalle.SqlDbType = SqlDbType.VarChar;
                ParDetalle.Value = Detalle.Detalle;
                SqlCmd.Parameters.Add(ParDetalle);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Precision = 8; // Coincide con tu decimal(8,2)
                ParPrecio.Scale = 2;
                ParPrecio.Value = Detalle.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParSalida = new SqlParameter();
                ParSalida.ParameterName = "@mensaje";
                ParSalida.SqlDbType = SqlDbType.VarChar;
                ParSalida.Size = 70;
                ParSalida.Direction = ParameterDirection.Output; // Salida
                SqlCmd.Parameters.Add(ParSalida);

                // Ejecutamos el procedimiento
                SqlCmd.ExecuteNonQuery();

                // 2. CORREGIDO: Leemos directamente lo que el SP guardó en el parámetro OUTPUT
                if (SqlCmd.Parameters["@mensaje"].Value != DBNull.Value)
                {
                    rpta = SqlCmd.Parameters["@mensaje"].Value.ToString();
                }
                else
                {
                    rpta = "Error desconocido: El procedimiento no devolvió ningún mensaje.";
                }
            }
            catch (Exception ex)
            {
                rpta = "Error en Capa Datos: " + ex.Message;
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





        //metodo efitar detalle
        public string EditarDetallexIdPedido(DDetalle Detalle)
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
                SqlCmd.CommandText = "sp_editarDetallePedido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametros
                SqlParameter ParId_Detalle = new SqlParameter();
                ParId_Detalle.ParameterName = "@id_detalle";
                ParId_Detalle.SqlDbType = SqlDbType.Int;
                ParId_Detalle.Value = Detalle.Id_detalle;
                SqlCmd.Parameters.Add(ParId_Detalle);

                SqlParameter ParDetalle = new SqlParameter();
                ParDetalle.ParameterName = "@detalle";
                ParDetalle.SqlDbType = SqlDbType.VarChar;
                ParDetalle.Value = Detalle.Detalle;
                SqlCmd.Parameters.Add(ParDetalle);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Decimal;
                ParPrecio.Value = Detalle.Precio;
                SqlCmd.Parameters.Add(ParPrecio);




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





        //metodo obtener costo total del pedido 
        public decimal BuscarCostoTotal(DDetalle Detalle)
        {//inicio buscar
            //DataTable DtResultado = new DataTable("pedido");
            decimal costoTotal;
            decimal parametro = 0;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sp_ObtenerCostoTotalDetalle";

                SqlParameter ParIdPedido = new SqlParameter();
                ParIdPedido.ParameterName = "@id_pedido";
                ParIdPedido.SqlDbType = SqlDbType.Int;
                ParIdPedido.Value = Detalle.Pedido_id;
                SqlCmd.Parameters.Add(ParIdPedido);

                SqlParameter ParParametro_Salida = new SqlParameter();
                ParParametro_Salida.ParameterName = "@parametro_salida";
                ParParametro_Salida.SqlDbType = SqlDbType.Decimal;
                //ParParametro_Salida.Size = 2;
                ParParametro_Salida.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParParametro_Salida);

                //SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                costoTotal = SqlCmd.ExecuteNonQuery();
                //SqlDat.Fill(DtResultado);

                SqlCmd.ExecuteNonQuery();
                //return (string)SqlCmd.Parameters["@parametro_salida"].Value;
                parametro = (decimal)SqlCmd.Parameters["@parametro_salida"].Value;
                //return parametro;

            }
            catch (Exception)
            {

                //return 0;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }

            }
            return parametro;
        }//fin metodo buscar 

        //metodo buscar campos cantidad y precio 
        public DataTable BuscarCantidadPrecio(DDetalle Detalle)
        {//inicio buscar
            DataTable DtResultado = new DataTable("pedido");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spBuscarCamposCalculados";

                SqlParameter ParIdPedido = new SqlParameter();
                ParIdPedido.ParameterName = "@pedido_id";
                ParIdPedido.SqlDbType = SqlDbType.Int;
                ParIdPedido.Value = Detalle.Pedido_id;
                SqlCmd.Parameters.Add(ParIdPedido);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin metodo buscar

        //metodo buscar campos cantidad y precio 
        public DataTable BuscarDetalles(DDetalle Detalle)
        {//inicio buscar
            DataTable DtResultado = new DataTable("pedido");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "sp_ObtenerDetalles";

                SqlParameter ParIdPedido = new SqlParameter();
                ParIdPedido.ParameterName = "@pedido_id";
                ParIdPedido.SqlDbType = SqlDbType.Int;
                ParIdPedido.Value = Detalle.Pedido_id;
                SqlCmd.Parameters.Add(ParIdPedido);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception)
            {

                return null;
            }
            return DtResultado;
        }//fin metodo buscar






    }
}
