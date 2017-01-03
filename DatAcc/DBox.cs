using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Entidades;
namespace DatAcc
{
   public class DBox
    {
       
       public Boolean returnEstaAgendado(String tiempo, string tipotratamiento, int box_id)
        {
            bool aux = false;

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
             try
                {
                    BOX bb = (from b in bd.BOX
                                  join ag in bd.AGENDABOX on b.IDBOX equals ag.BOX_IDBOX
                                  where ag.FECHATRATAMIENTO == tiempo 
                                        && ag.TIPOTRATAMIENTO == tipotratamiento 
                                        && b.IDBOX == box_id
                                  select b).FirstOrDefault();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return aux;
        }

       public List<ENBox> listarBoxs()
       {
           List<BOX> bdlist = new List<BOX>();
           List<ENBox> auxlist = new List<ENBox>();

           using (EntitiesDaBa bd = new EntitiesDaBa())
           {
               try
               {
                   bdlist = (from b in bd.BOX 
                             select b).ToList<BOX>();
                   foreach (BOX item in bdlist)
                   {
                       ENBox nb = this.buscarBox(Convert.ToInt16(item.IDBOX));
                       auxlist.Add(nb);
                   }
                   return auxlist;
               }
               catch (Exception ex)
               {
                   Console.WriteLine("\n ERROR : "+ex.Message+" - "+ex.StackTrace);
                   return null;
               }
           }
       }


       public List<ENBox> listarOcupados(String tiempo, string tipotratamiento)
       {
           List<BOX> bdlist = new List<BOX>();
           List<ENBox> auxlist = new List<ENBox>();

           using (EntitiesDaBa bd = new EntitiesDaBa())
           {
               try
               {
                   bdlist = (from b in bd.BOX
                             join
                                 a in bd.AGENDABOX on b.IDBOX
                                 equals a.BOX_IDBOX
                             where a.FECHATRATAMIENTO == tiempo &&
                             a.TIPOTRATAMIENTO == tipotratamiento
                             select b).ToList<BOX>();

                   foreach (BOX item in bdlist)
                   {
                       ENBox nb = this.buscarBox(Convert.ToInt16(item.IDBOX));
                       auxlist.Add(nb);
                   }
                   return auxlist;
               }
               catch (Exception)
               {
                   throw;
               }
           }
           
       }

       public List<ENBox> listarLibres(String tiempo, string tipotratamiento)
       {
           List<BOX> bdlist = new List<BOX>();
           List<ENBox> auxlist = new List<ENBox>();

           using (EntitiesDaBa bd = new EntitiesDaBa())
           {
               try
               {
                   bdlist = (from b in bd.BOX
                             join a in bd.AGENDABOX on b.IDBOX
                             equals a.BOX_IDBOX
                             where a.FECHATRATAMIENTO != tiempo &&
                             a.TIPOTRATAMIENTO == tipotratamiento
                             select b).ToList<BOX>();

                   if (bdlist.Count == 0)
                   {
                       return listarBoxs();
                   }
                   else
                   {

                       foreach (BOX item in bdlist)
                       {
                           ENBox nb = this.buscarBox(Convert.ToInt16(item.IDBOX));
                           auxlist.Add(nb);
                       }

                   }

                   return auxlist;
               }
               catch (Exception)
               {
                   throw;
               }
           }
       }

       public List<ENBox> listarRestoLibres(String tiempo, string tipotratamiento)
       {
           List<BOX> bdlist = new List<BOX>();
           List<ENBox> auxlist = new List<ENBox>();
           List<ENBox> boxs = listarBoxs();
           using (EntitiesDaBa bd = new EntitiesDaBa())
           {
               try
               {
                   bdlist = (from b in bd.BOX
                             join
                                 a in bd.AGENDABOX on b.IDBOX
                                 equals a.BOX_IDBOX
                             where a.FECHATRATAMIENTO == tiempo &&
                             a.TIPOTRATAMIENTO == tipotratamiento
                             select b).ToList<BOX>();
                   foreach (BOX item in bdlist)
                   {
                       foreach (ENBox em in boxs)
                       {
                           if (item.IDBOX != em.id)
                           {
                               ENBox nb = this.buscarBox(Convert.ToInt16(em.id));
                               auxlist.Add(nb);
                           }
                       }
                   }
                   return auxlist;
               }
               catch (Exception)
               {
                   throw;
               }
           }
       }

       public bool eliminar(int idBox)
       {
           try
           {
               using (var ctx = new EntitiesDaBa())
               {
                   BOX obj = (from b in ctx.BOX
                                        where b.IDBOX == idBox
                                        select b).FirstOrDefault();
                   ctx.BOX.DeleteObject(obj);
                   ctx.SaveChanges();
               }
               return true;
           }
           catch (Exception ex)
           {
               Console.WriteLine("\n ERROR : " + ex.Message + " - " + ex.StackTrace);
               return false;
           }
       }

       public bool modificar(ENBox eBox)
       {
           try
           {
               using (var ctx = new EntitiesDaBa())
               {
                   BOX obj = (from b in ctx.BOX
                                        where b.IDBOX == eBox.id
                                        select b).FirstOrDefault();

                   obj.TIPO= eBox.tipoBox;
                   obj.TAMA_= eBox.tamaño;
                   obj.IDBOX = eBox.id;
                   obj.PAQUETEINSUMO_IDPAQUETEINSUMO = Convert.ToDecimal(eBox.paqueteInsumo.id);
                   obj.CENTROS_IDCENTRO = Convert.ToDecimal(eBox.centroMedico.id);
                   obj.ESTADO_IDESTADO = Convert.ToDecimal(eBox.estado.id);
                   obj.DESCRIPCION = eBox.descripcion;
                   ctx.SaveChanges();
               }
               return true;
           }
           catch (Exception ex)
           {
               Console.WriteLine("\n ERROR : " + ex.Message + " - " + ex.StackTrace);
               return false;
           }

       }

       public bool agregarBox(ENBox eBox)
       {
           try
           {
               using (var ctx = new EntitiesDaBa())
               {
                   BOX obj = new BOX();

                   obj.TIPO = eBox.tipoBox;
                   obj.TAMA_ = eBox.tamaño;
                   obj.IDBOX = eBox.id;
                   obj.DESCRIPCION = eBox.descripcion;

                   obj.PAQUETEINSUMO_IDPAQUETEINSUMO = Convert.ToDecimal(eBox.paqueteInsumo.id);
                   obj.CENTROS_IDCENTRO = Convert.ToDecimal(eBox.centroMedico.id);
                   obj.ESTADO_IDESTADO = Convert.ToDecimal(eBox.estado.id);


                   ctx.AddToBOX(obj);
                   ctx.SaveChanges();
               }
               return true;
           }
           catch (Exception ex)
           {
               Console.WriteLine("\n ERROR : " + ex.Message + " - " + ex.StackTrace);
               return false;
           }

       }
        
       public ENBox buscarBox(int id)
       {
           ENBox box = new ENBox();

           using (EntitiesDaBa bd = new EntitiesDaBa())
           {
               try
               {
                   BOX bb = (from b in bd.BOX
                             where b.IDBOX == id
                             select b).FirstOrDefault();
                   box.id =Convert.ToInt16(bb.IDBOX);
                   box.tamaño = Convert.ToInt16(bb.TAMA_);
                   box.tipoBox = bb.TIPO;
                   box.descripcion = bb.DESCRIPCION;
                   return box;
               }
               catch (Exception)
               {                   
                   throw;
               }
           }
       }
      
    }    
}
