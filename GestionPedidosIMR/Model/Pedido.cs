using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPedidosIMR.Model
{
    public class Pedido
    {
        public String NPedido { get; set; }
        public String Cliente { get; set; }
        public String DNI { get; set; }
        public int Cantidad { get; set; }
        public String Fecha { get; set; }
    }
}
