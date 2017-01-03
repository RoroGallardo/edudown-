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
    public partial class moBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Box modificado'); opener.location.reload();      this.close(); ", true);

            }
            cargarDDL();
            cargarCampos();
        }

        private void cargarCampos()
        {
            txtId.Text = Convert.ToString(Session["modId"]);
            txtDescripcion.Text = Convert.ToString(Session["modDescripcion"]);
        }

        private void cargarDDL()
        {
            List<string> aux = new List<string>();
            List<string> daux = new List<string>();

            aux.Add("Kinesiologia");
            aux.Add("Psicologia");
            aux.Add("Fonoaudiologia");

            ddlTipo.DataSource = aux;
            ddlTipo.DataBind();

            daux.Add("Grande");
            daux.Add("Mediano");
            daux.Add("Pequeño");

            ddlTamaño.DataSource = daux;
            ddlTamaño.DataBind();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ENBox bn = new ENBox();
            BLBox bc = new BLBox();

            bn.id = Convert.ToInt16(txtId.Text);
            bn.descripcion = txtDescripcion.Text;
            bn.tipoBox = ddlTipo.Text;
            if (ddlTamaño.Text == "Grande")
            {
                bn.tamaño = 3;
            }
            else if (ddlTamaño.Text == "Mediano")
            {
                bn.tamaño = 2;
            }
            else if (ddlTamaño.Text == "Pequeño")
            {
                bn.tamaño = 1;
            }

            ENEstado es = new ENEstado();
            bn.descripcion = txtDescripcion.Text;
            es.descripcion = ""; es.id = 1; es.nombre = "disponible";
            bn.estado = es;

            bn.centroMedico = new BLCentros().llamarBuscarCentro(Convert.ToInt16(ddlCentro.SelectedValue));//buscar por el id del seleccionado
            ENPaqueteInsumo pq = new ENPaqueteInsumo();
            pq.cantidad = 1; pq.descripcion = ""; pq.id = 1; pq.nombre = "default";
            bn.paqueteInsumo = pq;

            if (bc.llamarModificar(bn))
            {
                Console.WriteLine("BOX " + bn.id + " eliminado con exito ");
                new mailService().enviarCorreo("nico.acevedo.nr@gmail.com", "Modificación de Box ",
                "Los nuevos datos son :\n" + bn.tamaño + " \n " + bn.descripcion + ".");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Box Modificado'); opener.location.reload();  this.close(); ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El box no se pudo modificar')  ", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "window.close(); ", true);
        }
 
    }
}