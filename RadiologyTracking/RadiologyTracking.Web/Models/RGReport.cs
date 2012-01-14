﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.DomainServices.Server;
using System.ComponentModel.DataAnnotations;

namespace RadiologyTracking.Web.Models
{
    /// <summary>
    /// This class represents a single Radiography report entry, which forms the basis of all the work done 
    /// by the users of this software
    /// </summary>
    public class RGReport
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int FixedPatternID { get; set; }
        public FixedPattern FixedPattern { get; set; }

        public String LeadScreen { get; set; }
        public ICollection<RGReportSource> Sources { get; set; }
        public String SourceSize { get; set; }
        public String RTNo { get; set; }
        public String ReportNo { get; set; }
        public String HeatNo { get; set; }
        public String ProcedureRef { get; set; }
        public String Specifications { get; set; }
        public DateTime ReportDate { get; set; }
        public String Film { get; set; }
        public DateTime DateOfTest { get; set; }

        public int ShiftID { get; set; }
        public Shift Shift { get; set; }

        public String EvaluationAsPer { get; set; }
        public String AcceptanceAsPer { get; set; }
        public String DrawingNo { get; set; }

        public int StatusID { get; set; }
        public RGStatus Status { get; set; }

        [Include, Composition]
        public ICollection<RGReportRow> RGReportRows { get; set; }
        public String Result { get; set; }
    }
}