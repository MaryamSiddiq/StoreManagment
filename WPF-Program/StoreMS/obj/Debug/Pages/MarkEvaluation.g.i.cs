﻿#pragma checksum "..\..\..\Pages\MarkEvaluation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8EA48F1F9AD6663EF3BB7C3AFECD506D36DB52023505F1E5914FBCE6B063398A"
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
    /// MarkEvaluation
    /// </summary>
    public partial class MarkEvaluation : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGId;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEId;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOMarks;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker CreatedOn;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnCreate;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnRead;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFScreen;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\Pages\MarkEvaluation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\Pages\MarkEvaluation.xaml"
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
            System.Uri resourceLocater = new System.Uri("/LibraryMS;component/pages/markevaluation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\MarkEvaluation.xaml"
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
            
            #line 48 "..\..\..\Pages\MarkEvaluation.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.btnReset_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtGId = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\Pages\MarkEvaluation.xaml"
            this.txtGId.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 63 "..\..\..\Pages\MarkEvaluation.xaml"
            this.txtGId.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtEId = ((System.Windows.Controls.TextBox)(target));
            
            #line 70 "..\..\..\Pages\MarkEvaluation.xaml"
            this.txtEId.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 71 "..\..\..\Pages\MarkEvaluation.xaml"
            this.txtEId.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtOMarks = ((System.Windows.Controls.TextBox)(target));
            
            #line 78 "..\..\..\Pages\MarkEvaluation.xaml"
            this.txtOMarks.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 79 "..\..\..\Pages\MarkEvaluation.xaml"
            this.txtOMarks.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CreatedOn = ((System.Windows.Controls.DatePicker)(target));
            
            #line 91 "..\..\..\Pages\MarkEvaluation.xaml"
            this.CreatedOn.Loaded += new System.Windows.RoutedEventHandler(this.CreatedOn_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCreate = ((System.Windows.Controls.Border)(target));
            
            #line 99 "..\..\..\Pages\MarkEvaluation.xaml"
            this.btnCreate.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnCreate_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnRead = ((System.Windows.Controls.Border)(target));
            
            #line 110 "..\..\..\Pages\MarkEvaluation.xaml"
            this.btnRead.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnRead_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnUpdate = ((System.Windows.Controls.Border)(target));
            
            #line 121 "..\..\..\Pages\MarkEvaluation.xaml"
            this.btnUpdate.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnUpdate_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnFScreen = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\..\Pages\MarkEvaluation.xaml"
            this.btnFScreen.Click += new System.Windows.RoutedEventHandler(this.btnFScreen_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 167 "..\..\..\Pages\MarkEvaluation.xaml"
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

