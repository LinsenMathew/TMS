using MicwayTMS.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicwayTMS.Models.BusinessLayer
{
    public class DriverFeatureManager
    {
        public IEnumerable<DriverDetail> GetDriverDetails()
        {
            DriverDataManager driverDataManager = new DriverDataManager();
            return driverDataManager.GetDriverDetails();
        }
        
        public DriverDetail GetDriverDetail(int id)
        {
            DriverDataManager driverDataManager = new DriverDataManager();
            return driverDataManager.GetDriverDetail(id);
        }
        
        public bool PutDriverDetail(int id, DriverDetail driverDetail)
        {
            DriverDataManager driverDataManager = new DriverDataManager();
            return driverDataManager.PutDriverDetail(id, driverDetail);
        }
        
        public void PostDriverDetail(DriverDetail driverDetail)
        {
            DriverDataManager driverDataManager = new DriverDataManager();
            driverDataManager.PostDriverDetail(driverDetail);
        }
        
        public DriverDetail DeleteDriverDetail(int id)
        {
            DriverDataManager driverDataManager = new DriverDataManager();
            return driverDataManager.DeleteDriverDetail(id);
        }
        
    }
}