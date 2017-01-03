using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Negocio;
using Entidades;
namespace Presentacion
{
    public partial class ModTratamiento : System.Web.UI.Page
    {
        String id;
        String tipoTratamiento;
        String descripcion;
        String cantidadSesiones;
        String sesionesFinalizadas;

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                id = Convert.ToString(Session["idTrat"]);
                tipoTratamiento = Convert.ToString(Session["tipTrat"]);
                descripcion = Convert.ToString(Session["descTrat"]);
                cantidadSesiones = Convert.ToString(Session["CantSTrat"]);
                sesionesFinalizadas = Convert.ToString(Session["SesFTrat"]);
                cargarCampos();
            }
            else
            {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Tratamiento agregado'); opener.location.reload();      this.close(); ", true);
            }

        }

        public void cargarCampos()
        {  
            txtTipoTrat.Text = tipoTratamiento;
            txtDescripcion.Text = descripcion;
            txtCantidadSesiones.Text = cantidadSesiones;
            txtSesionesFinalizadas.Text = sesionesFinalizadas;
        }

        public void limpiarCampos()
        {

            txtTipoTrat.Text = tipoTratamiento;
            txtDescripcion.Text = descripcion;
            txtCantidadSesiones.Text = cantidadSesiones;
            txtSesionesFinalizadas.Text = sesionesFinalizadas;
        }

        protected void btnGuardarr_Click(object sender, EventArgs e)//boton para guardar los cambios en una modificacion
        {
            ENTratamiento trat = new ENTratamiento();


            trat.id = Convert.ToInt32(Session["idTrat"]);
            trat.tipoTratamiento = Convert.ToString(txtTipoTrat.Text);
            trat.descripcion = Convert.ToString(txtDescripcion.Text);
            trat.cantidadSesiones = Convert.ToInt32(txtCantidadSesiones.Text);
            trat.sesionesFinalizadas = Convert.ToInt32(txtSesionesFinalizadas.Text);


            BLTratamiento nc = new BLTratamiento();
            if (nc.llamarModifcarTraramiento(trat))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Tratamiento Modificado'); opener.location.reload();  this.close(); ", true);
               

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Error al modificar'); opener.location.reload();  this.close(); ", true);


            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "window.close(); ", true);


        }

 

    }

    }
