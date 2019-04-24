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
            this.database = null;
          
            this.reader = null;
            this.declaracion = "";
        }

        /*Metodos implementados de la Interfaz iDAOUSuario

        /* Patron de diseño SINGLETON */
        public BdContext ConectarBD()
        {
         if(database == null)
            {
               this.database =  new BdContext(); 
            }
            
            return database;
        }
        
        public DTOUsuario BuscarUsuario(string cedula, string role, string password)
        {
            int idUsuario = 1;
           string nombre = "", apellido = "";

            try {
                this.ConectarBD();
                declaracion = "SELECT * FROM Usuario WHERE cedula = '" + cedula + "' AND rol = '" + role + "' AND password = MD5('" + password + "');";
                this.reader = this.database.Consultar(declaracion);
            
                if (this.reader.HasRows)
                {
                    if (this.reader.Read())
                    {
                        idUsuario = reader.GetBoolean(0) ? 1 : 0;
                        nombre = reader.GetString(2);
                        apellido = reader.GetString(3);
                        
                        this.database.CerrarConexion();
                        return new DTOUsuario(idUsuario, cedula, nombre, apellido, role, password);
                    }

                }
                
                
                
            }catch (MySqlException ex){
                 MessageBox.Show(ex.ToString());
            }
            this.database.CerrarConexion();
            return null;
        }

    }
}
