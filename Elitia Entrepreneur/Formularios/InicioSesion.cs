using Elitia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elitia_Entrepreneur
{
    public partial class InicioSesion : Heredar

    {
        

        public InicioSesion()
        {
            InitializeComponent();
           
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {

            Registrarse frm = new Registrarse();

            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
        private void InicioSesion_Load(object sender, EventArgs e)
        {
            ReallyCenterToScreen();
            //guna2Button1.PerformClick();
          

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        { 

            logins();

        }

        public void logins()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexxxion))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT id_usuario, usuario, perfil, Clave FROM Usuario WHERE usuario='" + txtuser.Text + "' AND Clave='" + txtpass.Text + "'", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Clases.Usuario.id_usuario = reader.GetInt32(reader.GetOrdinal("id_usuario"));
                            Clases.Usuario.Tipo_Usuario = reader.GetString(reader.GetOrdinal("perfil"));


                            Menu mn = new Menu();

                            this.Hide();
                            mn.ShowDialog();
                            this.Show();
                            txtpass.Text = "";
                            txtuser.Text = "";
                        }
                        else
                        {
                            mensaje(0,"Datos incorrectos.");
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

    }
}
