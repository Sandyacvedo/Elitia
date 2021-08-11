using Elitia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
         
            Menu mn = new Menu();
            mn.Show();
           
        }
    }
}
