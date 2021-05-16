using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanWebsite.Models
{
    public class SeatStatus
    {
        // Her gøres der sådan at vi vil kunne sætte og hente de forskellige variabler fra Databasne
        // Med de følgende 
        public int SeatID { get; set; }
        public int BookingID { get; set; }
        public String Status { get; set; }

        // Denne metode forbinder til databasen og returnere en string værdi fra den.
        // Metoden er dog også sat op sådan at den har brug for en int parameter for at
        // for at returerne værdien
        public String GetStatus(int SeatNr)
        {
            // Her initialisere der en String variable, hvilken bliver den som metoden returnere
            // Når den er kørt igennem
            String seat;

            // Her forbindes der til SQL databasen 
            using (LanWebsiteEntities e = new LanWebsiteEntities())
            {
                // Her er lavet en try/catch, hvilket gør sådan hvis der skulle opstå en problem
                // bliver execpetion "kastet" til console, så der kan ses hvad der gik galt
                try
                {
                    // Her sættes vores string variable til at være lig med string variable
                    // der står i den angivet "SeatNr" status kolunne.
                    // Måden (from) delen virker er at den er sat op ligesom en SQL Query.
                    // Så når der siges from r, er det DB'en den tager fat i og ved
                    // e.SeatDetail specificere at det er den tabel der skal bruges.
                    // Where bruges til at sige at sammeligne parameterens værdi
                    // med den som matcher i DB, som der så selectes og returner
                    // den værdi der står i "Status" kolunnen.
                    seat = (from r in e.SeatDetail 
                        where r.SeatID == SeatNr 
                        select r.Status).FirstOrDefault();
                    return seat;
                } catch (Exception ex)
                {
                    // Skriver erroren i loggen.
                    Console.WriteLine(ex.ToString());
                    return "Error";
                }
                
            } 

        }

        // Her laves en public metode der returnere en int variable med den total antal af border
        public int GetSeatAmount()
        {
            int amount = 0; // Init af antallet af border
            List<int> list; // Init af en Liste

            // Forbindes til DB
            using (LanWebsiteEntities e = new LanWebsiteEntities())
            {
                // Her bruges endnu en try/catch der vil sige hvis nået går galt
                try
                {
                    // Her sættes vores list til at være lig med en liste af alle
                    // de border der er.
                    list = (from r in e.SeatDetail select r.SeatID).ToList();

                    // Her bruges der en foreach løkke, der looper gennem alle de ints der er i listen
                    // og for hver af dem, tilføjes der en nummer til amount værdien.
                    foreach(int num in list)
                    {
                         amount++;
                    }
                    // Returnere antallet af borde
                    return amount;
                } catch (Exception ex)
                {
                    // Sender en error besked i consolen
                    Console.WriteLine(ex.ToString());
                    return 0;
                }
                
            }
        }
    }
}