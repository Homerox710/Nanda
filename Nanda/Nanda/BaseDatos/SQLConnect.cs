using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Nanda.BaseDatos
{
    public class SQLConnect
    {
        private SQLiteConnection con;
        private static SQLConnect instancia;
        public static SQLConnect Instancia //Pregunta si la instancia es igual a null para hacer una excepcion. 
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instancia;
            }
        }
        public static void Inicializador(String filename) //Tiene de parametro el archivo que se va a usar
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new SQLConnect(filename);
        }
        private SQLConnect(String dbPath) //Crea tablas
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Users>(); //Crear tablas
        }
        public string EstadoMensaje;
        public int AddNewUser(string username, string full_name, string email, string password, int phone) //Agrega un usuario, engancha la interfaz 
        {
            int result = 0;
            try
            {
                result = con.Insert(new Users
                {
                    Username = username,
                    Full_Name = full_name,
                    Email = email,
                    Password = password,
                    Phone = phone
                });
                EstadoMensaje = string.Format("Se agrego el usuario correctamente :)", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; } //Convierte en mensaje la cantidad de filas ingresadas
            return result;
        }
        public IEnumerable<Users> GetAllUsers()
        {
            try
            {
                return con.Table<Users>(); //Devuelve contenido de la tabla
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Users>(); //Devuelve del enumarble el empty user
        }

        public IEnumerable<Users> Login()
        {
            try
            {
                return con.Table<Users>(); //Devuelve contenido de la tabla
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Users>(); //Devuelve del enumarble el empty user
        }
    }
}

