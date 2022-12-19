using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class AlumnoController : ApiController
    {
        // GET: api/Alumno
        [HttpGet]
        [Route("api/Alumno/Get")]

        public IHttpActionResult Get()
        {
            ML.Alumno alumno = new ML.Alumno();

            ML.Result result = Bl.Alumno.GetallLINQ();

            if (result.Correct)
            {

                alumno.Alumnos = result.Objects;
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // GET: api/Materia/5
        [HttpGet]
        [Route("api/Alumno/GetById/{IdAlumno}")]

        public IHttpActionResult GetById(int IdAlumno)
        {
            ML.Alumno materia = new ML.Alumno();

            ML.Result result = Bl.Alumno.GetByIdLINQ(IdAlumno);
            if (result.Correct)
            {


                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // POST: api/Materia
        [HttpPost]
        [Route("api/Alumno/Post")]

        public IHttpActionResult Post([FromBody] ML.Alumno alumno)
        {

            ML.Result result = Bl.Alumno.AddLINQ(alumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


        // PUT: api/Materia/5
        [HttpPut]
        [Route("api/Alumno/Put/{IdAlumno}")]

        public IHttpActionResult Put(int IdAlumno, [FromBody] ML.Alumno alumno)
        {
            ML.Result result = Bl.Alumno.UpdateLINQ(alumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // DELETE: api/Materia/5
        [HttpGet]
        [Route("api/Alumno/Delete/{IdAlumno}")]

        public IHttpActionResult Delete(int IdAlumno)
        {
            ML.Result result = Bl.Alumno.DeleteLINQ(IdAlumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
