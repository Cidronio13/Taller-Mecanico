using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TallerMecanico
{
    public partial class AdminUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteMaster.IdUsuario == -1)
            {
                btnGuardar.Text = "Guardar";
                btnCancelar.Visible = false;
                txtUsuarioID.Text = "Este campo no se puede modificar";
            }
            else
            {
                btnGuardar.Text = "Actualizar";
                btnCancelar.Visible = true;
                txtUsuarioID.Text = SiteMaster.IdUsuario.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (SiteMaster.IdUsuario == -1)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO USUARIO(USU_NOMBRE, USU_CLAVE, USU_NIVEL) VALUES(@NOMBRE, @CLAVE, @NIVEL)";
                        using (var cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@CLAVE", txtClave.Text);
                            cmd.Parameters.AddWithValue("@NIVEL", ddlNivel.SelectedIndex);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE USUARIO SET USU_NOMBRE = @NOMBRE, USU_CLAVE = @CLAVE, USU_NIVEL = @NIVEL WHERE USU_ID = @ID";
                        using (var cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@ID", SiteMaster.IdUsuario);
                            cmd.Parameters.AddWithValue("@CLAVE", txtClave.Text);
                            cmd.Parameters.AddWithValue("@NIVEL", ddlNivel.SelectedIndex);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarUsuarios.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            SiteMaster.IdUsuario = -1;
            btnCancelar.Visible = false;
            txtUsuarioID.Text = "Este campo no se puede modificar";
            btnGuardar.Text = "Guardar";
        }
    }
}