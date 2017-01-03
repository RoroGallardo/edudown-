using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Net;
using System.Net.Mail;
namespace Presentacion
{
    public partial class aHora : System.Web.UI.Page
    {
        String dts;
        String tipotratamiento;
        List<ENProfesional> dcs;
        int idbox;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            BLDoctor dd = new BLDoctor();

            txtInicio.Text = Convert.ToString(Session["horaInicio"]);
            dts = Convert.ToString(Session["dts"]);
            tipotratamiento = Convert.ToString(Session["tipotratamiento"]);
            idbox = Convert.ToInt16(Session["idbox"]);
            dcs = dd.llamarRDoctorCo(dts, tipotratamiento);

            cargarComboDoctores();
        }

        private void cargarComboDoctores()
        {
            try
            {
                List<ENProfesional> idDocs = new BLDoctor().llamarRDoctorDispFecha(dts,tipotratamiento) ;

                List<string> st = new List<string>();

                foreach (ENProfesional item in idDocs)
                {
                    st.Add(item.persona.apellido + " " + item.persona.nombre);
                }

                ddpDoctores.DataSource =st;
                ddpDoctores.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                throw;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BLPaciente dp = new BLPaciente();
                ENFichaPaciente fi = new BLFichaPaciente().llamarBuscarPorRut(txtRut.Text);
                if (fi == null)
                {
                    //ALERTA Y REFRESCAR

                }
                else
                {
                    txtNombre.Text = dp.llamarReturnApellido(txtRut.Text) + " " + dp.llamarReturnNombre(txtRut.Text);
                    txtEdad.Text = Convert.ToString(dp.llamarReturnEdad(txtRut.Text));
                    txtFicha.Text = Convert.ToString(fi.id);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENAgendaBox ag = new ENAgendaBox();

                ag.fechaTratamiento = dts;
                ag.tipo = tipotratamiento;
                ag.tratamiento = tipotratamiento;

                ag.box = new BLBox().llamarBuscarBox(idbox);
                ag.fichapaciente = new BLFichaPaciente().llamarBuscarPorRut(txtRut.Text);
                ag.equipomedico = new BLEquipoMedico().llamarBuscarEquipoMed(1);
                ag.doctor = new BLDoctor().returnDocPorNombre(ddpDoctores.Text);

                BLPeriodo per = new BLPeriodo();
                ENPeriodo peri = new ENPeriodo(per.llamarCount(), Convert.ToString(Session["horaInicio"]), basicExample.Text);
                per.llamarInsertarPeriodo(peri);
                ag.periodo = peri;

                BLAgendaBox da = new BLAgendaBox();
                ag.id = da.llamarCount();

                if (da.llamarAgregarAgendaBox(ag))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", " alert('Hora agenda con exito'); opener.location.reload();  this.close(); ", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se pudo registrar reserva de hora')  ", true);
                    limpiarCampos();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                limpiarCampos();
            }
        }

        public void limpiarCampos()
        {
            txtFicha.Text = "";
            txtEdad.Text = "";
            txtNombre.Text = "";
            txtRut.Text = "";
        }

    }
}