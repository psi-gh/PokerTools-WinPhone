﻿#pragma checksum "C:\Users\surfrider\Documents\Visual Studio 2010\Projects\PokerTools\PivotApp2\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D35C3815F61B563B29ABA2ED7AB9F30F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.225
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
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


namespace PokerTools {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid firstGrid;
        
        internal System.Windows.Controls.Canvas canvasFirstPivotItem;
        
        internal System.Windows.Controls.Grid playersCardsGrid;
        
        internal System.Windows.Controls.ItemsControl upperPanel;
        
        internal System.Windows.Controls.Grid tableCardsGrid;
        
        internal System.Windows.Controls.ItemsControl ItPanel;
        
        internal System.Windows.Controls.Grid bottomGrid;
        
        internal System.Windows.Controls.Grid cardBoardGrid;
        
        internal System.Windows.Controls.ItemsControl cardBoardPanel;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PivotApp2;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.firstGrid = ((System.Windows.Controls.Grid)(this.FindName("firstGrid")));
            this.canvasFirstPivotItem = ((System.Windows.Controls.Canvas)(this.FindName("canvasFirstPivotItem")));
            this.playersCardsGrid = ((System.Windows.Controls.Grid)(this.FindName("playersCardsGrid")));
            this.upperPanel = ((System.Windows.Controls.ItemsControl)(this.FindName("upperPanel")));
            this.tableCardsGrid = ((System.Windows.Controls.Grid)(this.FindName("tableCardsGrid")));
            this.ItPanel = ((System.Windows.Controls.ItemsControl)(this.FindName("ItPanel")));
            this.bottomGrid = ((System.Windows.Controls.Grid)(this.FindName("bottomGrid")));
            this.cardBoardGrid = ((System.Windows.Controls.Grid)(this.FindName("cardBoardGrid")));
            this.cardBoardPanel = ((System.Windows.Controls.ItemsControl)(this.FindName("cardBoardPanel")));
        }
    }
}

