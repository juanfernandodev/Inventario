using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.Models.Dao
{
    public class BdContext {

        private static string server = "arquitecturabd.mysql.database.azure.com";
        private static string database = "inventario";
        private static string user = "adminbd@arquitecturabd";
        private static string pass = "Arquitecturabd2019";
        private static string port = "3306";
        private MySqlConnection conexionBd; //realiza la conexion a la BD
        private MySqlCommand cmd; //Ejecuta las sentencias o declaraciones a la BD
        private MySqlDataReader reader; //Obtiene los resultados de las declaraciones que obtiene el cmd

        public BdContext()
        {
            ConectarBD();
        }

        /// <summary>
        /// Crea el enlace de conexion a la base de datos
        /// </summary>
        private void ConectarBD()
        {
            conexionBd = new MySqlConnection("server=" + server + "; port=" + port + "; userid=" + user + "; password=" + pass + "; database=" + database + ";");
        }

        /// <summary>
        /// Devuelve la variable ConexionBd
        /// </summary>
        public MySqlConnection ConexionBd => conexionBd;

        /// <summary>
        /// Este metodo es para eliminacion, actualizacion, insertar, es decir para ALTERAR una tabla de la BD
        /// </summary>
        /// <param name="declaracion"></param>
        /// <returns>Returna un boolean confirmando si se puedo realizar la declaracion en la BD</returns>
        public bool Alterar(string declaracion)
        {
            conexionBd.Open();
            try
            {
                cmd = new MySqlCommand(declaracion, conexionBd);
                cmd.ExecuteReader();
                return true;
            }
            catch (MySqlException ex)
            {
                 MessageBox.Show(ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// Realiza una consulta a la BD
        /// </summary>
        /// <param name="declaracion"></param>
        /// <returns>Resultados de la consulta en un buffer</returns>
        public MySqlDataReader Consultar(string declaracion)
        {
            conexionBd.Open();
            cmd = new MySqlCommand(declaracion, conexionBd);
            reader = cmd.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Cierra la conexion de la BD
        /// </summary>
        public void CerrarConexion()
        {
            conexionBd.Close();
        }
        
    }
}