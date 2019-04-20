using Inventario.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.Facade
{
    class Facade{

        private LoginController loginController;
        private List<string> valores;

        public Facade(){
            this.loginController = new LoginController();
            valores = new List<string>();
        }

        public List<string> logear(string cedula, string rol,string pass) {
            valores = loginController.login(cedula,rol,pass);
            MessageBox.Show(valores.ElementAt(0)+" "+ valores.ElementAt(1));
            return valores;
        }

    }
}
