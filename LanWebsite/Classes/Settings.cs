using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LanWebsite.Models;

namespace LanWebsite.Classes
{
    public class Settings
    {

        public int rows = 5;
        public int cols = 15;

        public string rowCssPrefix = "row-";
        public string colCssPrefix = "col-";

        public int seatWidth = 35;
        public int seatHeight = 35;
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
