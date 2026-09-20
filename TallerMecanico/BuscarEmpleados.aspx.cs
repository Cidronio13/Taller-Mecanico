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
    public partial class BuscarEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Empleados";
                cmd.Connection = con;
                con.Open();
                GvClientes.DataSource = cmd.ExecuteReader();
                GvClientes.DataBind();

            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT EmpleadoID FROM Empleados WHERE EmpleadoID = @ID";
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", TxtAceptar.Text);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["EmpleadoID"] != null)
                        {
                            SiteMaster.IdEmpleado = Convert.ToInt32(TxtAceptar.Text);
                            Response.Redirect("AdministrarEmpleados.aspx");
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
        protected void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Empleados WHERE Nombre LIKE @Nombre + '%'";
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@Nombre", TxtFiltro.Text);
                GvClientes.DataSource = cmd.ExecuteReader();
                GvClientes.DataBind();
            }
        }
        protected void GvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GvClientes.SelectedIndex;
            string nombre = GvClientes.Rows[index].Cells[1].Text;

            Response.Write($"Seleccionado: {nombre}");
        }
    }
}