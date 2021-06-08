using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string IDC { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string TipoReg { get; set; }
        public string NumGa { get; set; }
        public string TipoPre { get; set; }
        public string CondUso { get; set; }
        public DateTime? avaluo { get; set; }
        public int? valCom { get; set; }
        public int? supTot { get; set; }
        public int? supUsa { get; set; }
        public int? SupAgHab { get; set; }
        public int? SupGaHab { get; set; }
        public string obs { get; set; }
        public string sucursal { get; set; }
        public string region { get; set; }
        public string cadena { get; set; }
        public string segmento { get; set; }
    }
}
