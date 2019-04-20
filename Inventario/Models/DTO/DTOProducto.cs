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

        public int NumSerie
        {
            get{
                return this.numSerie;
            }
        }

        public string NombreProducto
        {
            get
            {
                return this.nombreProducto;
            }
        }

        public string Proveedor
        {
            get
            {
                return this.proveedor;
            }
        }

        public string Categoria
        {
            get
            {
                return this.categoria;
            }
        }

        public int PrecioUnidad
        {
            get
            {
                return this.precioUnidad;
            }
        }

        public int CantidadExistente
        {
            get
            {
                return this.cantidadExistente;
            }
        }



    }
}
