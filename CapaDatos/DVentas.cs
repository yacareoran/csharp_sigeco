using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
//using CapaDatos;

namespace CapaDatos
{
    
        public class DVentas
        {//inicio clase
            private int _Cantidad;
            private int _Unidad_id;
            private string _Unidad;
            private string _Concepto;
            private decimal _Precio_unitario;
            private decimal _Subtotal;
            private string _Rubro;
            private int _Rubro_id;
            private string _Subrubro;
            private int _Subrubro_id;            
            
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
            public int Unidad_id
            {
                get
                {
                    return _Unidad_id;
                }

                set
                {
                    _Unidad_id = value;
                }
            }

        public string Unidad
            {
                get
                {
                    return _Unidad;
                }

                set
                {
                    _Unidad = value;
                }
            }

            public string Concepto
            {
                get
                {
                    return _Concepto;
                }

                set
                {
                    _Concepto = value;
                }
            }

            public decimal Precio_unitario
            {
                get
                {
                    return _Precio_unitario;
                }

                set
                {
                    _Precio_unitario = value;
                }
            }

            public decimal Subtotal
            {
                get
                {
                    return _Subtotal;
                }

                set
                {
                    _Subtotal = value;
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


        public DVentas()
            {

            }

            public DVentas(int cantidad, int unidad_id, string unidad, string concepto, decimal precio_unitario, decimal subtotal, string rubro, int rubro_id, string subrubro, int subrubro_id)
            {
                this.Cantidad = cantidad;
                this._Unidad_id = unidad_id;
                this.Unidad = unidad;
                this.Concepto = concepto;
                this.Precio_unitario = precio_unitario;
                this.Subtotal = subtotal;
                this.Rubro = rubro;
                this.Rubro_id = rubro_id;
                this.Subrubro= subrubro;
                this.Subrubro_id= subrubro_id;
            }
        }//fin clase


}

