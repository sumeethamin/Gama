﻿#pragma checksum "D:\DotNet\Gama\RadiologyTracking\RadiologyTracking\Views\Company.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "413BF3019AC60402113E235E0734447A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RadiologyTracking.Controls;
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


namespace RadiologyTracking.Views {
    
    
    public partial class Company : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal RadiologyTracking.Controls.BusyIndicator busyIndicator;
        
        internal System.Windows.Controls.DataForm companyForm;
        
        internal System.Windows.Controls.Button btnSave;
        
        internal System.Windows.Controls.Button btnCancel;
        
        internal System.Windows.Controls.DomainDataSource companyDomainDataSource;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/RadiologyTracking;component/Views/Company.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.busyIndicator = ((RadiologyTracking.Controls.BusyIndicator)(this.FindName("busyIndicator")));
            this.companyForm = ((System.Windows.Controls.DataForm)(this.FindName("companyForm")));
            this.btnSave = ((System.Windows.Controls.Button)(this.FindName("btnSave")));
            this.btnCancel = ((System.Windows.Controls.Button)(this.FindName("btnCancel")));
            this.companyDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("companyDomainDataSource")));
        }
    }
}

