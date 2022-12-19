using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class BecaAlumnoController : Controller
    {
        [HttpGet]
        public ActionResult GetAllalu()
        {
            ML.Result result = new ML.Result();
            ML.Alumno alumno = new ML.Alumno();
            //ML.Usuario usuario = new ML.Usuario();
            result = Bl.Alumno.GetallLINQ();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error, no se pueden mostar los registro ";
            }
            return View(alumno);
        }
        // GET: BecaAlumno
        [HttpGet]
        //public ActionResult GetAll()
        //{
        //    ML.Result result = new ML.Result();
        //    ML.BecaAlumno becaAlumno = new ML.BecaAlumno();
        //    //ML.Usuario usuario = new ML.Usuario();
        //    result = Bl.AlumnoBeca.GetallLINQ();
        //    if (result.Correct)
        //    {
        //        becaAlumno.BecaAlunmos = result.Objects;
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Ocurrio un error, no se pueden mostar los registro ";
        //    }
        //    return View(becaAlumno);
        //}

        // GET: BecaAlumno/Details/5
        public ActionResult GetAll(int? IdAlumno)
        {
            ML.BecaAlumno becaAlumno = new ML.BecaAlumno();
            ML.Result result = new ML.Result();
            becaAlumno.Alumno = new ML.Alumno();
            becaAlumno.Beca = new ML.Beca();
            var resbeca = Bl.Beca.GetallLINQ();
            
            if (IdAlumno == null)
            {
                becaAlumno.BecaAlunmos = result.Objects;

                return View(becaAlumno);
            }

            else
            {
              result = Bl.AlumnoBeca.GetallLINQ(IdAlumno.Value);

                if (result.Correct)
                {
                    
                    becaAlumno.BecaAlunmos = result.Objects;

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar las becas del alumno ";
                }
                return View(becaAlumno);
            }
        }

        // POST: BecaAlumno/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BecaAlumno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BecaAlumno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BecaAlumno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BecaAlumno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
