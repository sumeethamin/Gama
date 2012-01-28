﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RadiologyTracking.Web.Models
{
    /// <summary>
    /// Extensions to the <see cref="Remark"/> class.
    /// </summary>
    public partial class Remark
    {
        public override String ToString()
        {
            return this.Value;
        }
    }
}
