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
        private List<DTOProducto> productos;

        public DAOProducto()
        {
            this.database = null;
            this.conexionbd = null;
            this.reader = null;
            this.declaracion = "";
            this.productos = null;
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
        /* Actualiza la List de los productos con la informacion de la BD*/
        public List<DTOProducto> actualizarProductos()
        {
            this.productos = new List<DTOProducto>();
            this.conexionbd = this.ConectarBD().ConexionBd;
            declaracion = "Select * FROM Usuario";
            this.reader = this.database.consultar(declaracion);
            
            while (this.reader.Read())
            {
                productos.Add(new DTOProducto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5)));
            }

            return productos;
        }
        /* Metodo que busca en la lista de productos si se 
           encuentra un producto con el nombre pasado en parametro */
        public DTOProducto BuscarProductoNombre(string nombre)
        {
            foreach (DTOProducto producto in productos)
            {
                if (producto.NombreProducto.Equals("nombre"))
                {
                    return producto;
                }
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

        public DTOProducto BuscarProducto(int numSerie)
        {
            throw new NotImplementedException();
        }
    }
}
