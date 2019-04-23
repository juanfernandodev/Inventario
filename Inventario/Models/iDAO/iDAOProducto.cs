﻿using Inventario.Models.Dao;
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

        Boolean CrearProducto(string nombreProducto, string proveedor, string categoria, int precioUnidad, int cantidadExistente);
        DTOProducto BuscarProductoNombre(string nombre); //hace el select y tambien sirve para el update
        Boolean EliminarProducto(int numserie);
        Boolean ActualizarProducto(int numeroserie, string nombreproducto, string proveedor, string categoria, int preciounidad, int cantidadexistente);
    }
}
