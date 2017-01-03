using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
namespace Presentacion
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                NUsuario uc = new NUsuario();
                
                if (uc.llamarValidarUsuario(txtUsername.Text, txtPassword.Text))
                {
                    Session["Usuario"] = txtUsername.Text;
                    Session["onSesion"] = true;

                    //  Server.Transfer("Menu.aspx");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Buen día "+txtUsername+"')  ", true);

                    Response.Redirect("index.aspx", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos no valido, porfavor reintente.')  ", true);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

        }
    }
}