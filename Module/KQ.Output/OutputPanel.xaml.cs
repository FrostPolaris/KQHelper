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
using KQ.Basic;

namespace KQ.Output
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class OutputPanel : UserControl
    {
        public OutputPanel()
        {
            InitializeComponent();
            Logger.LogRecorded += Logger_LogRecorded;
        }

        private void Logger_LogRecorded(string outputStr)
        {
            TextBox_Output.Text += string.Format("{0}\n", outputStr);
            ScrollViewer_OutputText.ScrollToEnd();
        }
    }
}
