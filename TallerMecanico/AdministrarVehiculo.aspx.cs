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
    public partial class AdministrarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteMaster.IdVehiculo == -1)
            {
                btnGuardar.Text = "Guardar";
                btnCancelar.Visible = false;
                txtVehiculoID.Text = "Este campo no se puede modificar";
            }
            else
            {
                btnGuardar.Text = "Actualizar";
                btnCancelar.Visible = true;
                txtVehiculoID.Text = SiteMaster.IdVehiculo.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (SiteMaster.IdVehiculo == -1)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO Vehiculos(ClienteID, Marca, Modelo, Año, Placa) VALUES(@CLIENTEID, @MARCA, @MODELO, @AÑO, @PLACA)";
                        using (var cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@CLIENTEID", txtUsuarioID.Text);
                            cmd.Parameters.AddWithValue("@MARCA", txtMarca.Text);
                            cmd.Parameters.AddWithValue("@MODELO", txtModelo.Text);
                            cmd.Parameters.AddWithValue("@AÑO", Convert.ToInt32(txtAño.Text));
                            cmd.Parameters.AddWithValue("@PLACA", txtPlaca.Text);
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
                        string query = "UPDATE Vehiculos SET ClienteID = @CLIENTEID, Marca = @MARCA, Modelo = @MODELO, Año = @AÑO, Placa = @PLACA WHERE VehiculoID = @ID";
                        using (var cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@CLIENTEID", txtUsuarioID.Text);
                            cmd.Parameters.AddWithValue("@ID", SiteMaster.IdVehiculo);
                            cmd.Parameters.AddWithValue("@MARCA", txtMarca.Text);
                            cmd.Parameters.AddWithValue("@MODELO", txtModelo.Text);
                            cmd.Parameters.AddWithValue("@AÑO", txtAño.Text);
                            cmd.Parameters.AddWithValue("@PLACA", txtPlaca.Text);
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

            Response.Redirect("BuscarVehiculo.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            SiteMaster.IdVehiculo = -1;
            btnCancelar.Visible = false;
            txtVehiculoID.Text = "Este campo no se puede modificar";
            btnGuardar.Text = "Guardar";
        }
    }
}