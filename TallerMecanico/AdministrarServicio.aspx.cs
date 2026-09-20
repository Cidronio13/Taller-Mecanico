using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TallerMecanico
{
    public partial class AdministrarServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteMaster.IdServicio == -1)
            {
                btnGuardar.Text = "Guardar";
                btnCancelar.Visible = false;
                txtServicioID.Text = "Este campo no se puede modificar";
            }
            else
            {
                btnGuardar.Text = "Actualizar";
                btnCancelar.Visible = true;
                txtServicioID.Text = SiteMaster.IdServicio.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (SiteMaster.IdServicio == -1)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO Servicios(NombreServicio, Descripcion, Precio) VALUES(@NombreServicio, @Descripcion, @Precio)";
                        using (var cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@NombreServicio", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                            cmd.Parameters.AddWithValue("@Precio", txtPrecio.Text);

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
                        string query = "UPDATE Servicios SET NombreServicio = @NombreServicio, Descripcion = @Descripcion, Precio = @Precio WHERE ServicioID = @ID";
                        using (var cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@ID", txtServicioID.Text);
                            cmd.Parameters.AddWithValue("@NombreServicio", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                            cmd.Parameters.AddWithValue("@Precio", txtPrecio.Text);
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

            Response.Redirect("BuscarServicio.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            SiteMaster.IdServicio = -1;
            btnCancelar.Visible = false;
            txtServicioID.Text = "Este campo no se puede modificar";
            btnGuardar.Text = "Guardar";
        }
    }
}