using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;
using Negocio;
using Entidades;

namespace Presentacion
{
    public partial class AdministratPaciente : System.Web.UI.Page
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
            //List<ENTratamiento> lista = new BLTratamiento().llamarListarTratamiento();
            List<ENPaciente> lista = new BLPaciente().llamarListarPaciente();
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
            String rut = grvGeneral.Rows[e.RowIndex].Cells[5].Text;
            string Nombre = grvGeneral.Rows[e.RowIndex].Cells[6].Text;
            //BLCentros nc = new BLCentros();
            ENPaciente pac = new BLPaciente().llamarbuscarPacienteRut(rut);
            BLPaciente p = new BLPaciente();
            if (p.llamarEliminarPaciente(pac))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Paciente Eliminado'); opener.location.reload();  this.close(); ", true);


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Error al eliminar paciente'); opener.location.reload();  this.close(); ", true);

            }

        }

        protected void grvGeneral_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            Session["rutPac"] = grvGeneral.Rows[e.RowIndex].Cells[5].Text;
            Session["nomb"] = grvGeneral.Rows[e.RowIndex].Cells[6].Text;
            Session["apellido"] = grvGeneral.Rows[e.RowIndex].Cells[7].Text;
            Session["edad"] = grvGeneral.Rows[e.RowIndex].Cells[8].Text;
            //Session["etapa"] = grvGeneral.Rows[e.RowIndex].Cells[2].Text;

            Response.Write("<script>window.open('ModificarPaciente.aspx','popup','width=565,height=400'); location.href='AdministratPaciente.aspx; </script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "reloadwindow", " window.opener.location.reload(); ", true);
        }

        protected void btnAgregarr_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('AgregarPaciente.aspx','popup','width=565,height=400'); location.href='AdministratPaciente.aspx;' </script>");

        }

        protected void btnbCentro_Click(object sender, EventArgs e)
        {

        }

        protected void grvGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
