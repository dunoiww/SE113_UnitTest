﻿#pragma checksum "..\..\..\..\Views\Pages\dashBoardPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B270652F0CB537FE016DB1CF01FFD516F49187C6F168331C4318557C01C71899"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PhongMachTu.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace PhongMachTu.Controllers {
    
    
    /// <summary>
    /// dashBoardPageController
    /// </summary>
    public partial class dashBoardPageController : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\Views\Pages\dashBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgCurrentUser;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Views\Pages\dashBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtCurrentUser;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Views\Pages\dashBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtCurrentUserRole;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\..\Views\Pages\dashBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSumEmployee;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\Views\Pages\dashBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSumPatients;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\..\..\Views\Pages\dashBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView dsBenhNhan;
        
        #line default
        #line hidden
        
        
        #line 308 "..\..\..\..\Views\Pages\dashBoardPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvDoctorOnDashboard;
        
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
            System.Uri resourceLocater = new System.Uri("/PhongMachTu;component/views/pages/dashboardpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\dashBoardPage.xaml"
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
            
            #line 12 "..\..\..\..\Views\Pages\dashBoardPage.xaml"
            ((PhongMachTu.Controllers.dashBoardPageController)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.imgCurrentUser = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.txtCurrentUser = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtCurrentUserRole = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtSumEmployee = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtSumPatients = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.dsBenhNhan = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.lvDoctorOnDashboard = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

