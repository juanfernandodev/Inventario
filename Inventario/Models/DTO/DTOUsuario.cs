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

        public DTOUsuario(int idUsuario, string cedula, string nombre, string apellido, string rol, string password)
        {
            this.idUsuario = idUsuario;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.rol = rol;
            this.password = password;
        }

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }
        }

        public string Cedula
        {
            get
            {
                return cedula;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
        }

        public string Rol
        {
            get
            {
                return rol;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
        }
    }



}
