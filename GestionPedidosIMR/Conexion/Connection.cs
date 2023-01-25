using GestionPedidosIMR.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestionPedidosIMR.Conexion
{
    public class Connection
    {
        private string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\diurno\\Downloads\\DatabasePedidos.accdb";


        // Variables para recuperar información de la Base de datos
        private OleDbConnection CN;
        private OleDbCommand CMD;
        private OleDbDataReader RDR;


        public ObservableCollection<Pedido> ObtenerPedidos()
        {
          
            CN = new OleDbConnection(cadenaConexion);
           
            CMD = new OleDbCommand("SELECT * FROM Tpedidos", CN);
            // Tipo de comando.
            CMD.CommandType = CommandType.Text;

           
            ObservableCollection<Pedido> ListaDeLibros =
                new ObservableCollection<Pedido>();

            try // Intentamos...
            {
                CN.Open(); // Abrir la conexión.
                RDR = CMD.ExecuteReader(); // Ejecutar la instrucción OleDb SELECT.

                while (RDR.Read()) // recorrer todos los registros.
                {

                    // Crear un objecto que "envuelve" el registro actual.
                    Pedido libroActual = new Pedido();
                    libroActual.NPedido = (string)RDR["NPedido"];
                    libroActual.Cliente = (string)RDR["Cliente"];
                    libroActual.DNI = (string)RDR["DNI"];
                    libroActual.Cantidad = (int)RDR["Cantidad"];
                    libroActual.Fecha = (string)RDR["Fecha"];


                    // Agregar el objeto a la coleccion.
                    ListaDeLibros.Add(libroActual);
                }
            }
            catch (Exception ex)
            {
                throw ex; // Lanzamos excepción.
            }
            finally
            {
                CN.Close(); // Cerramos la conexión.
            }

            return ListaDeLibros; // Regresamos la lista.
        }
        public void GuardarNuevoPedido(Pedido nuevopedido)
        {
            CN = new OleDbConnection(cadenaConexion);
            CMD = new OleDbCommand();
            CMD.Connection = CN;
            CMD.CommandType = CommandType.Text;


            CMD.CommandText = "INSERT INTO Tpedidos (NPedido, Cliente,DNI, Cantidad, Fecha) VALUES (@p1,@p2,@p3,@p4,@p5);";


            // establecemos los valores que tomarán los parámetros de la instrucción OleDb.
            CMD.Parameters.AddWithValue("@p1", nuevopedido.NPedido);
            CMD.Parameters.AddWithValue("@p2", nuevopedido.Cliente);
            CMD.Parameters.AddWithValue("@p3", nuevopedido.DNI);
            CMD.Parameters.AddWithValue("@p4", nuevopedido.Cantidad);
            CMD.Parameters.AddWithValue("@p5", nuevopedido.Fecha);


            CN.Open();
            CMD.ExecuteNonQuery();

            MessageBox.Show("Registro agregado exitosamente");


            CN.Close();



        }
        public int BorrarPedido(string npedido)
        {
            CN = new OleDbConnection(cadenaConexion);
            CMD = new OleDbCommand("DELETE FROM TPedidos WHERE NPedido = @p0", CN);
            CMD.CommandType = CommandType.Text;
            CMD.Parameters.AddWithValue("@p0", npedido);

            try
            {
                CN.Open();
                return CMD.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CN.Close();
            }
        }

        public int ActualizarLibroExistente(string NPedido, string Cliente, string DNI, int Cantidad,
           string Fecha)
        {
            CN = new OleDbConnection(cadenaConexion);
            CMD = new OleDbCommand
            ("UPDATE TPedidos " +
            "SET NPedido = @p1, Cliente = @p2, DNI = @p3, Cantidad = @p4, Fecha = @p5 " +
            "WHERE NPedido = @p1 " , CN);

            CMD.CommandType = CommandType.Text;


            CMD.Parameters.AddWithValue("@p1", NPedido);
            CMD.Parameters.AddWithValue("@p2", Cliente);
            CMD.Parameters.AddWithValue("@p3", DNI);
            CMD.Parameters.AddWithValue("@p4", Cantidad);
            CMD.Parameters.AddWithValue("@p5", Fecha);

            try
            {
                CN.Open();
                return CMD.ExecuteNonQuery();// Devuelve el número de filas afectadas en este caso debe ser 1.
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CN.Close();
            }
        }


    }
}
