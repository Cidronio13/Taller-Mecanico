using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TallerMecanico
{
    public partial class SiteMaster : MasterPage
    {
        public static int NivelUsu = -1;
        public static int IdUsuario = -1, IdVehiculo = -1, IdEmpleado = -1, IdServicio = -1;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SiteMaster.NivelUsu == 0)
            {
                liProveedores.Visible = false;
                li1AdminUsuarios.Visible = true;
                li1AdminVehiculo.Visible = true;
                li1AdministrarEmpleados.Visible = true;
                li1AdministrarServicio.Visible = true;
                BtnIniciar.Text = Login.Nombre;
            }
            else if(SiteMaster.NivelUsu == 1)
            {
                li1AdministrarEmpleados.Visible = false;
                li1AdminVehiculo.Visible = false;
                liProveedores.Visible = false;
                li1AdminUsuarios.Visible = false;
                li1AdministrarServicio.Visible = false;
                BtnIniciar.Text = Login.Nombre;
            }
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            if (SiteMaster.NivelUsu == -1)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                liProveedores.Visible = false;
                li1AdminUsuarios.Visible = false;
                li1AdminVehiculo.Visible = false;
                li1AdministrarEmpleados.Visible = false;
                li1AdministrarServicio.Visible = false;
                BtnIniciar.Text = "Iniciar Sesión";
                NivelUsu = -1;
                Response.Redirect("Catalogo.aspx");
            }
            
        }
    }
}