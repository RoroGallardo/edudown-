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
    public partial class AgregarFicha : System.Web.UI.Page
    {

        protected void Page_Load()
        {
            if (IsPostBack)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Ficha agregado'); opener.location.reload();      this.close(); ", true);

            }

        }

        public void limpiarCampos()
        { 
            txtRut.Text ="";
                
        }

        protected void btnAgregar_Click(object sender, EventArgs e)//boton para guardar los cambios en una modificacion
        {
            ENFichaPaciente fich = new ENFichaPaciente();

            fich.fechaInicio = FechaInicio.SelectedDate;
            fich.id = new BLFichaPaciente().llamarListarFichaPaciente().Count +1;
            fich.rut = txtRut.Text;
            fich.patologia = new BLPatologia().llamarBuscar(Convert.ToInt32(drdPatologia.SelectedValue));
            fich.tratamiento = new BLTratamiento().llamarBuscarTratamiento(Convert.ToInt32(drdTratamiento.SelectedValue));


            BLFichaPaciente nc = new BLFichaPaciente();
            
            if (nc.llamarAgregarFichaPaciente(fich))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Ficha Agregada'); this.close(); ", true);
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Error al almacenar ficha'); opener.location.reload();  this.close(); ", true);

            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "window.close(); ", true);
        }
    }
}