using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class Alumno
    {
        public static ML.Result GetallLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanBecaEntities context = new DL.ZJuanBecaEntities())
                {
                    var query = (from alumno in context.Alumnoes
                                 select new
                                 {
                                     alumno.IdAlumno,
                                     alumno.Nombre,
                                     alumno.ApellidoPaterno,
                                     alumno.ApellidoMaterno,
                                     alumno.Genero,
                                     alumno.Edad
                                     
                                 });
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Alumno alumno= new ML.Alumno();

                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.Genero = obj.Genero.Value;
                            alumno.Edad = obj.Edad.Value;
                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetByIdLINQ(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanBecaEntities context = new DL.ZJuanBecaEntities())
                {
                    var query = (from alumno in context.Alumnoes
                                 where alumno.IdAlumno == IdAlumno
                                 select new
                                 {
                                     alumno.IdAlumno,
                                     alumno.Nombre,
                                     alumno.ApellidoPaterno,
                                     alumno.ApellidoMaterno,
                                     alumno.Genero,
                                     alumno.Edad

                                 }).FirstOrDefault();
                    
                    if (query != null )
                    {
                        
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = query.IdAlumno;
                            alumno.Nombre = query.Nombre;
                            alumno.ApellidoPaterno = query.ApellidoPaterno;
                            alumno.ApellidoMaterno = query.ApellidoMaterno;
                            alumno.Genero = query.Genero.Value;
                            alumno.Edad = query.Edad.Value;
                        result.Object = alumno;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result AddLINQ(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanBecaEntities contex = new DL.ZJuanBecaEntities())
                {
                    DL.Alumno alumnodl = new DL.Alumno();

                    alumnodl.Nombre = alumno.Nombre;
                    alumnodl.ApellidoPaterno = alumno.ApellidoPaterno;
                    alumnodl.ApellidoMaterno = alumno.ApellidoMaterno;
                    alumnodl.Genero = alumno.Genero;
                    alumnodl.Edad = alumno.Edad;
                    contex.Alumnoes.Add(alumnodl);
                    var query = contex.SaveChanges();
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result UpdateLINQ(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanBecaEntities contex = new DL.ZJuanBecaEntities())
                {
                    var query = (from alumnodl in contex.Alumnoes
                                where alumnodl.IdAlumno == alumno.IdAlumno
                                select alumnodl).SingleOrDefault();
                    if (query != null)
                    {

                        query.Nombre = alumno.Nombre;
                        query.ApellidoPaterno = alumno.ApellidoPaterno;
                        query.ApellidoMaterno = alumno.ApellidoMaterno;
                        query.Genero = alumno.Genero;
                        query.Edad = alumno.Edad;
                        contex.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result DeleteLINQ(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanBecaEntities contex = new DL.ZJuanBecaEntities())
                {
                    var query = (from alumnodl in contex.Alumnoes
                                 where alumnodl.IdAlumno == IdAlumno
                                 select alumnodl).First();
                    if (query != null)
                    {
                        contex.Alumnoes.Remove(query);
                        contex.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
