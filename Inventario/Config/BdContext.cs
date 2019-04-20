using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.Models.Dao
{
    class BdContext {
        private string server;
        private string database;
        private string user;
        private string pass;
        private string port;
        private MySqlConnection conexionBd;

        public BdContext()
        {
            this.server = "arquitecturabd.mysql.database.azure.com";
            this.database = "inventario";
            this.user = "adminbd@arquitecturabd";
            this.pass = "Arquitecturabd2019";
            this.port = "3306";

        }

        public MySqlConnection Conectar()
        {

            string datos = "";


            string cadenaConexion = "server=" + this.server + "; port=" + port + "; userid=" + user + "; password=" + pass + "; database=" + database + ";";
            conexionBd = new MySqlConnection(cadenaConexion);
            return conexionBd;

        }

    }
}

/*
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
/*
