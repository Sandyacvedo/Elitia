using Elitia;
using Elitia_Entrepreneur.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elitia_Entrepreneur
{
    public partial class Registrarse : Heredar


    {
        Claseconexion dbconexion = new Claseconexion();
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
            this.dbconexion.conectar();

            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Archivo JPG|*.jpg";
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                //pbLogo.Image = Image.FromFile(BuscarImagen.FileName);
                guna2TextBox6.Text = BuscarImagen.FileName;
            }
        }

        public void cargar_pais()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(conexxxion))
            {
                string query = "select  '' id, '' descripcion union select  isnull (ct.id, '') id_pais, isnull(ct.[name],'') descripcion  from countries ct";

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
                string query = "SELECT  ''as id_cities, ''as descripcion FROM cities st union select isnull (id, '') id, isnull (ct.[name], '') descripcion FROM cities ct join states st on  st.state_id = ct.state_id where st.[name] =  'Duarte' order by descripcion";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cmbCiudad.DisplayMember = "descripcion";
            cmbCiudad.ValueMember = "id_cities";
            cmbCiudad.DataSource = dt;

        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar_ciudad();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("Registrado");
        }
    }
}
