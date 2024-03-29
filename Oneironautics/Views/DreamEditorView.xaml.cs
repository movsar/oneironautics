﻿using ControlzEx.Theming;
using Data.Interfaces;
using DesktopApp.Models;
using DesktopApp.Stores;
using MahApps.Metro.Controls;
using DesktopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopApp.Views
{
    /// <summary>
    /// Interaction logic for DreamEditor.xaml
    /// </summary>
    public partial class DreamEditorView : MetroWindow
    {
        public DreamEditorView(JournalStore journalStore, string? dreamId = null)
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Dark.Cyan");
            DataContext = new DreamEditorViewModel(journalStore, dreamId);
        }
    }
}
