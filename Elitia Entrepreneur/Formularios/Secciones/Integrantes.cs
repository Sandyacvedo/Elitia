using Elitia;
using Elitia_Entrepreneur.Clases;
using Elitia_Entrepreneur.Formularios.Secciones.Detalle;
using Elitia_Entrepreneur.Formularios.Secciones.Mantenimiento;
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

namespace Elitia_Entrepreneur.Formularios.Secciones
{
    public partial class Integrantes : Heredar
    {
   
        public Integrantes()
        {
            InitializeComponent();
        }

        private void List_Load(object sender, EventArgs e)
        {
            ReallyCenterToScreen();
            Llenar_integrantes();
          
        }

        private void guna2Button_Edit_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button_Delete_Click(object sender, EventArgs e)
        {
            mensaje(2, "¿Desea Eliminar este elemento?");
        }
        public void Llenar_integrantes()
        {

            string cadenaconexion = conexxxion;
            SqlConnection con = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader dr;
            con.ConnectionString = cadenaconexion;
            comando.Connection = con;
            comando.CommandText = "	Select  isnull(up.id_unirProyecto,'') id_unirseproyecto, isnull(up.Estado,'') Estado, isnull(us.[image],'') imagen, isnull(us.nombre,'') nombre from Unirse_Proyecto up join Usuario us on us.id_usuario = up.id_usuario join Proyecto pr on pr.id_usuario = us.id_usuario where up.Estado = 1 ";
           // if (cmbopciones.Text == "Creador")
           // {
           //     comando.CommandText = "	Select  isnull(pr.id_usuario,'') id_usuario, isnull(us.[image],'') imagen, isnull(us.nombre,'') nombre, isnull(pr.nombre,'') proyecto, isnull(tp.Descripcion, '') descripcion, isnull (pr.fechacreacion, '') fechacreacion from Tipo_Proyecto tp join Proyecto pr on pr.id_tipoproyecto = tp.id_tipoProyecto  join Usuario us on us.id_usuario = pr.id_usuario where us.nombre like '%" + txtfiltro.Text + "%'";
           // }
           //else if (cmbopciones.Text == "Proyecto")
           // {
           //     comando.CommandText = "	Select  isnull(pr.id_usuario,'') id_usuario, isnull(us.[image],'') imagen, isnull(us.nombre,'') nombre, isnull(pr.nombre,'') proyecto, isnull(tp.Descripcion, '') descripcion, isnull (pr.fechacreacion, '') fechacreacion from Tipo_Proyecto tp join Proyecto pr on pr.id_tipoproyecto = tp.id_tipoProyecto  join Usuario us on us.id_usuario = pr.id_usuario where pr.nombre like '%" + txtfiltro.Text + "%'";
           // }
           //else if (cmbopciones.Text == "Tipo")
           // {
           //     comando.CommandText = "	Select  isnull(pr.id_usuario,'') id_usuario, isnull(us.[image],'') imagen, isnull(us.nombre,'') nombre, isnull(pr.nombre,'') proyecto, isnull(tp.Descripcion, '') descripcion, isnull (pr.fechacreacion, '') fechacreacion from Tipo_Proyecto tp join Proyecto pr on pr.id_tipoproyecto = tp.id_tipoProyecto  join Usuario us on us.id_usuario = pr.id_usuario where tp.Descripcion like '%" + txtfiltro.Text + "%'";
           // }
           //else if (cmbopciones.Text == "Creacion")
           // {
           //     comando.CommandText = "	Select  isnull(pr.id_usuario,'') id_usuario, isnull(us.[image],'') imagen, isnull(us.nombre,'') nombre, isnull(pr.nombre,'') proyecto, isnull(tp.Descripcion, '') descripcion, isnull (pr.fechacreacion, '') fechacreacion from Tipo_Proyecto tp join Proyecto pr on pr.id_tipoproyecto = tp.id_tipoProyecto  join Usuario us on us.id_usuario = pr.id_usuario where pr.fechacreacion like '%" + txtfiltro.Text + "%'";
           // }

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
                int renglon = dgvpublic.Rows.Add();

                dgvpublic.Rows[renglon].Cells[0].Value = dr.GetInt32(dr.GetOrdinal("id_unirseproyecto")).ToString();
                if (dr.GetSqlBinary(dr.GetOrdinal("imagen")).ToString() != "SqlBinary(0)")
                {
                    Byte[] imagen = new Byte[0];
                    imagen = (Byte[])(dr.GetSqlBinary(dr.GetOrdinal("imagen")));
                    MemoryStream mem = new MemoryStream(imagen);
                    ImageConverter converter = new ImageConverter();

                    dgvpublic.Rows[renglon].Cells[1].Value = Image.FromStream(mem);
                }
                dgvpublic.Rows[renglon].Cells[2].Value = dr.GetString(dr.GetOrdinal("nombre"));
               
            }
            label1.Text =  dgvpublic.Rows.Count.ToString();

        }

        private void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            Llenar_integrantes(); 
        }

        private void dgvpublic_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Mantenimiento_integrante frm = new Mantenimiento_integrante();
            frm.ShowDialog();
        }
    }
}
