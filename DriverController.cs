using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TMSView.Models;

namespace TMSView.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        public ActionResult Index()
        {
            IEnumerable<DriverDetail> driverDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51410/api/driver");
                //HTTP GET
                var responseTask = client.GetAsync("driver");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<DriverDetail>>();
                    readTask.Wait();

                    driverDetail = readTask.Result;
                }
                else 
                {
                    driverDetail = Enumerable.Empty<DriverDetail>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(driverDetail);

        }

        // GET: Driver/Details/5
        public ActionResult Details(int id)
        {
            DriverDetail driverDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51410/");
                //HTTP GET

                var responseTask =  client.GetAsync("api/driver/" + id );
                
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DriverDetail>();
                    readTask.Wait();

                    driverDetail = readTask.Result;
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(driverDetail);

        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(DriverDetail driverDetail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51410/api/driver");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<DriverDetail>("driver", driverDetail);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(driverDetail);
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            
            DriverDetail driverDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51410/");
                //HTTP GET

                var responseTask = client.GetAsync("api/driver/" + id);

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DriverDetail>();
                    readTask.Wait();

                    driverDetail = readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(driverDetail);
            
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DriverDetail driverDetail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51410/");

                //HTTP POST
                var responseTask = client.PutAsJsonAsync<DriverDetail>("api/driver/" + id, driverDetail);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();
            
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Driver/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51410/");
                //HTTP GET

                var responseTask = client.DeleteAsync("api/driver/" + id);
                
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                    
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View();
            
        }
    }
}
