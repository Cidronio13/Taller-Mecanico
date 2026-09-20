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
    public partial class AdministrarEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteMaster.IdEmpleado == -1)
            {
                btnGuardar.Text = "Guardar";
                btnCancelar.Visible = false;
                txtEmpleadoID.Text = "Este campo no se puede modificar";
            }
            else
            {
                btnGuardar.Text = "Actualizar";
                btnCancelar.Visible = true;
                txtEmpleadoID.Text = SiteMaster.IdEmpleado.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fechaNacimiento;
            if (DateTime.TryParse(txtFecha.Text, out fechaNacimiento))
            {
            }
            else
            {
            }
            if (SiteMaster.IdEmpleado == -1)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO Empleados(Nombre, Apellido, Puesto, Telefono, CorreoElectronico, FechaIngreso) VALUES(@Nombre, @Apellido, @Puesto, @Telefono, @CorreoElectronico, @FechaIngreso)";
                        using (var cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                            cmd.Parameters.AddWithValue("@Puesto", txtPuesto.Text);
                            cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                            cmd.Parameters.AddWithValue("@CorreoElectronico", txtCorreo.Text);
                            cmd.Parameters.AddWithValue("@FechaIngreso", fechaNacimiento);
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
                        string query = "UPDATE Empleados SET CorreoElectronico = @CorreoElectronico, Nombre = @Nombre, Apellido = @Apellido, Puesto = @Puesto, Telefono = @Telefono, FechaIngreso = @FechaIngreso WHERE EmpleadoID = @ID";
                        using (var cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@ID", SiteMaster.IdEmpleado);
                            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                            cmd.Parameters.AddWithValue("@Puesto", txtPuesto.Text);
                            cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                            cmd.Parameters.AddWithValue("@CorreoElectronico", txtCorreo.Text);
                            cmd.Parameters.AddWithValue("@FechaIngreso", fechaNacimiento);
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

            Response.Redirect("BuscarEmpleados.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            SiteMaster.IdEmpleado = -1;
            btnCancelar.Visible = false;
            txtEmpleadoID.Text = "Este campo no se puede modificar";
            btnGuardar.Text = "Guardar";
        }
    }
}