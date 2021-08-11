using Elitia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elitia_Entrepreneur.Formularios.Secciones.Mantenimiento
{
    public partial class Mantenimiento_Tarea : Heredar
    {
        public Mantenimiento_Tarea()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Mantenimiento_Tarea_Load(object sender, EventArgs e)
        {
            ReallyCenterToScreen();
        }
    }
}
