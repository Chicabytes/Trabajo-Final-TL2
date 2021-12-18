using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using tp6.Addon;
using System.Data.SQLite;

namespace tp6.Models
{
    public class RepoUsuario
    {
        public void AltaUsuario(User usuario)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();

            var command = conexion.CreateCommand();
            command.CommandText = "INSERT INTO User(Usuario, Contrasena, Rol) VALUES (@Usuario, @Contrasena, @Rol)";
            command.Parameters.AddWithValue("@Usuario", usuario.Usuario);
            command.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
            command.Parameters.AddWithValue("@Rol", usuario.Rol);
            command.ExecuteNonQuery();

            conexion.Close();
        }
        public bool Validacion(User usuario)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();

            var command = conexion.CreateCommand();
            command.CommandText = "SELECT Usuario, Contrasena FROM User WHERE Usuario = @Usuario AND Contrasena = @Contrasena";

            command.Parameters.AddWithValue("@Usuario", usuario.Usuario);
            command.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();

            string user = "";
            string contra = "";
            while (reader.Read())
            {
                user = reader["Usuario"].ToString();
                contra = reader["Contrasena"].ToString();
            }
            conexion.Close();

            if (usuario.Usuario == user && usuario.Contrasena == contra)
            {
                return true;
            }

            return false;
        }
        public int GetIdUsuario(string user)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();

            var command = conexion.CreateCommand();
            command.CommandText = "SELECT idUsuario FROM User WHERE Usuario = @user";
            command.Parameters.AddWithValue("@user", user);
            command.ExecuteNonQuery();

            var reader = command.ExecuteReader();
            int idUsuario = 0;

            while (reader.Read())
            {
                idUsuario = Convert.ToInt32(reader["idUsuario"]);
            }
            conexion.Close();

            return idUsuario;
        }
        public Roles GetRol(string User)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Data\\tp6.db");
            var conexion = new SQLiteConnection(cadena);
            conexion.Open();

            var command = conexion.CreateCommand();
            command.CommandText = "SELECT Rol FROM User WHERE Usuario = @User";
            command.Parameters.AddWithValue("@User", User);
            command.ExecuteNonQuery();

            var reader = command.ExecuteReader();
            Roles rol = 0;

            while (reader.Read())
            {
                rol = (Roles)Convert.ToInt32(reader["Rol"]);
            }
            conexion.Close();

            return rol;
        }
    }
}
