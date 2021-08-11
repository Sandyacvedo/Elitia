using Elitia;
using Elitia_Entrepreneur.Formularios.Secciones.Detalle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private bool btnproyecto = false;

        private bool btntarea = false;

        private void Menu_Load(object sender, EventArgs e)
        {
            ReallyCenterToScreen();
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
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
            btnproyecto = true;
        }

    private void btnTarea_Click(object sender, EventArgs e)
        {
            btntarea = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //if (btnproyecto=true)
            //{
            //    Detalle_proyecto dp = new Detalle_proyecto();
            //    dp.Show();
             
            //}
            //else if (btntarea=true)
            //{
     
            //    Detalle_proyecto dp = new Detalle_proyecto();
            //    dp.Show();
               
            }
        }
    }

