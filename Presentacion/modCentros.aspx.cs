using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Net.Mail;
using System.Net;
namespace Presentacion
{
    public partial class modCentros : System.Web.UI.Page
    {
        String id;
        String tel;
        String nom;
        String dire;

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                id = Convert.ToString(Session["modId"]);
                tel = Convert.ToString(Session["modTel"]);
                nom = Convert.ToString(Session["modNombre"]);
                dire = Convert.ToString(Session["modDire"]);
                cargarCampos();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Centro agregado'); opener.location.reload();      this.close(); ", true);
                              
            }
            
        }

        public void cargarCampos()
        {
            txtId.Text = id;
            txtTelefono.Text = tel;
            txtNombre.Text = nom;
            txtDire.Text = dire;
        }

        public void limpiarCampos()
        {
            txtDire.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)//boton para guardar los cambios en una modificacion
        {
            ENCentros ec = new ENCentros();

            ec.id = Convert.ToInt16(txtId.Text);
            ec.nombre = txtNombre.Text;
            ec.telefono = txtTelefono.Text;
            ec.direccion = txtDire.Text;

            BLCentros nc = new BLCentros();
            if (nc.llamarModificarCentro(ec))
            {
                Console.WriteLine("Usuario " + ec.nombre + " modificado con exito ");
                new mailService().enviarCorreo("nico.acevedo.nr@gmail.com", "Modificación de centro ",
                "Los nuevos datos so :\n" + ec.direccion + " \n " + ec.telefono + "\n"+ ec.nombre + ".");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Centro Modificado'); opener.location.reload();  this.close(); ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El centro no se pudo modificar')  ", true);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "window.close(); ", true);
        }

       
    }
}