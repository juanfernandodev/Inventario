using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventario.Models.DAO;
using Inventario.Models.DTO;
using Inventario.Views;

namespace Inventario.Controllers
{
    class LoginController
    {

        private Form1 main;
        private DAOUsuario user;
        private DTOUsuario dtoUser;
        
        public LoginController(Form1 main){
            user = new DAOUsuario();
            dtoUser = new DTOUsuario();
            this.main = main;
            
        }

        /// <summary>
        /// Solicita al DAOusuario buscar las credenciales del usuario que se va a logear en el sistema
        /// </summary>
        /// <param name="cedula"></param>
        /// <param name="rol"></param>
        /// <param name="pass"></param>
        /// <returns>Confirma si el usuario tiene acceso al sistema o no</returns>
        public bool Login(string cedula, string rol, string pass)
        {
            dtoUser = user.BuscarUsuario(cedula, rol, pass);

            if (dtoUser != null)
            {
                if (rol.Equals("Administrador"))
                {
                    main.AbrirVistaAdmin(dtoUser.Nombre, dtoUser.Apellido);
                }
                else
                {
                    main.AbrirVistaCajero(dtoUser.Nombre, dtoUser.Apellido);
                }
                return true;
            }

            return false;
        }


    }
}
