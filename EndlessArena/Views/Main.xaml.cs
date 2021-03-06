﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EndlessArena.Utilities;
using EndlessArena.Utilities.Messages;

namespace EndlessArena.Views
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            Messenger.Subscribe<CloseWindowMessage>(a => Close());
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Messenger.Publish(new KeyDownMessage(e.Key));
        }
    }
}
