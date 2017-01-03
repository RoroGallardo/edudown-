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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        EUsuario usuarioSesion;

        protected void Page_Load(object sender, EventArgs e)
        {
               if(Session["onSesion"] != null){
                    if(Convert.ToBoolean(Session["onSesion"]) == false){
                    Response.Redirect("LogIn.aspx",true);
                }
           }
            try
            {
                NUsuario nu = new NUsuario();

                usuarioSesion = nu.llamarBuscarUsuario(Convert.ToString(Session["Usuario"]));
                cargarBotones();
                lblUser.Text = "Buena Día   " + usuarioSesion.username;
                Session["idSession"] = usuarioSesion.id_tipousuario;

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " PROCESANDO LA LISTA COMPLETA");
            }
        }


        public void cargarBotones()
        {
            int id_tipo = usuarioSesion.id_tipousuario;
            /**
             *TIPOS DE USUARIOS
             * 1 SYSADMIN
             * 2 ADMINISTRADOR INSTITUCION
             * 3 ADMINISTRADOR CENTRO
             * 4 ENFERMERA
             * 5 MEDICO
             * 6 JEFE AUXILIAR
             */

            if (id_tipo == 1)
            {
                btnAgregarHora.Visible = true;
                btnAdminBox.Visible = true;
                btnAdminPac.Visible = true;
                btnAdUsers.Visible = true;
                btnAgregarHora.Visible = true;
                btnadCentros.Visible = true;
                btnAdminTrat.Visible = true;
                btnAdminFichas.Visible = true;
            }
            else if (id_tipo == 2)
            {
                btnAdUsers.Visible = true;
                btnadCentros.Visible = true;
            }
            else if (id_tipo == 3)
            {
                btnAdminBox.Visible = true;
            }   
            else if (id_tipo == 4)
            {
                btnAdminBox.Visible = true;
                btnAdminPac.Visible = true;
                btnAdminFichas.Visible = true;
                btnAgregarHora.Visible = true;
                btnAdminTrat.Visible = true;
            }
            else if (id_tipo == 5)
            {
                btnAdminPac.Visible = true;
                btnAdminFichas.Visible = true;
                btnAdminBox.Visible = true;
                btnAgregarHora.Visible = true;
            }
            else if (id_tipo == 6)
            {
                btnAdminPac.Visible = true;
                btnAdminFichas.Visible = true;
            }

        }

        protected void btnAgregarHora_Click(object sender, EventArgs e)
        {
            Console.WriteLine("REDIRECCION A MOSDISP");
            Response.Redirect("MostrarDisp.aspx", false);

        }

        protected void btnAdUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("adUsuario.aspx");
        }

        protected void btnadCentros_Click(object sender, EventArgs e)
        {
            Response.Redirect("adCentros.aspx");
        }

        protected void btnBuscarCentro_Click(object sender, EventArgs e)
        {
            Response.Redirect("bCentro.aspx", false);
        }

        protected void btnBuscarUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("bUsuario.aspx");
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("aUsuario.aspx", false);
        }

        protected void btnAgregarCentro_Click(object sender, EventArgs e)
        {
            Response.Redirect("aCentros.aspx", false);
        }

        protected void btnAgregarHora_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Disponibilidad.aspx", false);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx", true);
        }

        protected void btnAdminBox_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adBox.aspx", false);
        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void btnAgregarHora_Click2(object sender, EventArgs e)
        {
            Response.Redirect("disponibilidad.aspx", false);
        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Session["onSesion"] = false;
            Response.Redirect("LogIn.aspx", true);  
        }

        protected void btnAdminPac_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministratPaciente.aspx", true);  
        }

        protected void btnAdminFichas_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarFichas.aspx", true);  
        }

        protected void btnAdminTrat_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarTratamiento.aspx", true);
        }

    }
}
