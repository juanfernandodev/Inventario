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

    //Login vista;

    class LoginController{

        private Form1 main;
        private DAOUsuario user;
        private DTOUsuario dtoUser;
        

        public LoginController(Form1 main){
            user = new DAOUsuario();
            dtoUser = new DTOUsuario();
            this.main = main;
            
        }

        public bool login(string cedula, string rol, string pass){
            dtoUser = user.BuscarUsuario(cedula, rol, pass);

            if(dtoUser != null)
            {
               
                
                this.main.AbrirVistaAdmin(rol, dtoUser.Nombre, dtoUser.Apellido);
                

            }

            return false;

        }


    }
}
