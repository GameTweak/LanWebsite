using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanWebsite.Models;

namespace LanWebsite.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BookSeat(String User, String SeatID)
        {
            int seatID; // Init en integer variable der sættes til at være lig med det input fra Booking
            int users; // Init endnu en variable, der sættes til at være lig med User inputtet fra Booking siden

            if(int.TryParse(User, out int UserID) && int.TryParse(SeatID, out int SeatsID))
            {
                users = UserID;
                seatID = SeatsID;
                using (LanWebsiteEntities e = new LanWebsiteEntities())
                {
                    // Her laves der et objekt, hvilket bliver den der bruges til at få værdierne fra Databasen
                    SeatDetail seat = new SeatDetail();

                    /* 
                      Her laves der to variabler der går ind og sammenligner det input givet på hjemmesiden med den information der
                      står i vores SQL Database. Den værdi den får tilbage fra det bliver sat lig med den nye "seatDetails" variable 
                      og det samme sker der ved "isUser". 

                      De to mulige resultater enten et tal over 1 eller 0. Nul forekommer kun hvis det nummer der angives
                      ikke eksistere på databasen.
                    */
                    var seatDetails = (from r in e.SeatDetail where r.SeatID == seatID select r.SeatID).FirstOrDefault();
                    var isUser = (from r in e.Booking where r.BookingID == users select r.BookingID).FirstOrDefault();

                    // Her er lavet en try/catch, hvilket gør sådan hvis der skulle opstå en problem
                    // bliver execpetion "kastet" til console, så der kan ses hvad der gik galt
                    try
                    {
                        // If statement der tjekker om en af de to variabler ikke eksistere i databasne
                        if (seatDetails == 0 || isUser == 0)
                        {
                            // Logger problemet til DB
                            System.Diagnostics.Debug.WriteLine("Either the user or seat does not exist");

                            // Refresher siden
                            return View("Booking");
                        }
                        else
                        {
                            // Her køres der en Sql Query, som bruges til at opdatere den information der står inde på DB med den nye bord status.
                            e.Database.ExecuteSqlCommand("UPDATE SeatDetail SET BookingID='" + users + "', Status='selectedSeat' WHERE SeatID=" + seatID);
                            System.Diagnostics.Debug.WriteLine(seatDetails + " " + isUser);
                            return View("Booking");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Her viser den hvis der skulle forekomme en fejl i Consolen
                        System.Diagnostics.Debug.WriteLine(ex);
                        return View("Index");
                    }

                }
            } else {
                return View("Booking");
            }
        }
            //if(User == null)
            // Forbindelse til databasen bliver oprettet

    }
}