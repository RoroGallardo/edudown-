using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace Presentacion
{
    public class mailService
    {

        public mailService()
        {

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