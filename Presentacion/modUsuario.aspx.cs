using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Net;
using System.Net.Mail;        
namespace Presentacion
{
    public partial class modUsuario : System.Web.UI.Page
    {
        String id;
        String pass;
        String userName;
        String persona;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = Convert.ToString(Session["modId"]);
                pass = Convert.ToString(Session["modPass"]);
                userName = Convert.ToString(Session["modUsername"]);
                persona = Convert.ToString(Session["modPer"]);
                cargarCampos();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Usuario modificado'); opener.location.reload();      this.close(); ", true);
            }
            cargarDDLTipo();
        }

        public void cargarCampos()
        {
            txtId.Text = id;
            txtPass.Text = pass;
            txtUserName.Text = userName;
            txtPersona.Text = persona;
        }

        public void limpiarCampos()
        {
            txtId.Text = "";
            txtPass.Text = "";
            txtUserName.Text = "";
            txtPersona.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            NUsuario nu = new NUsuario();
            EUsuario eu = new EUsuario();

            eu.Id = Convert.ToInt16(txtId.Text);
            eu.username = txtUserName.Text;
            eu.password = txtPass.Text;

            if (ddlTipos.Text == "ADMINISTRADOR INSTITUCION")
            {
                eu.id_tipousuario = 6;
            }
            else if (ddlTipos.Text == "ADMINISTRADOR CENTRO")
            {
                eu.id_tipousuario = 1;
            }
            else if (ddlTipos.Text == "ENFERMERA")
            {
                eu.id_tipousuario = 2;
            }
            else if (ddlTipos.Text == "MEDICO")
            {
                eu.id_tipousuario = 3;
            }
            else if (ddlTipos.Text == "JEFE AUXILIAR")
            {
                eu.id_tipousuario = 4;
            }
            else if (ddlTipos.Text == "admin")
            {
                eu.id_tipousuario = 5;
            }

            eu.id_persona = Convert.ToInt16(txtPersona.Text);

            if (nu.llamarModificarUsuaro(eu))
            {
                Console.WriteLine("Usuario " + eu.username + " eliminado con exito ");

                new mailService().enviarCorreo("nico.acevedo.nr@gmail.com", "Modificación de usuario ",
                "Los nuevos datos son :\n" + eu.username + " \n " + eu.password + ".");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Usuario Modificado'); opener.location.reload();  this.close(); ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El usuario no se pudo modificar')  ", true);
            }
        }

        public void cargarDDLTipo()
        {
            try
            {
                List<String> aux = new List<string>();
                aux.Add("ADMINISTRADOR INSTITUCION");
                aux.Add("ADMINISTRADOR CENTRO");
                aux.Add("ENFERMERA");
                aux.Add("MEDICO");
                aux.Add("JEFE AUXILIAR");

                ddlTipos.DataSource = aux;
                ddlTipos.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " - " + ex.StackTrace);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "window.close(); ", true);
        }

    }
}