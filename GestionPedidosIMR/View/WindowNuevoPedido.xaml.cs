using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionPedidosIMR.View
{
    /// <summary>
    /// Lógica de interacción para WindowNuevoPedido.xaml
    /// </summary>
    public partial class WindowNuevoPedido : Window
    {
        public WindowNuevoPedido()
        {
            InitializeComponent();
            DataContext = new GestionPedidosIMR.ViewModel.NuevoPedidoViewModel();
        }
    }
}
