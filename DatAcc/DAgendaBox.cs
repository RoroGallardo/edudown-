using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades;

namespace DatAcc
{



    public class DAgendaBox
    {
        public bool agregarAgenda(ENAgendaBox eAgenda)
        
        {
            try
            {
                using (EntitiesDaBa ctx = new EntitiesDaBa())
                {

                    AGENDABOX objAgenda = new AGENDABOX();
                    objAgenda.BOX_IDBOX = eAgenda.box.id;
                    objAgenda.EQUIPOMEDICO_IDEQUIPOMEDICO = eAgenda.equipomedico.id;
                    objAgenda.FECHATRATAMIENTO = Convert.ToString(eAgenda.fechaTratamiento);
                    objAgenda.FICHAPACIENTE_IDFICHAPACIENTE = eAgenda.fichapaciente.id;
                    objAgenda.ID = eAgenda.id;
                    objAgenda.ID_PROFESIONAL = eAgenda.doctor.Id;
                    objAgenda.PERIODO_IDPERIODO = eAgenda.periodo.id;
                    objAgenda.TIEMPOTRATAMIENTO = eAgenda.tiempoTratamiento;
                    objAgenda.TIPOTRATAMIENTO = eAgenda.tipo;

                    ctx.AddToAGENDABOX(objAgenda);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            
        }

        public ENAgendaBox buscarAgendaFecha(String fechaTratamiento)
        {
            ENAgendaBox agenda = new ENAgendaBox();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    AGENDABOX ab = (from a in bd.AGENDABOX
                              where a.FECHATRATAMIENTO == fechaTratamiento
                              select a).FirstOrDefault();

                    agenda.box = new DBox().buscarBox( Convert.ToInt32(ab.BOX_IDBOX) );
                    agenda.equipomedico = new DEquipoMedico().buscar(Convert.ToInt32(ab.EQUIPOMEDICO_IDEQUIPOMEDICO));
                    agenda.fechaTratamiento =  ab.FECHATRATAMIENTO;
                    agenda.fichapaciente = new DFichaPaciente().buscarFichaID(Convert.ToInt32(ab.FICHAPACIENTE_IDFICHAPACIENTE));
                    agenda.id = Convert.ToInt32(ab.ID);
                    agenda.tiempoTratamiento = Convert.ToDateTime(ab.TIEMPOTRATAMIENTO);
                    agenda.doctor = new DDoctor().buscarDoctor(Convert.ToInt32(ab.ID_PROFESIONAL));
                    agenda.periodo = new DPeriodo().buscar(Convert.ToInt32(ab.PERIODO_IDPERIODO));
                    agenda.tratamiento = ab.TIPOTRATAMIENTO;
                    agenda.tipo = ab.TIPOTRATAMIENTO;

                    return agenda;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<ENAgendaBox> listar()
        {

            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    List<ENAgendaBox> lista = new List<ENAgendaBox>();
                    foreach (AGENDABOX ag in ctx.AGENDABOX.ToList<AGENDABOX>())
                    {
                        ENAgendaBox ea/*ea !ea !*/  = new ENAgendaBox();

                        ea.id = Convert.ToInt16(ag.ID);
                        //AAGREGAR EL RESTO DE LAS CONVERSIONES O AGREGAR EL METODO BUSCARAGENDA () ! BUSCAR AGRENDA ENTRE ()! BUSCAR AGENDA POR ID()! 

                        lista.Add(ea);
                    }

                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int count()
        {
            try
            {
                return listar().Count + 1;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ENAgendaBox buscarAgendaId(int id)
        {
            ENAgendaBox agenda = new ENAgendaBox();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    AGENDABOX ab = (from a in bd.AGENDABOX
                                    where a.ID == id
                                    select a).FirstOrDefault();

                    agenda.box = new DBox().buscarBox(Convert.ToInt32(ab.BOX_IDBOX));
                    agenda.equipomedico = new DEquipoMedico().buscar(Convert.ToInt32(ab.EQUIPOMEDICO_IDEQUIPOMEDICO));
                    agenda.fechaTratamiento = ab.FECHATRATAMIENTO;
                    agenda.fichapaciente = new DFichaPaciente().buscarFichaID(Convert.ToInt32(ab.FICHAPACIENTE_IDFICHAPACIENTE));
                    agenda.id = Convert.ToInt32(ab.ID);
                    agenda.tiempoTratamiento = Convert.ToDateTime(ab.TIEMPOTRATAMIENTO);
                    agenda.doctor = new DDoctor().buscarDoctor(Convert.ToInt32(ab.ID_PROFESIONAL));
                    agenda.periodo = new DPeriodo().buscar(Convert.ToInt32(ab.PERIODO_IDPERIODO));
                    agenda.tratamiento = ab.TIPOTRATAMIENTO;
                    agenda.tipo = ab.TIPOTRATAMIENTO;

                    return agenda;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
