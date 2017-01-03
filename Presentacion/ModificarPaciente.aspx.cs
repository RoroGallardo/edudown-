using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Net.Mail;
using System.Net;

using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class ModificarPaciente : System.Web.UI.Page
    {

        int etapa;
        String rut;
        String nombre;
        String apellido;
        int edad;

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                etapa = Convert.ToInt32(Session["idTrat"]);
                rut = Convert.ToString(Session["rutPac"]);
                nombre = Convert.ToString(Session["nomb"]);
                apellido = Convert.ToString(Session["apellido"]);
                edad = Convert.ToInt32(Session["edad"]);
                cargarCampos();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "  alert('Paciente agregado'); opener.location.reload();      this.close(); ", true);
           }

        }

        public void limpiarCampos()
        {

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtRut.Text = "";
          

        }
        public void cargarCampos()
        {
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = Convert.ToString(edad);
            txtRut.Text = rut;
            
            

        }
        protected void btnAgregar_Click(object sender, EventArgs e)//boton para guardar los cambios en una modificacion
        {
            ENPaciente pac = new ENPaciente();


            pac.nombre = txtNombre.Text;
            pac.rut = txtRut.Text;
            pac.apellido = txtApellido.Text;
            pac.edad = Convert.ToInt32(txtEdad.Text);
            pac.etapa = calcularEtapa(pac.edad);



            BLPaciente nc = new BLPaciente();
            if (nc.llamarModificarPaciente(pac))
            {


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Paciente Modificado'); this.close(); ", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Error al modificar '); this.close(); ", true);
               
               
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", "window.close(); ", true);


        }


        public int calcularEtapa(int _edad)
        {
            int _nroEtapa = 0; ;
            if (_edad > 0 && _edad < 10)
            {
                return _nroEtapa = 1;

            }
            else if (_edad > 10 && _edad < 20)
            {
                _nroEtapa = 2;

            }
            else if (_edad > 20 && _edad < 30)
            {
                _nroEtapa = 3;
            }
            else if (_edad > 30 && _edad < 50)
            {
                _nroEtapa = 4;
            }

            return _nroEtapa;


        }
    }
}