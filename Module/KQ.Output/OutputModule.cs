using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KQ.Core;

namespace KQ.Output
{
    public class OutputModule : IWidgetModule
    {
        public EModuleType ModuleType
        {
            get { return EModuleType.Output; }
        }

        private OutputPanel widget;

        public UserControl GetWidget()
        {
            return widget;
        }

        public void Initialize()
        {
            widget = new OutputPanel();
        }
    }
}
