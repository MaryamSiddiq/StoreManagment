﻿#pragma checksum "..\..\..\Pages\SGroup.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "003ABE3893119B3EB8EE4D955F6FE128C358F64D6D2C9CFDABE7B188F7CBB73B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LibraryMS.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace LibraryMS.Pages {
    
    
    /// <summary>
    /// SGroup
    /// </summary>
    public partial class SGroup : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGId;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSId;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBStatus;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker CreatedOn;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnCreate;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnRead;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFScreen;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\Pages\SGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGV;
        
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
            System.Uri resourceLocater = new System.Uri("/LibraryMS;component/pages/sgroup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SGroup.xaml"
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
            this.btnReset = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Pages\SGroup.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.btnReset_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtGId = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\Pages\SGroup.xaml"
            this.txtGId.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 63 "..\..\..\Pages\SGroup.xaml"
            this.txtGId.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtSId = ((System.Windows.Controls.TextBox)(target));
            
            #line 70 "..\..\..\Pages\SGroup.xaml"
            this.txtSId.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 71 "..\..\..\Pages\SGroup.xaml"
            this.txtSId.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CBStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.CreatedOn = ((System.Windows.Controls.DatePicker)(target));
            
            #line 93 "..\..\..\Pages\SGroup.xaml"
            this.CreatedOn.Loaded += new System.Windows.RoutedEventHandler(this.CreatedOn_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCreate = ((System.Windows.Controls.Border)(target));
            
            #line 101 "..\..\..\Pages\SGroup.xaml"
            this.btnCreate.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnCreate_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnRead = ((System.Windows.Controls.Border)(target));
            
            #line 112 "..\..\..\Pages\SGroup.xaml"
            this.btnRead.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnRead_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnUpdate = ((System.Windows.Controls.Border)(target));
            
            #line 123 "..\..\..\Pages\SGroup.xaml"
            this.btnUpdate.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnUpdate_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnFScreen = ((System.Windows.Controls.Button)(target));
            
            #line 148 "..\..\..\Pages\SGroup.xaml"
            this.btnFScreen.Click += new System.Windows.RoutedEventHandler(this.btnFScreen_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 169 "..\..\..\Pages\SGroup.xaml"
            this.txtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.DataGV = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

