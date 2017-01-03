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
    public partial class ModificarFicha : System.Web.UI.Page
    {
        int id;
        String strFechaInicio;
        String rut;
        int patologia;
        int tratamiento;

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Session["id"]);
                strFechaInicio = Convert.ToString(Session["fechaInicio"]);
                rut = Convert.ToString(Session["rut"]);
                tratamiento = Convert.ToInt32(Session["tratamiento"]);
                patologia = Convert.ToInt32(Session["patologia"]);
                cargarCampos();
            }
            else
            { 
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Ficha Modificada'); opener.location.reload();      this.close(); ", true);
            }

        }

        public void limpiarCampos()
        {

          


        }
        public void cargarCampos()
        {
            txtRut.Text = rut;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)//boton para guardar los cambios en una modificacion
        {

            ENFichaPaciente fich = new ENFichaPaciente();
            fich.id = new BLFichaPaciente().llamarListarFichaPaciente().Count + 1;
            fich.fechaInicio = FechaInicio.SelectedDate;
            fich.patologia = new BLPatologia().llamarBuscar(Convert.ToInt32(drdPatologia.SelectedValue));
            fich.tratamiento = new BLTratamiento().llamarBuscarTratamiento(Convert.ToInt32(drdTratamiento.SelectedValue));

            BLFichaPaciente nc= new BLFichaPaciente();
            if (nc.llamarModificarFichaPaciente(fich))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Ficha Modificada'); opener.location.reload();  this.close(); ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Error al modificar la c'); opener.location.reload();  this.close(); ", true);
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "window.close(); ", true);


        }
    }
}