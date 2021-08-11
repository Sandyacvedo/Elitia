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

namespace Elitia_Entrepreneur.Formularios.Secciones
{
    public partial class Publicaciones : Heredar
    {
        public Publicaciones()
        {
            InitializeComponent();
        }

        private void List_Load(object sender, EventArgs e)
        {
            guna2DataGridView_patient.Rows.Add(9);
            //guna2DataGridView_patient.Rows[0].Cells[1].Value = Properties.Resources._1;
            guna2DataGridView_patient.Rows[0].Cells[2].Value = "Dian Cooper";
            guna2DataGridView_patient.Rows[0].Cells[3].Value = "(239)555-2020";
            guna2DataGridView_patient.Rows[0].Cells[4].Value = "Cilacap";
            guna2DataGridView_patient.Rows[0].Cells[5].Value = "Jan 21,2020 -13:30";
           

           // guna2DataGridView_patient.Rows[1].Cells[1].Value = Properties.Resources._5;
            guna2DataGridView_patient.Rows[1].Cells[2].Value = "Dian Cooper";
            guna2DataGridView_patient.Rows[1].Cells[3].Value = "(239)555-2020";
            guna2DataGridView_patient.Rows[1].Cells[4].Value = "Cilacap";
            guna2DataGridView_patient.Rows[1].Cells[5].Value = "Jan 21,2020 -13:30";
          

           // guna2DataGridView_patient.Rows[2].Cells[1].Value = Properties.Resources._3;
            guna2DataGridView_patient.Rows[2].Cells[2].Value = "Dian Cooper";
            guna2DataGridView_patient.Rows[2].Cells[3].Value = "(239)555-2020";
            guna2DataGridView_patient.Rows[2].Cells[4].Value = "Cilacap";
            guna2DataGridView_patient.Rows[2].Cells[5].Value = "Jan 21,2020 -13:30";


            //guna2DataGridView_patient.Rows[3].Cells[1].Value = Properties.Resources._4;
            guna2DataGridView_patient.Rows[3].Cells[2].Value = "Dian Cooper";
            guna2DataGridView_patient.Rows[3].Cells[3].Value = "(239)555-2020";
            guna2DataGridView_patient.Rows[3].Cells[4].Value = "Cilacap";
            guna2DataGridView_patient.Rows[3].Cells[5].Value = "Jan 21,2020 -13:30";


            //guna2DataGridView_patient.Rows[4].Cells[1].Value = Properties.Resources._5;
            guna2DataGridView_patient.Rows[4].Cells[2].Value = "Dian Cooper";
            guna2DataGridView_patient.Rows[4].Cells[3].Value = "(239)555-2020";
            guna2DataGridView_patient.Rows[4].Cells[4].Value = "Cilacap";
            guna2DataGridView_patient.Rows[4].Cells[5].Value = "Jan 21,2020 -13:30";


            //guna2DataGridView_patient.Rows[5].Cells[1].Value = Properties.Resources._6;
            guna2DataGridView_patient.Rows[5].Cells[2].Value = "Dian Cooper";
            guna2DataGridView_patient.Rows[5].Cells[3].Value = "(239)555-2020";
            guna2DataGridView_patient.Rows[5].Cells[4].Value = "Cilacap";
            guna2DataGridView_patient.Rows[5].Cells[5].Value = "Jan 21,2020 -13:30";


           // guna2DataGridView_patient.Rows[6].Cells[1].Value = Properties.Resources._7;
            guna2DataGridView_patient.Rows[6].Cells[2].Value = "Dian Cooper";
            guna2DataGridView_patient.Rows[6].Cells[3].Value = "(239)555-2020";
            guna2DataGridView_patient.Rows[6].Cells[4].Value = "Cilacap";
            guna2DataGridView_patient.Rows[6].Cells[5].Value = "Jan 21,2020 -13:30";


          //  guna2DataGridView_patient.Rows[7].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView_patient.Rows[7].Cells[2].Value = "Dian Cooper";
            guna2DataGridView_patient.Rows[7].Cells[3].Value = "(239)555-2020";
            guna2DataGridView_patient.Rows[7].Cells[4].Value = "Cilacap";
            guna2DataGridView_patient.Rows[7].Cells[5].Value = "Jan 21,2020 -13:30";


          //  guna2DataGridView_patient.Rows[8].Cells[1].Value = Image.FromFile("photos\\1.png");
            guna2DataGridView_patient.Rows[8].Cells[2].Value = "Dian Cooper";
            guna2DataGridView_patient.Rows[8].Cells[3].Value = "(239)555-2020";
            guna2DataGridView_patient.Rows[8].Cells[4].Value = "Cilacap";
            guna2DataGridView_patient.Rows[8].Cells[5].Value = "Jan 21,2020 -13:30";

        }

        private void guna2Button_Edit_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
