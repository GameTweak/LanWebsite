using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanWebsite.Models
{
    public class SeatStatus
    {
        public int SeatID { get; set; }

        public int BookingID { get; set; }

        public String Status { get; set; }

        public String GetStatus(int SeatNr)
        {
            String seat;

            using (LanWebsiteEntities e = new LanWebsiteEntities())
            {
                seat = (from r in e.SeatDetail 
                        where r.SeatID == SeatNr 
                        select r.Status).FirstOrDefault();
                return seat;
            } 

        }
    }
}