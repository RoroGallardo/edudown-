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
    public partial class agCentros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack){
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Centro agregado'); opener.location.reload();      this.close(); ", true);
                
            }
        }

        public void limpiarCampos()
        {
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                BLCentros nc = new BLCentros();
                ENCentros cn = new ENCentros();
                cn.id = nc.llamarListarcentros().Count + 1;
                cn.direccion = txtDireccion.Text;
                cn.nombre = txtNombre.Text;
                cn.telefono = txtTelefono.Text;

                if (nc.llamarAgregarCentros(cn))
                {
                    new mailService().enviarCorreo("nico.acevedo.nr@gmail.com", "Se agrego el centro",
                    "Los datos son :\n" + cn.nombre + " \n " + cn.direccion + ".");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Centro agregado'); opener.location.reload();  this.close(); ", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Problemas al registrar el centro')  ", true);
                    limpiarCampos();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
    }
}