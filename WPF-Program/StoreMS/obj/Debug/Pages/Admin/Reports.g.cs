﻿#pragma checksum "..\..\..\..\Pages\Admin\Reports.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "21B3067933A0029D4AFA9FE6442482753E88A05A12F091D56B856EF45025102D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StoreMS.Pages.Admin;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace StoreMS.Pages.Admin {
    
    
    /// <summary>
    /// Reports
    /// </summary>
    public partial class Reports : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Pages\Admin\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBReport;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Pages\Admin\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRefresh;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\Admin\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFScreen;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Pages\Admin\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Pages\Admin\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGV;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\Pages\Admin\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnDownload;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StoreMS;component/pages/admin/reports.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Admin\Reports.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CBReport = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\..\..\Pages\Admin\Reports.xaml"
            this.CBReport.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBReport_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\Pages\Admin\Reports.xaml"
            this.btnRefresh.Click += new System.Windows.RoutedEventHandler(this.btnRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnFScreen = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\Pages\Admin\Reports.xaml"
            this.btnFScreen.Click += new System.Windows.RoutedEventHandler(this.btnFScreen_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 91 "..\..\..\..\Pages\Admin\Reports.xaml"
            this.txtSearch.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 92 "..\..\..\..\Pages\Admin\Reports.xaml"
            this.txtSearch.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            
            #line 93 "..\..\..\..\Pages\Admin\Reports.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataGV = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnDownload = ((System.Windows.Controls.Border)(target));
            
            #line 104 "..\..\..\..\Pages\Admin\Reports.xaml"
            this.btnDownload.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnDownload_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

