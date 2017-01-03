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
    public partial class AgregarTratamiento : System.Web.UI.Page
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
                //sesionesFinalizadas = Convert.ToString(Session["SesFTrat"]);
                //cargarCampos();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Tratamiento agregado'); opener.location.reload();      this.close(); ", true);
            }
        }

        //public void cargarCampos()
        //{
        //    txtTratamiento.Text = tipoTratamiento;
        //    txtDescripcion.Text = descripcion;
        //    txtCantidadSesiones.Text = cantidadSesiones;
        //    //txtSesionesFinalizadas.Text = sesionesFinalizadas;
        //}

        public void limpiarCampos()
        {
            txtTratamiento.Text = tipoTratamiento;
            txtDescripcion.Text = descripcion;
            txtCantidadSesiones.Text = cantidadSesiones;
            //txtSesionesFinalizadas.Text = sesionesFinalizadas;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)//boton para guardar los cambios en una modificacion
        {
            ENTratamiento trat = new ENTratamiento();


            trat.id = new BLTratamiento().llamarListarTratamiento().Count + 1;
            trat.tipoTratamiento = Convert.ToString(txtTratamiento.Text);
            trat.descripcion = txtDescripcion.Text;
            trat.cantidadSesiones = Convert.ToInt32(txtCantidadSesiones.Text);
            trat.sesionesFinalizadas = 0;


           BLTratamiento nc = new BLTratamiento();
            if (nc.llamarInsertarTratamiento(trat))
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Tratamiento almacenado'); opener.location.reload();  this.close(); ", true);
                

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('No se pudo almacenar el tratamiento'); opener.location.reload();  this.close(); ", true);
            
                
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "window.close(); ", true);


        }


    }

    }
