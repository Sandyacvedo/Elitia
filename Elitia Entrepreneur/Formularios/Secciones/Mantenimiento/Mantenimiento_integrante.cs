using Elitia;
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

namespace Elitia_Entrepreneur.Formularios.Secciones.Mantenimiento
{
    public partial class Mantenimiento_integrante : Heredar
    {
        public Mantenimiento_integrante()
        {
            InitializeComponent();
        }

        public void Llenar_integrante()
        {

            string cadenaconexion = conexxxion;
            SqlConnection con = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader dr;
            con.ConnectionString = cadenaconexion;
            comando.Connection = con;
            comando.CommandText = "Select  isnull(up.id_unirProyecto,'') id_unirseproyecto, isnull(up.Estado,'') Estado, isnull(pr.nombre,'') name, isnull(us.[image],'') imagen, isnull(us.nombre,'') nombre from Unirse_Proyecto up join Usuario us on us.id_usuario = up.id_usuario join Proyecto pr on up.id_usuario = us.id_usuario and up.id_Proyecto=pr.Id_Proyecto where up.Estado = 0";
           

            //            Creador
            //Proyecto
            //Tipo
            //Creacion

            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //limpiamos los renglones de la datagridview
            dgvpublic.Rows.Clear();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            //el ciclo while se ejecutará mientras lea registros en la tabla


            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                int renglon = dgvintegrante.Rows.Add();

                dgvintegrante.Rows[renglon].Cells[0].Value = dr.GetInt32(dr.GetOrdinal("id_unirseproyecto")).ToString();
                if (dr.GetSqlBinary(dr.GetOrdinal("imagen")).ToString() != "SqlBinary(0)")
                {
                    Byte[] imagen = new Byte[0];
                    imagen = (Byte[])(dr.GetSqlBinary(dr.GetOrdinal("imagen")));
                    MemoryStream mem = new MemoryStream(imagen);
                    ImageConverter converter = new ImageConverter();

                    dgvintegrante.Rows[renglon].Cells[1].Value = Image.FromStream(mem);
                }
                dgvintegrante.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("nombre"));
                dgvintegrante.Rows[renglon].Cells[3].Value = dr.GetString(dr.GetOrdinal("name"));


            }
        }
            public void selección()
        {
         

            String nombre = dgvintegrante.Rows[dgvintegrante.CurrentRow.Index].Cells[2].Value.ToString();
          // Boolean Check = Boolean.Parse(dgvintegrante.Rows[dgvintegrante.CurrentRow.Index].Cells[3].Value.ToString());

            txTnombre.Text = nombre;
            guna2ComboBox1.Text = "Pendiente";
            //if (Check == true)
            //{
            //    cmestado.SelectedIndex = 1;
            //}
            //else
            //    cmestado.SelectedIndex = 2;


        }

        private void Mantenimiento_integrante_Load(object sender, EventArgs e)
        {
            ReallyCenterToScreen();
            Llenar_integrante();
        }

        private void dgvintegrante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selección();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
