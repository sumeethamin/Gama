﻿#pragma checksum "D:\ClientWork\Gama\Sources\RadiographyTracking\RadiographyTracking\Views\ThicknessToEnergyType.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A849A102B4F9A0E78A52863867E6C35E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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
    
    
    public partial class ThicknessToEnergyType : RadiographyTracking.Views.BaseCRUDView {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Label headerLabel;
        
        internal System.Windows.Controls.DomainDataSource thicknessRangeForEnergyDomainDataSource;
        
        internal System.Windows.Controls.TextBox filterTextBox;
        
        internal RadiographyTracking.Controls.BusyIndicator busyIndicator;
        
        internal Vagsons.Controls.CustomGrid grdThicknessRangeForEnergy;
        
        internal System.Windows.Controls.DataGridTextColumn thicknessFromColumn;
        
        internal System.Windows.Controls.DataGridTextColumn thicknessToColumn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/RadiographyTracking;component/Views/ThicknessToEnergyType.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.headerLabel = ((System.Windows.Controls.Label)(this.FindName("headerLabel")));
            this.thicknessRangeForEnergyDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("thicknessRangeForEnergyDomainDataSource")));
            this.filterTextBox = ((System.Windows.Controls.TextBox)(this.FindName("filterTextBox")));
            this.busyIndicator = ((RadiographyTracking.Controls.BusyIndicator)(this.FindName("busyIndicator")));
            this.grdThicknessRangeForEnergy = ((Vagsons.Controls.CustomGrid)(this.FindName("grdThicknessRangeForEnergy")));
            this.thicknessFromColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("thicknessFromColumn")));
            this.thicknessToColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("thicknessToColumn")));
            this.btnSave = ((System.Windows.Controls.Button)(this.FindName("btnSave")));
            this.btnCancel = ((System.Windows.Controls.Button)(this.FindName("btnCancel")));
            this.btnAdd = ((System.Windows.Controls.Button)(this.FindName("btnAdd")));
        }
    }
}

