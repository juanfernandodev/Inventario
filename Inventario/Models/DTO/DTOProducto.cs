using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Models.DTO
{
    public class DTOProducto
    {
        private int numSerie;
        private string nombreProducto;
        private string proveedor;
        private string categoria;
        private int precioUnidad;
        private int cantidadExistente;

        public DTOProducto(int numSerie, string nombreProducto, string proveedor, string categoria, int precioUnidad, int cantidadExistente)
        {
            this.numSerie = numSerie;
            this.nombreProducto = nombreProducto;
            this.proveedor = proveedor;
            this.categoria = categoria;
            this.precioUnidad = precioUnidad;
            this.cantidadExistente = cantidadExistente;
        }

        public int NumSerie => numSerie;

        public string NombreProducto => nombreProducto;

        public string Proveedor => proveedor;

        public string Categoria => categoria;

        public int PrecioUnidad => precioUnidad;

        public int CantidadExistente => cantidadExistente;


    }
}
