﻿#pragma checksum "..\..\..\..\Pages\Admin\GiftCards.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5F2FB75CCFEAF4D8A4C4B5F9D6349C43A49019CD3DE404D0861636F4C8F6D665"
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
    /// GiftCards
    /// </summary>
    public partial class GiftCards : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 39 "..\..\..\..\Pages\Admin\GiftCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNumberOfCards;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Pages\Admin\GiftCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBalance;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\Admin\GiftCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnGenerateCards;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Pages\Admin\GiftCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtGenerate;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Pages\Admin\GiftCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtGenerate2;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\Pages\Admin\GiftCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path generateIcon;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Pages\Admin\GiftCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGiftCardSearch;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\Pages\Admin\GiftCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid giftCardDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/StoreMS;component/pages/admin/giftcards.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Admin\GiftCards.xaml"
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
            this.txtNumberOfCards = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.txtNumberOfCards.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.txtNumberOfCards.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtBalance = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.txtBalance.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.txtBalance.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnGenerateCards = ((System.Windows.Controls.Border)(target));
            
            #line 71 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.btnGenerateCards.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnGenerateCards_MouseDown);
            
            #line default
            #line hidden
            
            #line 72 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.btnGenerateCards.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btnGenerateCards_MouseEnter);
            
            #line default
            #line hidden
            
            #line 73 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.btnGenerateCards.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnGenerateCards_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtGenerate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtGenerate2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.generateIcon = ((System.Windows.Shapes.Path)(target));
            return;
            case 7:
            this.txtGiftCardSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 114 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.txtGiftCardSearch.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 115 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.txtGiftCardSearch.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            
            #line 116 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            this.txtGiftCardSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtGiftCardSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.giftCardDataGrid = ((System.Windows.Controls.DataGrid)(target));
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
            case 9:
            
            #line 135 "..\..\..\..\Pages\Admin\GiftCards.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

