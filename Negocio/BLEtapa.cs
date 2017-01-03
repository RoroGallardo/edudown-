using Entidades;
using DatAcc;
using System.Collections.Generic;

namespace Negocio
{
    public class BLEtapa
    {


        public void llamarAgregarEtapa(ENEtapa iEtapa)
        {
            new DEtapa().insertar(iEtapa);
        }

        public void llamarEliminarEtapa(ENEtapa iEtapa)
        {
            new DEtapa().eliminar(iEtapa);
        }

        public void llamarModificarEtapa(ENEtapa iEtapa)
        {
            new DEtapa().modificar(iEtapa);
        }

        public List<ENEtapa> llamarListarEtapa()
        {
            List<ENEtapa> lista = new DEtapa().listarEtapa();
            
            return lista;

        }

    }
}