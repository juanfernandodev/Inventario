using Inventario.Models.Dao;
using Inventario.Models.DTO;
using Inventario.Models.iDAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.Models.DAO
{
    class DAOUsuario : iDAOUsuario
    {
        private BdContext database;
        private string declaracion;
        private MySqlDataReader reader;

        public DAOUsuario()
        {
            database = null;
            reader = null;
            declaracion = "";
        }

        /// <summary>
        /// Patron de diseño Singleton, que solo crea una clase de bd si no existe otra
        /// </summary>
        /// <returns>Retorna un objeto abstracto de la bd</returns>
        public BdContext ConectarBD()
        {
            if (database == null)
            {
                database = new BdContext();
            }
            
            return database;
        }
        

        /// <summary>
        /// Solicita al objeto BD que realice una consulta a la BD
        /// </summary>
        /// <param name="cedula"></param>
        /// <param name="role"></param>
        /// <param name="password"></param>
        /// <returns>Retorna un DTOUsuario</returns>
        public DTOUsuario BuscarUsuario(string cedula, string role, string password)
        {
            int idUsuario = 1;
            string nombre = "", apellido = "";

            try {
                ConectarBD();
                declaracion = "SELECT * FROM Usuario WHERE cedula = '" + cedula + "' AND rol = '" + role + "' AND password = MD5('" + password + "');";
                reader = database.Consultar(declaracion);
            
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        idUsuario = reader.GetBoolean(0) ? 1 : 0;
                        nombre = reader.GetString(2);
                        apellido = reader.GetString(3);
                        database.CerrarConexion();
                        return new DTOUsuario(idUsuario, cedula, nombre, apellido, role, password);
                    }
                }
            }catch (MySqlException ex){
                 MessageBox.Show(ex.ToString());
            }
            database.CerrarConexion();
            return null;
        }

    }
}
