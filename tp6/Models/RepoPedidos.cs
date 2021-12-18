using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace tp6.Models
{
    public class RepoPedidos
    {
        public List<Pedido> GetAll(EstadoPedido estado = EstadoPedido.Todos)
        {
            List<Pedido> NPedidos = new List<Pedido>();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            if (estado == EstadoPedido.Todos)
            {
                command.CommandText = @"Select 
                                    IdPedido,
                                    NombreCliente,
                                    Observacion,
                                    NombreCadete,
                                    EstadoPedido
                                    From Pedidos
                                    Left Join Cadetes using (IdCadete)
                                    Inner Join Clientes using (IdCliente);";
            }
            else
            {
                command.CommandText = @"Select 
                                    IdPedido,
                                    NombreCliente,
                                    Observacion,
                                    NombreCadete,
                                    EstadoPedido
                                    From Pedidos
                                    Left Join Cadetes using (IdCadete)
                                    Inner Join Clientes using (IdCliente);";
                command.Parameters.AddWithValue("@EstadoPedido", estado);
            }


            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var ped = new Pedido();
                ped.Numpedido = Convert.ToInt32(reader["idPedido"]);
                ped.Obs = reader["Observacion"].ToString();
                ped.Estado_actual = (EstadoPedido)(Convert.ToInt32(reader["EstadoPedido"]));

                ped.NCliente = new Cliente();
                ped.NCliente.Nombre = reader["NombreCliente"].ToString();

                ped.Cadete = new Cadete();
                ped.Cadete.Nombre = reader["NombreCadete"].ToString();

                NPedidos.Add(ped);
            }
            reader.Close();
            conexion.Close();
            return NPedidos;
        }

        public List<Pedido> GetAll(TipoPedido tipo, int idCadete = 0)
        {
            List<Pedido> NPedidos = new List<Pedido>();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            if(idCadete == 0)
            {
                command.CommandText = @"Select 
                                IdPedido,
                                IdCliente,
                                NombreCliente,
                                DireccionCliente,
                                Observacion,
                                EstadoPedido,
                                TipoEnvio
                                From Pedidos
                                Inner Join Clientes using (IdCliente) where TipoEnvio = @TEnvio;";
                command.Parameters.AddWithValue("@TEnvio", tipo);
            }
            else
            {
                command.CommandText = @"Select 
                                    IdPedido,
                                    IdCliente,
                                    NombreCliente,
                                    DireccionCliente,
                                    Observacion,
                                    EstadoPedido,
                                    TipoEnvio
                                    From Pedidos
                                    Inner Join Clientes using (IdCliente) where idCadete = @idCad;";
                command.Parameters.AddWithValue("@TipoEnvio", tipo);
                command.Parameters.AddWithValue("@idCad", idCadete);
            }
            

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var ped = new Pedido();
                ped.Numpedido = Convert.ToInt32(reader["idPedido"]);
                ped.Obs = reader["Observacion"].ToString();
                ped.Estado_actual = (EstadoPedido)(Convert.ToInt32(reader["EstadoPedido"]));
                ped.Tipo = (TipoPedido)(Convert.ToInt32(reader["TipoEnvio"]));
                ped.NCliente = new Cliente();
                ped.NCliente.Id = Convert.ToInt32(reader["idCliente"]);
                ped.NCliente.Nombre = reader["NombreCliente"].ToString();
                ped.NCliente.Direccion = reader["DireccionCliente"].ToString();

                NPedidos.Add(ped);
            }

            reader.Close();
            conexion.Close();
            return NPedidos;
        }

        public void Alta(Pedido _pe)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = "Insert Into Pedidos(Observacion, TipoEnvio, EstadoPedido, idCliente) values (@Obs, @TipoEnvio, @Estado, @idCli)";
            command.Parameters.AddWithValue("@Obs", _pe.Obs);
            command.Parameters.AddWithValue("@Estado", _pe.Estado_actual);
            command.Parameters.AddWithValue("@TipoEnvio", _pe.Tipo);
            command.Parameters.AddWithValue("@idCli", _pe.NCliente.Id);
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void AgregarCadete(int _idPedido, int _idCadete)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = "UPDATE Pedidos SET idCadete = @idCadete WHERE idPedido = @idPedido";
            command.Parameters.AddWithValue("@idCadete", _idCadete);
            command.Parameters.AddWithValue("@idPedido", _idPedido);
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void Modificacion(Pedido pe)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = "UPDATE Pedidos SET Observacion = @Obs, TipoEnvio = @Tipo WHERE idPedido = @ID";
            command.Parameters.AddWithValue("@Obs", pe.Obs);
            command.Parameters.AddWithValue("@Tipo", pe.Tipo);
            command.Parameters.AddWithValue("@ID", pe.Numpedido);
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void Baja(int idPedido)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = "Delete From Pedidos Where idPedido = @idPedido";
            command.Parameters.AddWithValue("@idPedido", idPedido);
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarEstado(int idPedido, EstadoPedido estado)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();
            var command = conexion.CreateCommand();
            command.CommandText = "UPDATE Pedidos SET EstadoPedido = @Estado WHERE idPedido = @ID";
            command.Parameters.AddWithValue("@Estado", estado);
            command.Parameters.AddWithValue("@ID", idPedido);
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
