using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class AlumnoBeca
    {
        public static ML.Result GetallLINQ(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanBecaEntities context = new DL.ZJuanBecaEntities())
                {
                    var query = (from becaalumno in context.BecaAlumnoes
                                 join Alumno in context.Alumnoes on becaalumno.IdAlumno equals Alumno.IdAlumno
                                 join Beca in context.Becas on becaalumno.IdBeca equals Beca.IdBeca
                                 where becaalumno.IdAlumno == IdAlumno
                                 select new
                                 {
                                     becaalumno.IdBecaAlumno,
                                     nombreAlumno=Alumno.Nombre,
                                     nombreapAlumno=Alumno.ApellidoPaterno,
                                     nombreapmAlumno=Alumno.ApellidoMaterno,
                                     nombreBeca=Beca.Nombre,
                                     
                                     

                                 });;
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.BecaAlumno becaAlumno = new ML.BecaAlumno();

                            becaAlumno.IdBecaAlumno = obj.IdBecaAlumno;
                            becaAlumno.Alumno = new ML.Alumno();
                            becaAlumno.Alumno.Nombre = obj.nombreAlumno;
                            becaAlumno.Alumno.ApellidoPaterno = obj.nombreapAlumno;
                            becaAlumno.Alumno.ApellidoMaterno = obj.nombreapmAlumno;
                            becaAlumno.Beca = new ML.Beca();
                            becaAlumno.Beca.Nombre = obj.nombreBeca;

                            result.Objects.Add(becaAlumno);
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
                    var query = (from becaalumno in context.BecaAlumnoes
                                 join Alumno in context.Alumnoes on becaalumno.IdAlumno equals Alumno.IdAlumno
                                 join Beca in context.Becas on becaalumno.IdBeca equals Beca.IdBeca
                                 where becaalumno.IdAlumno == IdAlumno
                                 select new
                                 {
                                     becaalumno.IdBecaAlumno,
                                     nombreAlumno = Alumno.Nombre,
                                     nombreapAlumno = Alumno.ApellidoPaterno,
                                     nombreapmAlumno = Alumno.ApellidoMaterno,
                                     nombreBeca = Beca.Nombre,

                                 }).FirstOrDefault();

                    if (query != null)
                    {

                        ML.BecaAlumno becaAlumno = new ML.BecaAlumno();

                        becaAlumno.IdBecaAlumno = query.IdBecaAlumno;
                        becaAlumno.Alumno = new ML.Alumno();
                        becaAlumno.Alumno.Nombre = query.nombreAlumno;
                        becaAlumno.Alumno.ApellidoPaterno = query.nombreapAlumno;
                        becaAlumno.Alumno.ApellidoMaterno = query.nombreapmAlumno;
                        becaAlumno.Beca = new ML.Beca();
                        becaAlumno.Beca.Nombre = query.nombreBeca;
                        result.Object = becaAlumno;
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
