﻿#pragma checksum "D:\DotNet\Gama\RadiographyTracking\RadiographyTracking\Views\ChangesMadeReport.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6923112095E1DF4CC053383B4A958DCF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RadiographyTracking;
using RadiographyTracking.Controls;
using RadiographyTracking.Views;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using Vagsons.Controls;


namespace RadiographyTracking.Views {
    
    
    public partial class ChangesMadeReport : RadiographyTracking.Views.BaseCRUDView {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Label headerLabel;
        
        internal System.Windows.Controls.DomainDataSource changesDomainDataSource;
        
        internal RadiographyTracking.Controls.BusyIndicator busyIndicator;
        
        internal RadiographyTracking.NotOperatorValueConverter NotConverter;
        
        internal System.Windows.Controls.CheckBox chkAllFoundries;
        
        internal System.Windows.Controls.ComboBox cmbFoundry;
        
        internal System.Windows.Controls.DatePicker fromDatePicker;
        
        internal System.Windows.Controls.DatePicker toDatePicker;
        
        internal System.Windows.Controls.Button FetchButton;
        
        internal Vagsons.Controls.CustomGrid changesDataGrid;
        
        internal System.Windows.Controls.Button btnPrint;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/RadiographyTracking;component/Views/ChangesMadeReport.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.headerLabel = ((System.Windows.Controls.Label)(this.FindName("headerLabel")));
            this.changesDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("changesDomainDataSource")));
            this.busyIndicator = ((RadiographyTracking.Controls.BusyIndicator)(this.FindName("busyIndicator")));
            this.NotConverter = ((RadiographyTracking.NotOperatorValueConverter)(this.FindName("NotConverter")));
            this.chkAllFoundries = ((System.Windows.Controls.CheckBox)(this.FindName("chkAllFoundries")));
            this.cmbFoundry = ((System.Windows.Controls.ComboBox)(this.FindName("cmbFoundry")));
            this.fromDatePicker = ((System.Windows.Controls.DatePicker)(this.FindName("fromDatePicker")));
            this.toDatePicker = ((System.Windows.Controls.DatePicker)(this.FindName("toDatePicker")));
            this.FetchButton = ((System.Windows.Controls.Button)(this.FindName("FetchButton")));
            this.changesDataGrid = ((Vagsons.Controls.CustomGrid)(this.FindName("changesDataGrid")));
            this.btnPrint = ((System.Windows.Controls.Button)(this.FindName("btnPrint")));
        }
    }
}

