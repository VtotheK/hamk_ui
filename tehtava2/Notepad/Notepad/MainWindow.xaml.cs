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

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNewFile(object sender, RoutedEventArgs e)
        {
            if (filePath == null)
            {
                Notepad_text.Text = "";
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to open a new file? All unsaved work will be erased.", "Message",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    filePath = "";
                    Notepad_text.Text = "";
                }
            }
        }
    }
}