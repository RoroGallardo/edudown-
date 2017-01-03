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
    public partial class adUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                if (Session["result"] != null)
                {
                    if((Boolean)Session["result"]  == true){
                        lblSuccess.Visible = true;
                        lblSuccess.Text = (String)Session["resultText"];
                    }
                    if ((Boolean)Session["result"] == false)
                    {
                        lblError.Visible = true;
                        lblError.Text = (String)Session["resultText"]; ;
                    }
                }
            }
            cargarGrid();
        }

        public void cargarGrid()
        {
            List<EUsuario> lista = new NUsuario().listarUsuarios();

            if(lista.Count() > 0 ){
                grvGeneral.DataSource = lista;
                grvGeneral.DataBind();
            }else{
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
            NUsuario nu = new NUsuario();
            if (nu.llamarEliminarUsuario(nombre))
            {
                lblSuccess.Visible = true;

                Console.WriteLine("Usuario " + nombre + " eliminado con exito ");
                Session["result"] = true;
                Session["resultText"] = "CAMBIOS en el usuario :" + nombre + " realizados con exito";
                new mailService().enviarCorreo("nico.acevedo.nr@gmail.com", "Se eliminó usuario ",
                " : \n" + nombre +  ".");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario eliminado'); location.href='adUsuario.aspx';  ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario no eliminado'); location.href='adUsuario.aspx'  ", true);
            }

        }

        protected void grvGeneral_RowUpdating(object sender, GridViewUpdateEventArgs e)
        { 
            Session["modId"] =  grvGeneral.Rows[e.RowIndex].Cells[2].Text;
            Session["modPer"] = grvGeneral.Rows[e.RowIndex].Cells[5].Text;
            Session["modUsername"] = grvGeneral.Rows[e.RowIndex].Cells[3].Text;
            Session["modPass"] = grvGeneral.Rows[e.RowIndex].Cells[4].Text;

            Response.Write("<script>window.open('adUsuario.aspx','popup','resizable=false, width=650px,height=400px');  location.href='adUsuario.aspx';  </script>");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adUsuario.aspx",false);
        }

        protected void btnAgregarr_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('agUsuario.aspx','popup','resizable=0, width=650px,height=400px'); location.href='adUsuario.aspx';  </script>");

        }
              
    }
}