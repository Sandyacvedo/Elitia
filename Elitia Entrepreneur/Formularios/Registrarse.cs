using Elitia;
using Elitia_Entrepreneur.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elitia_Entrepreneur
{
    public partial class Registrarse : Heredar


    {
        public Registrarse()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Registrarse_Load(object sender, EventArgs e)
        {

            ReallyCenterToScreen();
            cargar_pais();


        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_provincia();
        }

        private void guna2TextBox6_Click(object sender, EventArgs e)
        {

            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Archivo PNG|*.png";
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                pbprofile.Image = Image.FromFile(BuscarImagen.FileName);
                txtpicture.Text = BuscarImagen.FileName;
            }
        }

        public void cargar_pais()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conexxxion))
            {
                string query = "select  '' id_country, '' descripcion union select  isnull (ct.id_country, '') id_pais, isnull(ct.[name],'') descripcion  from countries ct";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cmbPais.DisplayMember = "descripcion";
            cmbPais.ValueMember = "id_pais";
            cmbPais.DataSource = dt;

        }

        public void cargar_provincia()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexxxion))
            {
                string query = "SELECT  ''as state_id, ''as descripcion FROM states st union select isnull (state_id, '') id_provincia,  isnull ([name], '') descripcion FROM states where country_id = " + cmbPais.SelectedIndex + " order by descripcion";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cmbProvincia.DisplayMember = "descripcion";
            cmbProvincia.ValueMember = "id_provincia";
            cmbProvincia.DataSource = dt;

        }

        public void cargar_ciudad()
        {

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(conexxxion))
            {
                //Se coloco un select de esta forma porque las relaciones de las tablas direcciones tienen errores
                string query = "SELECT  ''as id_cities, ''as descripcion FROM cities st union select isnull (id, '') id, isnull (ct.[name], '') descripcion FROM cities ct join states st on  st.state_id = ct.state_id join countries co on  co.id_country = st.country_id where co.[name] =  'Dominican Republic'";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cmbCiudad.DisplayMember = "descripcion";
            cmbCiudad.ValueMember = "id";
            cmbCiudad.DataSource = dt;

        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_ciudad();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guardar_cliente();
            //this.Close();
            //MessageBox.Show("Registrado");
        }

        public void guardar_cliente()
        {
            SqlConnection con = new SqlConnection(conexxxion);
            using (SqlCommand cmd = new SqlCommand("Usuario_agregar_modificar", con))
            {
                mayuscula();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = txtNombre.Text;
                cmd.Parameters.Add("@telefono", SqlDbType.NVarChar).Value = txtTelefono.Text;
                cmd.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = txtDireccion.Text;
                cmd.Parameters.Add("@correo", SqlDbType.NVarChar).Value = txtCorreo.Text;
                cmd.Parameters.Add("@perfil", SqlDbType.NVarChar).Value = cmbcuenta.Text;
                cmd.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = txtUsuario.Text;
                cmd.Parameters.Add("@clave", SqlDbType.NVarChar).Value = txtContraseña.Text;

                if (pbprofile.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    pbprofile.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] pict = stream.ToArray();
                    cmd.Parameters.Add("@image", SqlDbType.Image).Value = pict;
                }
                else
                {
                    cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = DBNull.Value;
                }
              
                cmd.Parameters.Add("@id_cities", SqlDbType.Int).Value = DBNull.Value;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
              
           

                try
                {
                    limpiar();
                    mensaje(4, "DATOS GUARDADOS CORRECTAMENTE");
                    this.Close();


                }
                catch (Exception)
                {
                    mensaje(0, "VALIDAR FORMATO");

                }
            }

        }

        private void cmbProvincia_TextChanged(object sender, EventArgs e)
        {
           // cargar_ciudad();
        }

        private void cmbcuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void limpiar()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtpicture.Text = "";
            txtContraseña.Text = "";
            cmbcuenta.Text = null;
            cmbCiudad.Text = "";
            cmbPais.Text = "";
            pbprofile.Image = null;


        }
    }
}
        
 
   
