using Inventario.Models.Dao;
using Inventario.Models.DTO;
using MySql.Data.MySqlClient;
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
        BdContext ConectarBD();
        DTOUsuario BuscarUsuario(string cedula, string rol, string password); //hace el select y tambien sirve para el update
       
    }
}
