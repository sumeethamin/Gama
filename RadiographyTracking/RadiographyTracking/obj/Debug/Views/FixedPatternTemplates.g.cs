﻿#pragma checksum "D:\DotNet\Gama\RadiologyTracking\RadiographyTracking\Views\FixedPatternTemplates.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BB5A6A7BBE53F633319F0471A244EE34"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
    
    public partial class FixedPatternTemplates : RadiographyTracking.Views.BaseCRUDView {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.DomainDataSource FPTemplatesSource;
        
        internal System.Windows.Controls.Label headerLabel;
        
        internal System.Windows.Controls.TextBlock txtFPNo;
        
        internal System.Windows.Controls.TextBlock txtCustomer;
        
        internal System.Windows.Controls.TextBlock txtDescription;
        
        internal System.Windows.Controls.TextBlock txtFPTemplateID;
        
        internal System.Windows.Controls.ComboBox cmbCoverage;
        
        internal RadiographyTracking.Controls.BusyIndicator busyIndicator;
        
        internal Vagsons.Controls.CustomGrid FPTemplatesDataGrid;
        
        internal System.Windows.Controls.StackPanel ButtonsPanel;
        
        internal System.Windows.Controls.Button btnSave;
        
        internal System.Windows.Controls.Button btnCancel;
        
        internal System.Windows.Controls.Button btnAdd;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/RadiographyTracking;component/Views/FixedPatternTemplates.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.FPTemplatesSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("FPTemplatesSource")));
            this.headerLabel = ((System.Windows.Controls.Label)(this.FindName("headerLabel")));
            this.txtFPNo = ((System.Windows.Controls.TextBlock)(this.FindName("txtFPNo")));
            this.txtCustomer = ((System.Windows.Controls.TextBlock)(this.FindName("txtCustomer")));
            this.txtDescription = ((System.Windows.Controls.TextBlock)(this.FindName("txtDescription")));
            this.txtFPTemplateID = ((System.Windows.Controls.TextBlock)(this.FindName("txtFPTemplateID")));
            this.cmbCoverage = ((System.Windows.Controls.ComboBox)(this.FindName("cmbCoverage")));
            this.busyIndicator = ((RadiographyTracking.Controls.BusyIndicator)(this.FindName("busyIndicator")));
            this.FPTemplatesDataGrid = ((Vagsons.Controls.CustomGrid)(this.FindName("FPTemplatesDataGrid")));
            this.ButtonsPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ButtonsPanel")));
            this.btnSave = ((System.Windows.Controls.Button)(this.FindName("btnSave")));
            this.btnCancel = ((System.Windows.Controls.Button)(this.FindName("btnCancel")));
            this.btnAdd = ((System.Windows.Controls.Button)(this.FindName("btnAdd")));
        }
    }
}
