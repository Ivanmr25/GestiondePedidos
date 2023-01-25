using GestionPedidosIMR.Conexion;
using GestionPedidosIMR.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestionPedidosIMR.ViewModel
{
    public class MainViewModel 
    {
        public ICommand ComandoNew{ get; set; }
        public ICommand ComandoUpdate{ get; set; }

        public MainViewModel()
        {
            ComandoNew = new Command(AccionNew);
            ComandoUpdate = new Command(AccionUpdate);

        }
        private void AccionNew(object parametro)
        {
           
            
                View.WindowNuevoPedido ventana1 = new View.WindowNuevoPedido();
                ventana1.ShowDialog();
            

           
        }
        private void AccionUpdate(object parametro)
        {
            
                View.WindowActualizarBorrar ventana2 = new View.WindowActualizarBorrar();
                ventana2.ShowDialog();
            
        }
    }
}
