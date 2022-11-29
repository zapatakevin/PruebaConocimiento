using PresentacionWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Pages
{
    public partial class Usuario : System.Web.UI.Page
    {
        Negocio.ServiceUsuario obj = new Negocio.ServiceUsuario();
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el id
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo usuario";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de usuario";
                            tbdate.TextMode = TextBoxMode.DateTime;
                            tbnombre.Enabled = false;
                            tbdate.Enabled = false;
                            DropLisSexo.Enabled = false;
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar usuario";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar usuario";
                            this.BtnDelete.Visible = true;
                            tbdate.TextMode = TextBoxMode.DateTime;
                            tbnombre.Enabled = false;
                            tbdate.Enabled = false;
                            DropLisSexo.Enabled = false;
                            break;
                    }
                }
            }
        }
        void CargarDatos()
        {
            DataSet ds = new DataSet();
             ds = obj.ReadUsuario(Convert.ToInt32(sID));
            if (ds.Tables[0].Rows.Count > 0)
            {
                tbnombre.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                DateTime d = Convert.ToDateTime(ds.Tables[0].Rows[0]["Fecha"].ToString());
                DropLisSexo.SelectedValue = ds.Tables[0].Rows[0]["Sexo"].ToString();
                tbdate.Text = d.ToString("dd/MM/yyyy");
            }

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string Nombre = tbnombre.Text.Trim();
            DateTime Fecha = Convert.ToDateTime(tbdate.Text);
            char Sexo = Convert.ToChar(DropLisSexo.SelectedValue);
            ServiceReference1.Persona people =new ServiceReference1.Persona()
          {
              Nombre = Nombre,
              FechaNacimiento = Fecha,
              Sexo = Sexo
          };
            obj.InsertUsuario(people.Nombre ,people.FechaNacimiento, people.Sexo);
            Response.Redirect("UsuarioConsulta.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioConsulta.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
             int id = (int)Convert.ToInt64(sID);
            string Nombre = tbnombre.Text.Trim();
            DateTime Fecha = Convert.ToDateTime(tbdate.Text);
            char Sexo = Convert.ToChar(DropLisSexo.SelectedValue);
            ServiceReference1.Persona people = new ServiceReference1.Persona()
            {   Id= id,
                Nombre = Nombre,
                FechaNacimiento = Fecha,
                Sexo = Sexo
            };
            obj.UpdateUsuario(people.Id,people.Nombre, people.FechaNacimiento, people.Sexo);
            Response.Redirect("UsuarioConsulta.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = (int)Convert.ToInt64(sID);
            if (obj.DeleteUsuario(id) == true)
            {
                Response.Write("<script language=javascript>alert('Usuario elimando');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Error al eliminar usuario');</script>");
            }
        }
    }
}