using Inventario.Models.Dao;
using Inventario.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Models.iDAO
{
    interface iDAOProducto
    {
        BdContext ConectarBD();
        void CrearProducto(DTOProducto producto);
        DTOProducto BuscarProducto(int numSerie); //hace el select y tambien sirve para el update
        void EliminarProducto(int numserie);
    }
}
