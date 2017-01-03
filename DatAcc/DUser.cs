using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
namespace DatAcc
{
    public class DUser
    {

        public Boolean ValidarUsuario(String user, String password)
        {
            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    USUARIOS bdUsuarios = (from u in bd.USUARIOS
                                           where u.USERNAME == user && u.PASSWORD == password
                                           select u).FirstOrDefault();
                    if (bdUsuarios.PASSWORD.Equals(password))
                    {
                        return true;
                    }
                }
                catch (EntitySqlException e)
                {
                    Console.Write(e.StackTrace); 
                    throw;
                }
            }
            return false;
        }

        public String returnTipoUsuario(String username)
        {
            String aux = "";
            
            using(EntitiesDaBa bd = new EntitiesDaBa()){
                try
                {
                        aux =  Convert.ToString( (from u in bd.USUARIOS where
                                u.USERNAME == username 
                                select u.TIPOUSUARIO));

                        return aux;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.StackTrace); 
                    throw;
                }           
            }         
        }


        public String returnPofesionUsuario(String username) // JOIN?
        {
            String aux = "";

            using(EntitiesDaBa bd = new EntitiesDaBa()){

                try
                {
                    aux = Convert.ToString((from u in bd.USUARIOS
                                            join
                                                p in bd.PERSONAS on
                                                u.PERSONAS_ID_PERSONA equals p.ID_PERSONA
                                            where u.USERNAME == username
                                            select p.TIPOPERSONA_ID));
                    return aux;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return null;
                }
            }

        }


        public int returnIDPersona(String username)
        {
            int aux ;


            using(EntitiesDaBa bd = new EntitiesDaBa()){
                try
                {
                    aux = Convert.ToInt16((from u in bd.USUARIOS
                               where u.USERNAME == username
                               select u.PERSONAS_ID_PERSONA));
                    return aux;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.StackTrace); 
                    throw;
                }
            }
        }
               

        public EUsuario buscarUsuario(String username)
        {
            EUsuario aux = new EUsuario() ;

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {

                    USUARIOS ubd = (from u in bd.USUARIOS 
                           where u.USERNAME == username
                           select u).FirstOrDefault();

                    aux.Id = Convert.ToInt16(ubd.IDUSUARIOS);
                    aux.id_persona = Convert.ToInt16(ubd.PERSONAS_ID_PERSONA);
                    aux.id_tipousuario = Convert.ToInt16(ubd.TIPOUSUARIO);
                    aux.password = ubd.PASSWORD;
                    aux.username = ubd.USERNAME;

                    return aux;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return null;
                }

            }
        }

        public List<EUsuario> listarUsuarios()
        {
            List<USUARIOS> bdlist = new List<USUARIOS>();
            List<EUsuario> auxlist = new List<EUsuario>();

            using (EntitiesDaBa bd = new EntitiesDaBa())
            {
                try
                {
                    bdlist = (from b in bd.USUARIOS
                              select b).ToList<USUARIOS>();
                    foreach (USUARIOS item in bdlist)
                    {
                        EUsuario nu = this.buscarUsuario(item.USERNAME) ;
                        auxlist.Add(nu);
                    }
                    return auxlist;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return null;

                }
            }
        }

        public bool modificar(EUsuario user) // cambiar por el username
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    USUARIOS objUser = (from u in ctx.USUARIOS
                                         where u.IDUSUARIOS == user.Id
                                         select u).FirstOrDefault();

                    objUser.IDUSUARIOS = user.Id;
                    objUser.PASSWORD = user.password;
                    objUser.PERSONAS_ID_PERSONA = user.id_persona;
                    objUser.TIPOUSUARIO = user.id_tipousuario;
                    objUser.USERNAME = user.username;

                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }


        }

        public bool insertar(EUsuario user) // cambiar por el username
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    USUARIOS objUser = new USUARIOS();

                    objUser.IDUSUARIOS = user.Id;
                    objUser.PASSWORD = user.password;
                    objUser.PERSONAS_ID_PERSONA = user.id_persona;
                    objUser.TIPOUSUARIO = user.id_tipousuario;
                    objUser.USERNAME = user.username;
                    ctx.AddToUSUARIOS(objUser);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("ERROR: "+ex.Message+" - "+ex.StackTrace);
                return false;
            }
        }

        public bool eliminar(String username)
        {
            try
            {
                using (var ctx = new EntitiesDaBa())
                {
                    USUARIOS us = (from u in ctx.USUARIOS
                                          where u.USERNAME == username
                                          select u).FirstOrDefault();
                    ctx.USUARIOS.DeleteObject(us);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                return false;
            }


        }


    }
}
