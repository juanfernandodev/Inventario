using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.Models.Dao
{
    class BdContext{

       public void conectarEimprimir()
        {
            string datos = "";
            string server = "arquitecturabd.mysql.database.azure.com";
            string database = "inventario";
            string user = "adminbd@arquitecturabd";
            string pass = "Arquitecturabd2019";
            string port = "3306";

            string cadenaConexion = "server=" + server + "; port=" + port + "; userid=" + user + "; password=" + pass + "; database=" + database + ";";
            MySqlConnection conexionBd = new MySqlConnection(cadenaConexion);

            try {
                conexionBd.Open();
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Usuario;", conexionBd);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    datos += reader.GetString(0) + " " + reader.GetString(1);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            MessageBox.Show(datos);
        }


    }
}
