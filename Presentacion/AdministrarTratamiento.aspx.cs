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
    public partial class ModificarTratamiento : System.Web.UI.Page
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
 

        public void enviarCorreo(String strCorreoDestino, String strAsunto, String strCuerpo)
        {
            String correoEduDow = "edudownduoc@gmail.com";
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(correoEduDow, "portafolio123"),
                EnableSsl = true
            };
            client.Send(correoEduDow, strCorreoDestino, strAsunto, strCuerpo);
            Console.WriteLine("Sent");
            Console.ReadLine();
        }


        public void refreshGrid()
        {
            grvGeneral.DataBind();
        }


        public void cargarGrid()
        {
            //List<ENCentros> lista = new BLCentros().llamarListarcentros();
            List<ENTratamiento> lista = new BLTratamiento().llamarListarTratamiento();
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
              int id = Convert.ToInt16(grvGeneral.Rows[e.RowIndex].Cells[2].Text);
              string tipoTrat = grvGeneral.Rows[e.RowIndex].Cells[3].Text;
            //BLCentros nc = new BLCentros();
              ENTratamiento trtoEn = new BLTratamiento().llamarBuscarTratamiento(id);
              BLTratamiento trtoBL = new BLTratamiento();
              if (trtoBL.llamarEliminarTratamiento(trtoEn))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Tratamiento Eliminado'); opener.location.reload();  this.close(); ", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Error al intentar Eliminar'); opener.location.reload();  this.close(); ", true);
              
            }

        }

        

        

        protected void grvGeneral_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Session["idTrat"] = grvGeneral.Rows[e.RowIndex].Cells[2].Text;
            Session["tipTrat"] = grvGeneral.Rows[e.RowIndex].Cells[3].Text;
            Session["descTrat"] = grvGeneral.Rows[e.RowIndex].Cells[4].Text;
            Session["CantSTrat"] = grvGeneral.Rows[e.RowIndex].Cells[5].Text;
            Session["SesFTrat"] = grvGeneral.Rows[e.RowIndex].Cells[6].Text;

            Response.Write("<script>window.open('ModTratamiento.aspx','popup','width=565,height=400'); location.href='AdministrarTratamiento.aspx;  </script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "reloadwindow", " window.opener.location.reload(); ", true);
        }

        protected void btnAgregarr_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('AgregarTratamiento.aspx','popup','width=565,height=400'); location.href='AdministrarTratamiento.aspx; </script>");

        }

        protected void btnbCentro_Click(object sender, EventArgs e)
        {

        }

        protected void grvGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 

        
    }
}