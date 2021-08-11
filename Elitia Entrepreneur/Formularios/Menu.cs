using Elitia;
using Elitia_Entrepreneur.Formularios.Secciones.Detalle;
using Elitia_Entrepreneur.Formularios.Secciones.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elitia_Entrepreneur
{
    public partial class Menu : Heredar
 
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            ReallyCenterToScreen();
            cargarperfil();
            btninicio.PerformClick();
            ocultarb();
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            ocultarbotones();
            guna2PictureBox_val.Image = Properties.Resources.nuev;
            label_val.Text = "Inicio";
            container(new Formularios.Secciones.Publicaciones());

        }

        private void container(object _form)
        {
            if (guna2Panel_container.Controls.Count > 0)
                this.guna2Panel_container.Controls.Clear();
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            guna2Panel_container.Controls.Add(fm);
            guna2Panel_container.Tag = fm;
            fm.Show();
        }

        private void btnProyecto_Click(object sender, EventArgs e)
        {
            
                btnNuevaTarea.Visible = false;
                btnNuevoProyecto.Visible = true;
               
            guna2PictureBox_val.Image = Properties.Resources.projects;
            label_val.Text = "Proyectos";
            container(new Formularios.Secciones.Proyectos());
        }

        private void btnTarea_Click(object sender, EventArgs e)
        {

            if (lblperfil.Text != "Integrantes")
            {

                btnNuevoProyecto.Visible = false;
                btnNuevaTarea.Visible = true;
                guna2PictureBox_val.Image = Properties.Resources.task;
                label_val.Text = "Tareas";
                container(new Formularios.Secciones.Tarea());

            }
            else
            {
      
                //guna2PictureBox_val.Image = Properties.Resources.task;
                //label_val.Text = "Tareas";
                //container(new Formularios.Secciones.Publicaciones());
            }
           

            
        }
        private void btnIntegran_Click(object sender, EventArgs e)
        {
            ocultarbotones();
            guna2PictureBox_val.Image = Properties.Resources.people;
            label_val.Text = "Integrantes";
            container(new Formularios.Secciones.Integrantes());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Mantenimiento_Proyecto mp = new Mantenimiento_Proyecto();
            mp.Show();


        }

        private void btnNuevaTarea_Click(object sender, EventArgs e)
        {
            Mantenimiento_Tarea mp = new Mantenimiento_Tarea();
            mp.ShowDialog();
        }

        public void cargarperfil()
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

            comando.CommandText = "select isnull(nombre, '') nombre, isnull(Perfil, '') perfil, isnull([Image],'') imagen from usuario where id_usuario = "+Clases.Usuario.id_usuario+"";
;

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
                //variable de tipo entero para ir enumerando los la filas del datagridview
                lblnombre.Text = dr.GetString(dr.GetOrdinal("nombre"));
                lblperfil.Text = dr.GetString(dr.GetOrdinal("perfil"));

                if (dr.GetSqlBinary(dr.GetOrdinal("imagen")).ToString() != "SqlBinary(0)")
                {
                    Byte[] imagen = new Byte[0];
                    imagen = (Byte[])(dr.GetSqlBinary(dr.GetOrdinal("imagen")));
                    MemoryStream mem = new MemoryStream(imagen);
                    ImageConverter converter = new ImageConverter();

                    pbprofile.Image = Image.FromStream(mem);
                }
            }

        }
        public void ocultarb()
        {
            if (lblperfil.Text == "Integrante")
            {
                btnProyecto.Visible = false;
            }
        }
        private void ocultarbotones()
        {
            btnNuevoProyecto.Visible = false;
            btnNuevaTarea.Visible = false;
        }

        private void btnNuevoProyecto_Click(object sender, EventArgs e)
        {
            Mantenimiento_Proyecto frm = new Mantenimiento_Proyecto();
            frm.ShowDialog();
         }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            //Convert The resource Data into Byte[]

            byte[] PDF = Properties.Resources.Manual_Usuario;



            MemoryStream ms = new MemoryStream(PDF);



            //Create PDF File From Binary of resources folders help.pdf

            FileStream f = new FileStream("Manual_Usuario.pdf", FileMode.OpenOrCreate);



            //Write Bytes into Our Created help.pdf

            ms.WriteTo(f);

            f.Close();

            ms.Close();



            // Finally Show the Created PDF from resources

            Process.Start("Manual_Usuario.pdf");
        }
    }

   
    }




