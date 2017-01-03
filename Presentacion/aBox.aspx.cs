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
    public partial class aBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Box agregado'); opener.location.reload();      this.close(); ", true);

            }
            cargarDDL();
        }

        private void cargarDDL()
        {
            List<string> aux = new List<string>();
            List<string> daux = new List<string>();

            aux.Add("Kinesiologia");
            aux.Add("Psicologia");
            aux.Add("Fonoaudiologia");

            ddlTipo.DataSource = aux;
            ddlTipo.DataBind();

            daux.Add("Grande");
            daux.Add("Mediano");
            daux.Add("Pequeño");

            ddlTamaño.DataSource = daux;
            ddlTamaño.DataBind();

        }

        public void limpiarCampos()
        {
            txtDescripcion.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                BLBox bc = new BLBox();
                ENBox bn = new ENBox();
                bn.centroMedico = new BLCentros().llamarBuscarCentro(Convert.ToInt16(ddlCentro.SelectedValue));//buscar por el id del seleccionado
                bn.descripcion = txtDescripcion.Text;
                ENPaqueteInsumo pq = new ENPaqueteInsumo();
                pq.cantidad = 1; pq.descripcion = ""; pq.id = 1; pq.nombre = "default";
                bn.paqueteInsumo = pq;
                if(ddlTamaño.Text == "Grande"){
                    bn.tamaño = 1;
                }else if(ddlTamaño.Text == "Mediano"){
                    bn.tamaño = 2;
                }else{
                    bn.tamaño = 3;
                }
                bn.descripcion = txtDescripcion.Text;
                bn.tipoBox = ddlTipo.Text;
                ENEstado es = new ENEstado();
                es.descripcion = txtDescripcion.Text; es.id = 1; es.nombre = "disponible";
                bn.estado = es;

                if (bc.llamarAgregarBox(bn))
                {
                    limpiarCampos();
                    Console.WriteLine("REDIRECCION A listado cemtros");
                    Response.Redirect("adCentros.aspx", false);
                    enviarCorreo("nico.acevedo.nr@gmail.com", "Añade Box",
                     "Se añadio box en el centro :" + bn.centroMedico.nombre + ".");
                     ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Box Agregado'); opener.location.reload();  this.close(); ", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Usuario no Modificado');  ", true);
                    limpiarCampos();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "window.close(); ", true);
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
    }
}