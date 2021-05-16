using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LanWebsite.Models;

namespace LanWebsite.Classes
{
    public class Settings
    {
        // Definere hvor mange rows og cols der skal være på booking siden
        // Begge variabler er lavet til at være public, så vi kan hente disse
        // variabler inde i andre klasser ved at lave en objekt
        public int rows = 5;
        public int cols = 15;

        // Her bliver der lavet to public Strings, som begge indeholder
        // prefixet til om det er row eller column
        public string rowCssPrefix = "row-";
        public string colCssPrefix = "col-";

        // Her bliver den højde og brede, som vores borde kommer til at have
        // på booking siden
        public int seatWidth = 52;
        public int seatHeight = 52;

        // Her laves der 3 Strings, hvor den første giver seat CSS til bordene
        // og de sidste to er den CSS der bliver brugt når en bord er optaget
        // eller valgt
        public string seatCss = "seat";
        public string selectedSeatCss = "selectedSeat";
        public string selectingSeatCss = "selectingSeat";

    }
}

/*
var settings = {
        rows: 5,
        cols: 15,
        rowCssPrefix: 'row-',
        colCssPrefix: 'col-',
        seatWidth: 35,
        seatHeight: 35,
        seatCss: 'seat',
        selectedSeatCss: 'selectedSeat',
        selectingSeatCss: 'selectingSeat'
    }; 
 
*/
