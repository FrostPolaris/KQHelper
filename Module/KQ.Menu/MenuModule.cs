﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KQ.Core;

namespace KQ.Editor.Menu
{
    public class MenuModule : IWidgetModule
    {
        public EModuleType ModuleType
        {
            get { return EModuleType.EditorMenu; }
        }

        private MainMenu theMainMenu;

        public UserControl GetWidget()
        {
            return theMainMenu;
        }

        public void Initialize()
        {
            theMainMenu = new MainMenu();
        }
    }
}
