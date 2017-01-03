using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Net;
using System.Net.Mail;

namespace Presentacion
{
    public partial class agUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Usuario agregado'); opener.location.reload();      this.close(); ", true);

            }
            cargarDDLRut();
            cargarDDLTipo();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            NUsuario nu = new NUsuario();
            EUsuario eu = new EUsuario();

            eu.Id = nu.listarUsuarios().Count() + 1;
            eu.username = txtUsername.Text;
            eu.password = txtPass.Text;

            if (ddlTipo.Text == "ADMINISTRADOR INSTITUCION")
            {
                eu.id_tipousuario = 2;
            }
            else if (ddlTipo.Text == "ADMINISTRADOR CENTRO")
            {
                eu.id_tipousuario = 3;
            }
            else if (ddlTipo.Text == "ENFERMERA")
            {
                eu.id_tipousuario = 4;
            }
            else if (ddlTipo.Text == "MEDICO")
            {
                eu.id_tipousuario = 5;
            }
            else if (ddlTipo.Text == "JEFE AUXILIAR")
            {
                eu.id_tipousuario = 6;
            }
            else if (ddlTipo.Text == "SYSADMIN")
            {
                eu.id_tipousuario = 1;
            }

            eu.id_persona = new BLPersonas().llamarRetornarId(ddlRut.Text);  //  CAMBIAR POR -> ddlRut.Text;

            if (nu.llamarInsertarIUsuario(eu))
            {
                limpiarCampos();
                new mailService().enviarCorreo("nico.acevedo.nr@gmail.com", "Se agrego al usuario ",
                ":\n" + eu.username +  ".");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Usuario agregado'); opener.location.reload();  this.close(); ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se pudo registrar usuario')  ", true);
                limpiarCampos();
            }

        }

        public void limpiarCampos()
        {
            txtPass.Text = "";
            txtUsername.Text = "";
        }

        public void cargarDDLRut()
        {
            try
            {
                ddlRut.DataSource = new BLDoctor().doctoresRuts();
                ddlRut.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " - " + ex.StackTrace);
            }
        }

        public void cargarDDLTipo()
        {
            try
            {
                List<String> aux = new List<string>();

                EUsuario userSesion = new NUsuario().llamarBuscarUsuario(Convert.ToString(Session["Usuario"]));

                if (userSesion.id_tipousuario == 1)
                {
                    aux.Add("SYSADMIN");
                }
                aux.Add("ADMINISTRADOR INSTITUCION");
                aux.Add("ADMINISTRADOR CENTRO");
                aux.Add("ENFERMERA");
                aux.Add("MEDICO");
                aux.Add("JEFE AUXILIAR");

                ddlTipo.DataSource = aux;
                ddlTipo.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " - " + ex.StackTrace);
            }
        }
 
    }
}