using Inventario.Models.DAO;
using Inventario.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Controllers
{
    class AdminController{

        private List<DTOProducto> productos;
        private DAOProducto daoProducto;

        public AdminController(){
            productos = new List<DTOProducto>();
            daoProducto = new DAOProducto();
        }

        public void agregarProducto(){

        }

        public void eliminarProducto(){

        }

        public List<DTOProducto> listarPorducto(){
            productos = daoProducto.darProductos();
            return productos;
        }

        public void buscar(){

        }


    }
}
