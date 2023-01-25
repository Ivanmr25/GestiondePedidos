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
    public class ActualizarBorrarViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Connection conexionDeDatos;
        public ICommand ComandoBorrar { get; set; }
        public ICommand ComandoActualizar{ get; set; }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ActualizarBorrarViewModel()
        {
           
            conexionDeDatos = new Connection();
            ComandoBorrar = new Command(AccionBorrar);
            ComandoActualizar = new Command(AccionActualizar);
            ListaLibros = conexionDeDatos.ObtenerPedidos();
        }
        private Pedido libroSeleccionado;
        public Pedido LibroSeleccionado
        {
            get { return libroSeleccionado; }
            set
            {
                libroSeleccionado = value;
                OnPropertyChanged("LibroSeleccionado");

                if (libroSeleccionado != null)

                {



                    NPedido = libroSeleccionado.NPedido;
                   Cliente = libroSeleccionado.Cliente;
                    DNI = libroSeleccionado.DNI;
                    Cantidad = libroSeleccionado.Cantidad;
                    Fecha = libroSeleccionado.Fecha;
                }
            }
        }
        private void AccionBorrar(object parametro)
        {
            if (LibroSeleccionado != null)
            {

                if (MessageBox.Show("¿Seguro que desea eliminar el Pedido seleccionado?",
                       "Confirmar eliminacion de registro", MessageBoxButton.YesNo,
                       MessageBoxImage.Warning) == MessageBoxResult.Yes) 
                {

                    int resultado = 0;

                    try
                    {


                        resultado = conexionDeDatos.BorrarPedido(NPedido);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (resultado > 0)// Por que afectó a un registro
                    {

                        ListaLibros.Remove(LibroSeleccionado);

                        NPedido = "";
                        Cliente = "";
                        DNI = "";
                        Cantidad = 0;
                        Fecha = "";

                    }
                }

                LibroSeleccionado = null;
            }
            else
            {
                MessageBox.Show("Tienes que seleccionar un Pedido de la lista para poder borrarlo",
                    "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void AccionActualizar(object parametro)
        {
          

                try
                {


                    int resultado = 0;


                    resultado = conexionDeDatos.ActualizarLibroExistente(NPedido,Cliente, DNI,
                        Cantidad, Fecha);


                    if (resultado > 0) // si se actualizó el registro en la tabla ...
                    {
                        MessageBox.Show("Pedido Modificado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                         ListaLibros = conexionDeDatos.ObtenerPedidos();
                    NPedido = "";
                    Cliente = "";
                    DNI = "";
                    Cantidad = 0;
                    Fecha = "";


                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    


                }



            
        }
        private string npedido;
        public string NPedido
        {
            get { return npedido; }
            set
            {
                npedido = value;
                OnPropertyChanged("NPedido");
            }
        }


        private string cliente;
        public string Cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;
                OnPropertyChanged("Cliente");
            }
        }

        private string dni;
        public string DNI
        {
            get { return dni; }
            set
            {
                dni = value;
                OnPropertyChanged("DNI");
            }
        }


        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                OnPropertyChanged("Cantidad");
            }
        }
        private string fecha;
        public string Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                OnPropertyChanged("Fecha");
            }
        }
        private bool activarControlN;

        public bool ActivarControlN
        {
            get { return activarControlN; }
            set
            {
                activarControlN = value;
                OnPropertyChanged("ActivarControlB1");
            }
        }
        private ObservableCollection<Pedido> listaLibros;

        public ObservableCollection<Pedido> ListaLibros
        {
            get { return listaLibros; }
            set
            {
                listaLibros = value;
                OnPropertyChanged("ListaLibros");
            }
        }
    }
}

