// Updated by XamlIntelliSenseFileGenerator 18/11/2023 4:37:11 am
#pragma checksum "..\..\..\..\Pages\User\CartPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B60ED3353941C3DA3EC765659E2080C3A782DA772614AC879B9073BDB5AA36C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StoreMS.Pages.User;
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


namespace StoreMS.Pages.Cashier
{


    /// <summary>
    /// CartPage
    /// </summary>
    public partial class POS : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StoreMS;component/pages/user/cartpage.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Pages\User\CartPage.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.DataGrid itemsDataGrid;
        internal System.Windows.Controls.Border btnConfirmOrder;
        internal System.Windows.Controls.TextBlock txtConfirmOrder;
        internal System.Windows.Controls.TextBox txtItemName;
        internal System.Windows.Controls.TextBox txtItemQuantity;
        internal System.Windows.Controls.TextBlock txtAdd;
        internal System.Windows.Controls.TextBlock txtAdd2;
        internal System.Windows.Shapes.Path addIcon;
        internal System.Windows.Controls.Border btnAddCart;
        internal System.Windows.Controls.Label lblTotalPrice;
    }
}

