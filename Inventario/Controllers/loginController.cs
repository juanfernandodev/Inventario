using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.Models.DAO;
using Inventario.Models.DTO;
using Inventario.Views;

namespace Inventario.Controllers
{

    //Login vista;

    class LoginController{

        private DAOUsuario user;
        private DTOUsuario dtoUser;
        private List<string> valores;

        public LoginController(){
            user = new DAOUsuario();
            dtoUser = new DTOUsuario();
            valores = new List<string>();
        }

        public List<string> login(string cedula, string rol, string pass){
            dtoUser = user.BuscarUsuario(cedula, rol, pass);
            valores.Add(dtoUser.Nombre);
            valores.Add(dtoUser.Rol);
            return valores;
        }

        public string vista(){
            string rol;
            if (valores.Any()&& valores.ElementAt(1)=="Administrador"){
            
            }
            return "hola";
        }

    }
}
