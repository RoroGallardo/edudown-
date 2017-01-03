using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Collections;
using Entidades;
namespace Presentacion
{
    public partial class disponibilidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                lblTitleGral.Visible = false;
                grvGral.Enabled = false;
                grvGral.Visible = false;
            }
            else
            {
                cargarComboTipo();
                BLBox db = new BLBox();

                lblTitleLibres.Visible = false;
                lblTitleOcupados.Visible = false;

                grvGral.DataSource = db.llamarListarBoxs();
                grvGral.DataBind();
            }
            //grvlibres.visible = false;
            //grvocupados.visible = false;
        }
        
        public void cargarComboTipo()
        {
            ArrayList aux = new ArrayList();

            aux.Add("Kinesiologia");
            aux.Add("Fonoaudiologia");
            cmbTrataminetos.DataSource = aux;
            cmbTrataminetos.DataBind();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                BLBox db = new BLBox();
                var ats = cldFecha.SelectedDate + " " +basicExample.Text;

                List<ENBox> boxOcupados = db.llamarListarOcupados(ats, cmbTrataminetos.Text);

                grvOcupados.DataSource = boxOcupados;

                if (boxOcupados.Count == 0)
                {
                    grvLibres.DataSource = db.llamarListarBoxs();
                }
                else
                {
                    grvLibres.DataSource = db.ListarRestoLibres(ats, cmbTrataminetos.Text);
                }

                grvLibres.DataBind();
                grvOcupados.DataBind();
                lblTitleLibres.Visible = true;
                lblTitleOcupados.Visible = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " PROCESANDO LA LISTA COMPLETA");
            }
        }

        protected void grvLibres_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx", false);
        }

        protected void grvLibres_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("agendarHora"))
            {
                Session["idbox"] = 1;// grvLibres.SelectedRow.Cells[].Text;
                Session["horaInicio"] = basicExample.Text;
                Session["tipoTratamiento"] = cmbTrataminetos.Text;
                Session["dts"] = cldFecha.SelectedDate + " " + basicExample.Text;

                Response.Write("<script>window.open('aHora.aspx','popup','width=565,height=400') </script>");

           //     Response.Redirect("agHora.aspx", false);
            }
        }
    }
}