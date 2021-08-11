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

namespace Elitia_Entrepreneur.Formularios.Secciones.Detalle
{
    public partial class Detalle_proyecto : Heredar
    {
        public Detalle_proyecto()
        {
            InitializeComponent();
        }
        int idproyecto;

        private void Detalle_proyecto_Load(object sender, EventArgs e)
        {
            Llenar_publicacion();
            ocultarbotones();
        }
        public void Llenar_publicacion()
        {

            string cadenaconexion = conexxxion;
            SqlConnection con = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader dr;
            con.ConnectionString = cadenaconexion;
            comando.Connection = con;
            comando.CommandText = "	Select  isnull(pr.id_usuario,'') id_usuario, isnull(us.[image],'') imagen, isnull(pr.tiempoEstimado, '')tiempo, isnull(pr.Id_Proyecto, '') id_proyecto, isnull (pr.descripcion,'') descripcion, isnull(us.nombre,'') nombre, isnull(pr.nombre,'') proyecto, isnull(tp.Descripcion, '') tipo, isnull (pr.fechacreacion, '') fechacreacion from Tipo_Proyecto tp join Proyecto pr on pr.id_tipoproyecto = tp.id_tipoProyecto  join Usuario us on us.id_usuario = pr.id_usuario where us.id_usuario = " + lblid.Text+"";


            //especificamos que es de tipo Text
            comando.CommandType = CommandType.Text;
            //se abre la conexion
            con.Open();
            //a la variable DataReader asignamos  el la variable de tipo SqlCommand
            dr = comando.ExecuteReader();
            //el ciclo while se ejecutará mientras lea registros en la tabla


            while (dr.Read())
            {
                //variable de tipo entero para ir enumerando los la filas del datagridview
                lblcreador.Text = dr.GetString(dr.GetOrdinal("nombre"));


                if (dr.GetSqlBinary(dr.GetOrdinal("imagen")).ToString() != "SqlBinary(0)")
                {
                    Byte[] imagen = new Byte[0];
                    imagen = (Byte[])(dr.GetSqlBinary(dr.GetOrdinal("imagen")));
                    MemoryStream mem = new MemoryStream(imagen);
                    ImageConverter converter = new ImageConverter();

                    pbprofile.Image = Image.FromStream(mem);
                }
                lblProyecto.Text = dr.GetString(dr.GetOrdinal("proyecto"));
                lblTipo.Text = dr.GetString(dr.GetOrdinal("tipo"));
                lblFecha.Text = dr.GetDateTime(dr.GetOrdinal("fechacreacion")).ToString();
                lblTiempo.Text = dr.GetString(dr.GetOrdinal("tiempo"));
                txtDescripcion.Text = dr.GetString(dr.GetOrdinal("descripcion"));
                idproyecto = dr.GetInt32(dr.GetOrdinal("id_proyecto"));


            }
        }

        public void guardar_solicitud()
        {
            SqlConnection con = new SqlConnection(conexxxion);
            using (SqlCommand cmd = new SqlCommand("Usuario_Unirse_Proyecto", con))
            {
                mayuscula();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_unir", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = Clases.Usuario.id_usuario;
                cmd.Parameters.Add("@id_Proyecto", SqlDbType.Int).Value = idproyecto;
                cmd.Parameters.Add("@Solicitud", SqlDbType.Bit).Value = 1;
                cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = 0;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                try
                {

                    mensaje(4, " SOLICITUD ENVIADA ");


                }
                catch (Exception)
                {
                    mensaje(0, "ERROR");

                }
            }
        }

        public void Validarregistro()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexxxion))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT id_usuario, id_proyecto FROM unirse_proyecto WHERE id_usuario='" + Clases.Usuario.id_usuario + "' AND id_proyecto='" + idproyecto + "'", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            mensaje(1,"Solicitud en Proceso");
                        }
                        else
                        {
                            guardar_solicitud();
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button_Delete_Click(object sender, EventArgs e)
        {
            Validarregistro();
        }

        public void ocultarbotones()
        {
            if (Clases.Usuario.Tipo_Usuario == "Integrante")
            {
                btnunirse.Visible = true;
            }
        }
    }
}
