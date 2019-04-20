using Inventario.Models.Dao;
using Inventario.Models.DTO;
using Inventario.Models.iDAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Models.DAO
{
    class DAOProducto : iDAOProducto
    {
        private BdContext database;
        private MySqlConnection conexionbd;
        private string declaracion;
        private MySqlDataReader reader;

        public DAOProducto()
        {
            this.database = null;
            this.conexionbd = null;
            this.reader = null;
            this.declaracion = "";
        }


        /* Metodos implementados de iDAOProducto */
        
        /* Patron de diseño SINGLETON */
        public BdContext ConectarBD()
        {
            if (database == null)
            {
                database = new BdContext();
            }
            return database;
        }

        public DTOProducto BuscarProducto(int numSerie)
        {
            try
            {
                this.conexionbd = this.ConectarBD().ConexionBd;
                declaracion = "SELECT * FROM Usuario WHERE cedula = '" + cedula + "' AND rol = '" + role + "' AND password = MD5('" + password + "');";
                this.reader = this.database.consultar(declaracion);
                if (this.reader.Read())
                {
                    idUsuario = reader.GetBoolean(0) ? 1 : 0;
                    nombre = reader.GetString(2);
                    apellido = reader.GetString(3);
                    MessageBox.Show("Bienvenido " + nombre + " " + apellido + " con el ID " + idUsuario);
                    return new DTOUsuario(1, cedula, nombre, apellido, role, password);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return null;
        }

        public void CrearProducto(DTOProducto producto)
        {
            throw new NotImplementedException();
        }

        public void EliminarProducto(int numserie)
        {
            throw new NotImplementedException();
        }
    }
}
