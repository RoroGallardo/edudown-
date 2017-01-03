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
    public partial class adBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
                if (Session["result"] != null)
                {
                    if ((Boolean)Session["result"] == true)
                    {

                    }
                    if ((Boolean)Session["result"] == false)
                    {

                    }
                }
                cargarGrid();
            }
            else
            {
             
            }
        }

        public void cargarGrid()
        {
            List<ENBox> lista = new BLBox().llamarListarBoxs();

            if (lista.LongCount() > 0)
            {
                grvGeneral.DataSource = lista;
                grvGeneral.DataBind();
            }
            else
            {
            }

        }
        protected void grvGeneral_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grvGeneral_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(grvGeneral.Rows[e.RowIndex].Cells[2].Text);
            string locacion = grvGeneral.Rows[e.RowIndex].Cells[4].Text;
            BLBox nc = new BLBox();
            if (nc.llamarEliminarBox(id))
            {
                Console.WriteLine("Box N° " + id + " eliminado con exito ");
              
                new mailService().enviarCorreo("nico.acevedo.nr@gmail.com", "Se eliminó el box n°",
                " " + id + " del centro " + locacion + ".");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Box eliminado'); location.href='adBox.aspx'  ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El box no se pudo eliminar'); location.href='adBox.aspx", true);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adBox.aspx", false);
        }

        protected void grvGeneral_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["modId"] = grvGeneral.Rows[e.RowIndex].Cells[2].Text;

            if (Convert.ToInt16(grvGeneral.Rows[e.RowIndex].Cells[3].Text) == 1)
            {
                Session["modTam"]  = "Pequeño";
            }else if (Convert.ToInt16(grvGeneral.Rows[e.RowIndex].Cells[3].Text) == 2)
            {
                Session["modTam"] = "Mediano";
            }
            else if (Convert.ToInt16(grvGeneral.Rows[e.RowIndex].Cells[3].Text) == 3)
            {
                Session["modTam"] = "Grande";
            }

            Session["modDire"] = grvGeneral.Rows[e.RowIndex].Cells[5].Text;
            String tipo =  grvGeneral.Rows[e.RowIndex].Cells[4].Text;
            Session["modTipo"] = tipo;

            Response.Write("<script>window.open('moBox.aspx','popup','width=565,height=400'); location.href='adBox.aspx'; </script>");
        }

        protected void btnAgregarr_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('aBox.aspx','popup','width=565,height=400'); location.href='adBox.aspx';  </script>");
        }  
    }
}