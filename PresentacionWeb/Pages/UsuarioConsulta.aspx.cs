using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Pages
{
    public partial class UsuarioConsulta : System.Web.UI.Page
    {
        Negocio.ServiceUsuario obj = new Negocio.ServiceUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarTabla();
            }

        }

        void CargarTabla()
        {
            gvusuarios.DataSource = obj.GetUsuarios();
            gvusuarios.DataBind();
        }
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Usuario.aspx?op=C");

        }
        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/Usuario.aspx?id=" + id + "&op=R");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/Usuario.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/Usuario.aspx?id=" + id + "&op=D");
        }    

    }
}