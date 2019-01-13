using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MicwayTMS.Models.DataLayer
{
    public class DriverDataManager
    {
        private TMSEntities1 db = new TMSEntities1();

        public IEnumerable<DriverDetail> GetDriverDetails()
        {
            return db.DriverDetails.ToList();
        }
        
        public DriverDetail GetDriverDetail(int id)
        {
            return db.DriverDetails.Find(id);
        }
        
        public bool PutDriverDetail(int id, DriverDetail driverDetail)
        {
            db.Entry(driverDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverDetailExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;

        }
        
        private bool DriverDetailExists(int id)
        {
            return db.DriverDetails.Count(e => e.Id == id) > 0;
        }
        
        public void PostDriverDetail(DriverDetail driverDetail)
        {
            db.DriverDetails.Add(driverDetail);
            db.SaveChanges();
        }
        
        public DriverDetail DeleteDriverDetail(int id)
        {
            DriverDetail driverDetail = db.DriverDetails.Find(id);
            
            db.DriverDetails.Remove(driverDetail);
            db.SaveChanges();
            return driverDetail;
        }
        
    }
}

