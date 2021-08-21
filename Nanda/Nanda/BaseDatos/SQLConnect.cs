using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Nanda.BaseDatos
{
    class SQLConnect
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
        public int AddNewProduct(string name, string brand, string description, int price,  string categorie) //Agrega un usuario, engancha la interfaz 
        {
            int result = 0;
            try
            {
                result = con.Insert(new Products
                {
                    Name = name,
                    Brand= brand,
                    Description = description,
                    Price = price,
                    Category = categorie
                });
                EstadoMensaje = string.Format("Se agrego el producto correctamente :)", result);
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

        public IEnumerable<Products> GetAllProducts()
        {
            try
            {
                return con.Table<Products>(); //Devuelve contenido de la tabla
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Products>(); //Devuelve del enumarble el empty user
        }
        public IEnumerable<Sales> GetAllSales()
        {
            try
            {
                return con.Table<Sales>(); //Devuelve contenido de la tabla
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Sales>(); //Devuelve del enumarble el empty user
        }
        public IEnumerable<SalesDetails> GetSalesDetail(int id)
        {
            try
            {
                return con.Table<SalesDetails>(); //Devuelve contenido de la tabla
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<SalesDetails>(); //Devuelve del enumarble el empty user
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

