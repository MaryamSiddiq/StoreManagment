﻿#pragma checksum "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "217638E2CCEE0EA7ECC1902ECF22AF778DDE21DBF89F4C2042B04173A771E825"
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
    /// SignInL
    /// </summary>
    public partial class SignInL : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStaffID;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSignUp;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border btnSignIn;
        
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
            System.Uri resourceLocater = new System.Uri("/LibraryMS;component/pages/librarian%20-%20copy/signinl.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
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
            
            #line 47 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.btnReset_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtStaffID = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
            this.txtStaffID.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 63 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
            this.txtStaffID.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 70 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
            this.txtPassword.GotFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_GotFocus);
            
            #line default
            #line hidden
            
            #line 71 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
            this.txtPassword.LostFocus += new System.Windows.RoutedEventHandler(this.txtLabelPlace_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnSignUp = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
            this.btnSignUp.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnSignUp_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSignIn = ((System.Windows.Controls.Border)(target));
            
            #line 89 "..\..\..\..\Pages\Librarian - Copy\SignInL.xaml"
            this.btnSignIn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnSignIn_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
