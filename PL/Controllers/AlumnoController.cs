using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIUrl"]);

                    var responseTask = client.GetAsync("api/Alumno/Get");
                    //result = bl.Usuario.GetAll();

                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        result.Objects = new List<object>();
                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Alumno resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Alumno>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            if (result.Correct)
            {
                
                alumno.Alumnos = result.Objects;
                return View(alumno);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error, no se pueden mostar los registro ";
                return View();
            }

        }
          
        // GET: Alumno/Details/5
        public ActionResult Form(int? IdAlumno)
        { 
            ML.Alumno alumno = new ML.Alumno();

            if (IdAlumno == null)
            {
                
                return View(alumno);
            }
            else
            {
                ML.Result result = new ML.Result();
                try
                {
                    
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIUrl"]);

                        var responseTask = client.GetAsync("api/Alumno/GetById/"+IdAlumno);

                        responseTask.Wait();

                        var resultServicio = responseTask.Result;

                        if (resultServicio.IsSuccessStatusCode)
                        {
                            var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Alumno resultItemList = new ML.Alumno();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Alumno>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;
                            result.Correct = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }
                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                   

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar al usuario seleccionado";
                }
                return View(alumno);
            }
        }
        

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            if (alumno.IdAlumno == 0)
            {
                //add
               

                try
                {

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIUrl"]);

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<ML.Alumno>("api/Alumno/Post", alumno);
                        postTask.Wait();

                       var resultSer = postTask.Result;
                        if (resultSer.IsSuccessStatusCode)
                        {
                            return RedirectToAction("GetAll");
                        }
                    }

                    return View("GetAll");
                }


                
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }
            }
            else
            {
                //update
                try
                {

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIUrl"]);

                        //HTTP POST
                        var postTask = client.PutAsJsonAsync<ML.Alumno>("api/Alumno/Put/"+ alumno.IdAlumno , alumno);
                        postTask.Wait();

                        var resultSer = postTask.Result;
                        if (resultSer.IsSuccessStatusCode)
                        {
                            return RedirectToAction("GetAll");
                        }
                    }

                    return View("GetAll");
                }



                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }

            }

            return PartialView("Modal");

        }

    
        [HttpGet]
        public ActionResult Delete(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIUrl"]);

                    //HTTP POST
                    var postTask = client.GetAsync("api/Alumno/Delete/" + IdAlumno);
                    postTask.Wait();

                    var resultSer = postTask.Result;
                    if (resultSer.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAll");
                    }
                }

                return View("GetAll");
            }



            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return PartialView("Modal");
        }
    }
}
