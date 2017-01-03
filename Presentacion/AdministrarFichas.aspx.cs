using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Net;
using System.Net.Mail;

using Entidades;
using Negocio;


namespace Presentacion
{
    public partial class AdministrarFichas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["result"] != null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", Convert.ToString(Session["resultText"]), true);
                Session["result"] = null;
            }
            cargarGrid();

        }

        public void refreshGrid()
        {
            grvGeneral.DataBind();
        }


        public void cargarGrid()
        {
            //List<ENTratamiento> lista = new BLTratamiento().llamarListarTratamiento();
            List<ENFichaPaciente> lista = new BLFichaPaciente().llamarListarFichaPaciente();
            if (lista.Count() > 0)
            {
                grvGeneral.DataSource = lista;
                grvGeneral.DataBind();
            }
            else
            {
                lblError.Text = "No existen registros en la base de datos";
            }

        }

        protected void grvGeneral_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        //listo
        protected void grvGeneral_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvGeneral.Rows[e.RowIndex].Cells[2].Text);
          
            //BLCentros nc = new BLCentros();
            ENFichaPaciente pac = new BLFichaPaciente().llamarBuscarFichaID(id);
            BLFichaPaciente p = new BLFichaPaciente();
            if (p.llamarEliminarFichaPaciente(pac))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Ficha eliminada'); opener.location.reload();  this.close(); ", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Error al eliminar Ficha'); opener.location.reload();  this.close(); ", true);
                

            }

        }

        protected void grvGeneral_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Session["id"] = grvGeneral.Rows[e.RowIndex].Cells[2].Text;
            Session["fechaInicio"] = grvGeneral.Rows[e.RowIndex].Cells[3].Text;
            Session["rut"] = grvGeneral.Rows[e.RowIndex].Cells[4].Text;
            //Session["tratamiento"] = grvGeneral.Rows[e.RowIndex].Cells[5].Text;
            //Session["patologia"] = grvGeneral.Rows[e.RowIndex].Cells[6].Text;


            Response.Write("<script>window.open('ModificarFicha.aspx','popup','width=565,height=400'); location.href='AdministrarFichas.aspx.cs'  </script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "reloadwindow", " window.opener.location.reload(); ", true);
        }

        protected void btnAgregarr_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('AgregarFicha.aspx','popup','width=auto,height=auto , resizable=false'); location.href='AdministrarFichas.aspx.cs' </script>");

        }

        protected void btnbCentro_Click(object sender, EventArgs e)
        {

        }

        protected void grvGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}