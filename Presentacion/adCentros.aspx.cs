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
    public partial class adCentros1 : System.Web.UI.Page
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

        public void cargarGrid()
        {
            List<ENCentros> lista = new BLCentros().llamarListarcentros();

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

        protected void grvGeneral_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(grvGeneral.Rows[e.RowIndex].Cells[2].Text);
            string nombre = grvGeneral.Rows[e.RowIndex].Cells[3].Text;
            BLCentros nc = new BLCentros();

            if(nc.llamarEliminarCentro(id)){                        
                Console.WriteLine("Usuario "+nombre+ " eliminado con exito ");               
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Centro eliminado'); location.href='adCentros.aspx'  ", true);
            }else{              
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Centro no eliminado'); location.href='adCentros.aspx'  ", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)//boton para guardar los cambios en una modificacion
        {
            ENCentros ec = new ENCentros();
            BLCentros nc = new BLCentros();

            if (nc.llamarModificarCentro(ec))
            {
                lblSuccess.Visible = true;

                Console.WriteLine("Usuario " + ec.nombre + " eliminado con exito ");
                Session["result"] = true;
                Session["resultText"] = "CAMBIOS en el centro :" + ec.nombre + " realizados con exito";
                new mailService().enviarCorreo("nico.acevedo.nr@gmail.com", "Se eliminó el centro ",
                " : \n" + ec.nombre + ".");
                Response.Redirect("adCentros.aspx", false);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Centro eliminado'); location.href='adCentros.aspx'  ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Centro no eliminado'); location.href='adCentros.aspx'  ", true);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adCentros.aspx",false);
        }

        protected void grvGeneral_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["modId"] = grvGeneral.Rows[e.RowIndex].Cells[2].Text;
            Session["modTel"] = grvGeneral.Rows[e.RowIndex].Cells[5].Text;
            Session["modNombre"] = grvGeneral.Rows[e.RowIndex].Cells[3].Text;
            Session["modDire"] = grvGeneral.Rows[e.RowIndex].Cells[4].Text;

            Response.Write("<script>window.open('modCentros.aspx','popup','width=565,height=400'); location.href='adCentros.aspx'; </script>");
        }

        protected void btbAgregarr_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('agCentros.aspx','popup','width=565,height=400'); location.href='adCentros.aspx'; </script>");
        }

        protected void btnbCentro_Click(object sender, EventArgs e)
        {
           
        }  
    }
}
