using Elitia;
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

namespace Elitia_Entrepreneur.Formularios.Secciones.Mantenimiento
{
    public partial class Mantenimiento_Proyecto : Heredar
    {
        public Mantenimiento_Proyecto()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void Llenar_proyecto()
        {

            //string cadenaconexion = conexxxion;
            //SqlConnection con = new SqlConnection();
            //SqlCommand comando = new SqlCommand();
            //SqlDataReader dr;
            //con.ConnectionString = cadenaconexion;
            //comando.Connection = con;
            //comando.CommandText = "Select  isnull(pr.Id_Proyecto,'') id_proyecto,  isnull(tp.Descripcion, '') tipoproyecto, isnull(pr.nombre,'') proyecto, isnull(pr.descripcion, '') prdescripcion, isnull(pr.tiempoEstimado, '') tiempo, isnull (pr.fechacreacion, '') fechacreacion from Tipo_Proyecto tp join Proyecto pr on pr.id_tipoproyecto = tp.id_tipoProyecto  join Usuario us on us.id_usuario = pr.id_usuario where pr.id_proyecto =" + lblid.Text + "";


            ////especificamos que es de tipo Text
            //comando.CommandType = CommandType.Text;
            ////se abre la conexion
            //con.Open();
            ////a la variable DataReader asignamos  el la variable de tipo SqlCommand
            //dr = comando.ExecuteReader();
            ////el ciclo while se ejecutará mientras lea registros en la tabla


            //while (dr.Read())
            //{
            //    //variable de tipo entero para ir enumerando los la filas del datagridview
            //    txtNombreproyecto.Text = dr.GetString(dr.GetOrdinal("proyecto"));
            //    cmbtipoproyecto.Text = dr.GetString(dr.GetOrdinal("tipoproyecto"));
            //    cmbestado.SelectedItem = 1;
            //    txttiempo.Text = dr.GetString(dr.GetOrdinal("tiempo"));
            //    txtdescripcion.Text = dr.GetString(dr.GetOrdinal("prdescripcion"));
            //}
        }

        private void mantenimiento_Proyecto_Load(object sender, EventArgs e)
        {
            ReallyCenterToScreen();
            Llenar_proyecto();
        }
    }
}

