﻿#pragma checksum "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D84D81B8CDEE5414B3FB3C0BBF14E5E0C380CC89ECE3141EF6B852DCE2C323F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StoreMS;
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
using WPFModernVerticalMenu.Controls;


namespace StoreMS.Pages.Admin {
    
    
    /// <summary>
    /// ViewTransactionWindow
    /// </summary>
    public partial class ViewTransactionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal StoreMS.Pages.Admin.ViewTransactionWindow home;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDateTime;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblEmail;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotal;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGiftCard;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblLoyalty;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPaid;
        
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
            System.Uri resourceLocater = new System.Uri("/StoreMS;component/pages/admin/viewtransactionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
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
            this.home = ((StoreMS.Pages.Admin.ViewTransactionWindow)(target));
            return;
            case 2:
            this.lblDateTime = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblEmail = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.DataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            
            #line 44 "..\..\..\..\Pages\Admin\ViewTransactionWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblGiftCard = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblLoyalty = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblPaid = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

