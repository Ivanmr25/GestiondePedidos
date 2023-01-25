using GestionPedidosIMR.Conexion;
using GestionPedidosIMR.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace GestionPedidosIMR.ViewModel
{
    public class NuevoPedidoViewModel : INotifyPropertyChanged
    {
        private Connection conexionDeDatos;
        public ICommand ComandoNuevo { get; set; }
        public ICommand ComandoGuardar { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public NuevoPedidoViewModel()
        {
            conexionDeDatos = new Connection();

            ListaLibros = conexionDeDatos.ObtenerPedidos();


            ActivarControlN = false;


            ComandoNuevo = new Command(AccionNuevo);
            ComandoGuardar = new Command(AccionGuardar);



        }
        private void AccionNuevo(object parametro)
        {

            ActivarControlN = true;




            NPedido = "";
            Cliente = "";
            DNI = "";
            Cantidad = 0;
            Fecha = "";


        }
        private void AccionGuardar(object parametro)
        {
            Pedido nuevoLibro;



            try
            {

                nuevoLibro = new Pedido();

                nuevoLibro.NPedido = NPedido;
                nuevoLibro.Cliente = Cliente;
                nuevoLibro.DNI = DNI;
                nuevoLibro.Cantidad = Cantidad;
                nuevoLibro.Fecha = Fecha;

                conexionDeDatos.GuardarNuevoPedido(nuevoLibro);

                ListaLibros.Add(nuevoLibro);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                ActivarControlN = true;



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
                OnPropertyChanged("ActivarControlN");
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

