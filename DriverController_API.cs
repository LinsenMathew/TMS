using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MicwayTMS.Models;
using MicwayTMS.Models.BusinessLayer;

namespace MicwayTMS.Controllers
{
    public class DriverController : ApiController
    {
        private TMSEntities1 db = new TMSEntities1();

        // GET: api/Driver
        public IEnumerable<DriverDetail> GetDriverDetails()
        {
            DriverFeatureManager driverFeatureManager = new DriverFeatureManager();
            return driverFeatureManager.GetDriverDetails();
        }

        // GET: api/Driver/5
        [ResponseType(typeof(DriverDetail))]
        public IHttpActionResult GetDriverDetail(int id)
        {
            DriverFeatureManager driverFeatureManager = new DriverFeatureManager();
            DriverDetail driverDetail = driverFeatureManager.GetDriverDetail(id);
            
            if (driverDetail == null)
            {
                return NotFound();
            }

            return Ok(driverDetail);
        }

        // PUT: api/Driver/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverDetail(int id, DriverDetail driverDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driverDetail.Id)
            {
                return BadRequest();
            }
            
            DriverFeatureManager driverFeatureManager = new DriverFeatureManager();

            if (!driverFeatureManager.PutDriverDetail(id, driverDetail))
                return NotFound();
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Driver
        [ResponseType(typeof(DriverDetail))]
        public IHttpActionResult PostDriverDetail(DriverDetail driverDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            DriverFeatureManager driverFeatureManager = new DriverFeatureManager();
            driverFeatureManager.PostDriverDetail(driverDetail);
            
            return CreatedAtRoute("DefaultApi", new { id = driverDetail.Id }, driverDetail);
        }

        // DELETE: api/Driver/5
        [ResponseType(typeof(DriverDetail))]
        public IHttpActionResult DeleteDriverDetail(int id)
        {
            DriverFeatureManager driverFeatureManager = new DriverFeatureManager();
            DriverDetail driverDetail = driverFeatureManager.DeleteDriverDetail(id);
            
            return Ok(driverDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}