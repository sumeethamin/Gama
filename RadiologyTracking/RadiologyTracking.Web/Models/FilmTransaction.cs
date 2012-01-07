﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadiologyTracking.Web.Models
{
    public class FilmTransaction
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Foundry Foundry { get; set; }
        public String ChallanNo { get; set; }
        public Direction Direction { get; set; }
        public int Area { get; set; }
    }
}