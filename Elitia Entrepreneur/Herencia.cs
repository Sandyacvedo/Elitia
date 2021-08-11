using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Elitia_Entrepreneur
{
    public partial class Herencia : Form
    {
        public string conexxxion = "";
        public int formulario_devolver = 0;
        public Herencia()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                conexxxion = ConfigurationManager.ConnectionStrings["Elitia.Properties.Settings.ElitiaConnectionString"].ConnectionString;
            }
        }
        public void Llenar_pais()
        {

            string cadenaconexion = conexxxion;
            SqlConnection con = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader dr;
            con.ConnectionString = cadenaconexion;
            comando.Connection = con;
            comando.CommandText = "select isnull(coun.[name], '') paises, isnull(coun.id, '') id  from countries coun ";

            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //limpiamos los renglones de la datagridview
            dataGridView1.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            //el ciclo while se ejecutará mientras lea registros en la tabla


            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dataGridView1.Rows.Add();

                dataGridView1.Rows[renglon].Cells[0].Value = dr.GetInt32(dr.GetOrdinal("id")).ToString();
                dataGridView1.Rows[renglon].Cells[1].Value = dr.GetString(dr.GetOrdinal("paises"));
                //dataCliente.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("nombre"));
                //dataCliente.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("apellido"));
                //dataCliente.Rows[renglon].Cells[4].Value = dr.GetDateTime(dr.GetOrdinal("fechanacimiento")).ToString("yyyy-MM-dd");
                //dataCliente.Rows[renglon].Cells[5].Value = dr.GetString(dr.GetOrdinal("correo"));
                //dataCliente.Rows[renglon].Cells[6].Value = dr.GetString(dr.GetOrdinal("telefono"));
                //dataCliente.Rows[renglon].Cells[7].Value = dr.GetString(dr.GetOrdinal("telefono2"));
                //dataCliente.Rows[renglon].Cells[8].Value = dr.GetString(dr.GetOrdinal("trabajo"));
                //dataCliente.Rows[renglon].Cells[9].Value = dr.GetString(dr.GetOrdinal("ocupacion"));
                //dataCliente.Rows[renglon].Cells[10].Value = dr.GetString(dr.GetOrdinal("pais"));
                //dataCliente.Rows[renglon].Cells[11].Value = dr.GetString(dr.GetOrdinal("provincia"));
                //dataCliente.Rows[renglon].Cells[12].Value = dr.GetString(dr.GetOrdinal("municipio"));
                //dataCliente.Rows[renglon].Cells[13].Value = dr.GetString(dr.GetOrdinal("sector"));
                //dataCliente.Rows[renglon].Cells[14].Value = dr.GetString(dr.GetOrdinal("direccion"));


            }
        }
        public int dev_form = 0; //Devolver formulario.

        private void Herencia_Load(object sender, EventArgs e)
        {
           Llenar_pais();
        }
    }
}
