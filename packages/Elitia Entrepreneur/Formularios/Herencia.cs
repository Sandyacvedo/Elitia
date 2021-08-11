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
        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == string.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

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

            //declaramos el comando para realizar la busqueda

            comando.CommandText = "select (select isnull(em.imagen,'')imagen from empresa em join Terminal te on te.id_empresa = em.id_empresa  where te.mac =  '" + GetMACAddress() + "')  imagen ";
           
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
            string ventana = "SOFTECA";
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
        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try

            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales >= 0)
            {
                dec = " PESOS CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }
        //funciones de convertir num  a letras
        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }

        private void Heredar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
