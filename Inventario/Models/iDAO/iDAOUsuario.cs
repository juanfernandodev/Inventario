using Inventario.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventario.Models.iDAO
{   /*
       Aunque la app no realiza algunos metodos, se programan todos.
    */
    interface iDAOUsuario
    {
        void CrearUsuario(DTOUsuario usuario);
        DTOUsuario BuscarUsuario(string cedula); //hace el select y tambien sirve para el update
        void EliminarUsuario(int idusuario); 
    }
}
