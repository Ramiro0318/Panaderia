using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia
{
    public enum tipoPan {Quequito, Dona, Quaso, PanBlanco, GalletaChispas, QuequitoChispas, Pretzel, GalletaCuadrada, GalletaEstrella}
    public class Productos
    {
        public tipoPan pan { set; get; }
        public decimal precio { set; get; }

        public sbyte cantidad { set; get; }

        public string imagen { set; get; } = null!;
        
        public decimal total => precio * cantidad;
    }
}
