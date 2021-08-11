using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elitia_Entrepreneur.Clases
{
    public class Claseconexion
    {
        public static string conexxxion = "";
        public void conectar()
        {
            try 
            {
                if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    conexxxion = ConfigurationManager.ConnectionStrings["Elitia.Properties.Settings.ElitiaConnectionString"].ConnectionString;
                    MessageBox.Show("Exito");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falla", ex.Message);
            }
        
        }

    }

 }

