using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;

namespace TallerMecanico
{
    public partial class Login : System.Web.UI.Page
    {
        public static string Nombre = "";   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteMaster.NivelUsu == 0)
            {
                LblSesion.Text = "Sesion iniciada como: "+Nombre;
            }
            else if (SiteMaster.NivelUsu == 1)
            {
                LblSesion.Text = "Sesion iniciada como: " + Nombre;
            }
            else if (SiteMaster.NivelUsu == -2)
            {
                LblSesion.Text = "Usuario no existente";
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT USU_NIVEL FROM USUARIO WHERE USU_NOMBRE =  AND USU_CLAVE = ", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SiteMaster.NivelUsu = reader.GetInt32(0);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                
            }
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", Convert.ToString(SiteMaster.NivelUsu), true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT USU_NIVEL FROM USUARIO WHERE USU_NOMBRE = '{TxtUsuario.Text}' AND USU_CLAVE = '{TxtContraseña.Text}'", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    SiteMaster.NivelUsu = reader.GetInt32(0);
                                }
                            }
                            else
                            {
                                SiteMaster.NivelUsu = -2;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }

            }
            Login.Nombre = TxtUsuario.Text;
            //Response.Redirect(Request.RawUrl);
            
            if (SiteMaster.NivelUsu == 0)
            {
                Response.Redirect("Catalogo.aspx");
            }
            else if (SiteMaster.NivelUsu == 1)
            {
                Response.Redirect("Catalogo.aspx");
            }
            else if (SiteMaster.NivelUsu == -2)
            {
                LblSesion.Text = "Usuario no existente";
            }
        }
    }
}