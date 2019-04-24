using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Models.DTO
{
    public class DTOUsuario
    {
        private int idUsuario;
        private string cedula;
        private string nombre;
        private string apellido;
        private string rol;
        private string password;

        public DTOUsuario()
        {
        }

        public DTOUsuario(int idUsuario, string cedula, string nombre, string apellido, string rol, string password)
        {
            this.idUsuario = idUsuario;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.rol = rol;
            this.password = password;
        }

        public int IdUsuario => idUsuario;

        public string Cedula => cedula;

        public string Nombre => nombre;

        public string Apellido => apellido;

        public string Rol => rol;

        public string Password => password;
    }

}
