using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAutoSupplying
{
    class DBInteract
    {
        public static void DeleteWayList(Models.WayList wayList)
        {
            Models.DatabaseEntities2 db = new Models.DatabaseEntities2();
            var downTimes = db.DownTime_on_Lines.Where(x => x.WayList_ID == wayList.Id);
            foreach (var obj in downTimes)
                db.DownTime_on_Lines.Remove(obj);
            var carTrailer = db.Car_Tralers_in_WayList.Where(x => x.WayList_ID == wayList.Id);
            foreach (var obj in carTrailer)
                db.Car_Tralers_in_WayList.Remove(obj);
            var driverWorks = db.Driver_Works.Where(x => x.Way_List_ID == wayList.Id);
            foreach (var obj in driverWorks)
                db.Driver_Works.Remove(obj);
        }
    }
}
