﻿#pragma checksum "..\..\..\..\Pages\Admin\Customers.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4F7FBBEB0082B43558FF0C278B7E7C311FFF4B5F76E1D7D55926A371C5CB69D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using StoreMS;
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


namespace StoreMS.Pages.Admin {
    
    
    /// <summary>
    /// Customers
    /// </summary>
    public partial class Customers : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 39 "..\..\..\..\Pages\Admin\Customers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Pages\Admin\Customers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Pages\Admin\Customers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLoyaltyPoints;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Pages\Admin\Customers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnAddCustomer;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\Pages\Admin\Customers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAdd;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\Pages\Admin\Customers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtAdd2;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Pages\Admin\Customers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path customerIcon;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\Pages\Admin\Customers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerSearch;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\Pages\Admin\Customers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid customerDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/StoreMS;component/pages/admin/customers.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Admin\Customers.xaml"
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
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.txtName.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.txtName.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.txtEmail.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.txtEmail.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtLoyaltyPoints = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.txtLoyaltyPoints.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 76 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.txtLoyaltyPoints.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAddCustomer = ((System.Windows.Controls.Border)(target));
            
            #line 91 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.btnAddCustomer.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnAddCustomer_MouseDown);
            
            #line default
            #line hidden
            
            #line 92 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.btnAddCustomer.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btnAddCustomer_MouseEnter);
            
            #line default
            #line hidden
            
            #line 93 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.btnAddCustomer.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnAddCustomer_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtAdd = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtAdd2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.customerIcon = ((System.Windows.Shapes.Path)(target));
            return;
            case 8:
            this.txtCustomerSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 134 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.txtCustomerSearch.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 135 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.txtCustomerSearch.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            
            #line 136 "..\..\..\..\Pages\Admin\Customers.xaml"
            this.txtCustomerSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtCustomerSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.customerDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 10:
            
            #line 156 "..\..\..\..\Pages\Admin\Customers.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 157 "..\..\..\..\Pages\Admin\Customers.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

