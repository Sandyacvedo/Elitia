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

namespace Elitia
{
    public partial class Heredar : Form
    {
        public string conexxxion = "";
        public int formulario_devolver = 0;
        public Heredar()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                conexxxion = ConfigurationManager.ConnectionStrings["Elitia.Properties.Settings.ElitiaConnectionString"].ConnectionString;
            }
        }
        public int dev_form = 0; //Devolver formulario.

        protected void ReallyCenterToScreen()
        {
            Screen screen = Screen.FromControl(this);

            Rectangle workingArea = screen.WorkingArea;
            this.Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - this.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - this.Height) / 2)
            };
        }

        public void Cargarimagen()
        {
            //declaramos la cadena  de conexion
            string cadenaconexion = conexxxion;

            //variable de tipo Sqlconnection
            SqlConnection con = new SqlConnection();

            //variable de tipo Sqlcommand
            SqlCommand comando = new SqlCommand();

            //variable SqlDataReader para leer los datos
            SqlDataReader dr;

            con.ConnectionString = cadenaconexion;
            comando.Connection = con;
           
            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //limpiamos los renglones de la datagridview

            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            //el ciclo while se ejecutará mientras lea registros en la tabla
            while (dr.Read())
            {


                if (dr.GetSqlBinary(dr.GetOrdinal("imagen")).ToString() != "SqlBinary(0)")
                {
                    Byte[] imagen = new Byte[0];
                    imagen = (Byte[])(dr.GetSqlBinary(dr.GetOrdinal("imagen")));
                    MemoryStream mem = new MemoryStream(imagen);
                    ImageConverter converter = new ImageConverter();
                    foreach (Control c in Controls)
                    {
                        if (c is PictureBox)
                        {
                            ((PictureBox)c).Image = Image.FromStream(mem);
                        }
                    }
                }
               

            }
        }


        public void limpiar_texbox_combo()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
              
                if (c is CheckBox)
                {

                    ((CheckBox)c).Checked = false;

                }

                if (c is ComboBox)
                {
                    try
                    {

                        ((ComboBox)c).SelectedIndex = 0;
                    }
                    catch
                    {
                        ((ComboBox)c).Text = "";
                    }
                }
            }
        }
 


        public void mayuscula()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = c.Text.Trim();
                    c.Text = c.Text.ToUpper();

                }
                else if (c is ComboBox)
                {
                    c.Text = c.Text.Trim();
                    c.Text = c.Text.ToUpper();
                }
            }
        }
        public int mensaje(int valor_tipo, string mens)
        {

            //0 <- Error
            //1 <- Afirmación 
            //2 <- Pregunta
            //3 <- Information
            string ventana = "ELITIA";
            if (valor_tipo == 0)
            {
                MessageBox.Show(mens, ventana, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            if (valor_tipo == 1)
            {
                MessageBox.Show(mens, ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (valor_tipo == 2)
            {
                DialogResult boton = MessageBox.Show(mens, ventana, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (boton == DialogResult.OK)
                {
                    return 1;
                }
            }
            else if (valor_tipo == 3)
            {
                MessageBox.Show(mens, ventana, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mens, ventana);
            }

            return 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnLimpiaar_Click(object sender, EventArgs e)
		{
			limpiar_texbox_combo();
		}

        private void Heredar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
