using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatAcc;
using Entidades;
namespace Negocio
{
    public class NUsuario
    {

        public Boolean llamarValidarUsuario(String iUser, String iPassword)
        {
            return new DUser().ValidarUsuario(iUser, iPassword);
        }

        public String llamarReturnTipoUsuario(String iUserName)
        {
            return new DUser().returnTipoUsuario(iUserName);
        }

        public String llamarReturnPofesionUsuario(String iUserName)
        {
            return new DUser().returnPofesionUsuario(iUserName);
        }
        public int llamarReturnIDPersona(String iUserName)
        {
            return new DUser().returnIDPersona(iUserName);

        }
        public EUsuario llamarBuscarUsuario(String iUserName)
        {
            return new DUser().buscarUsuario(iUserName);
        }

        public List<EUsuario> listarUsuarios()
        {
            return new DUser().listarUsuarios();
        }

        public bool llamarModificarUsuaro(EUsuario user)
        {
              return   new DUser().modificar(user);
        }

        public bool llamarInsertarIUsuario(EUsuario user)
        {
            return new DUser().insertar(user);
        }

        public bool llamarEliminarUsuario(String username)
        {
            return new DUser().eliminar(username);
        }

    }
}
