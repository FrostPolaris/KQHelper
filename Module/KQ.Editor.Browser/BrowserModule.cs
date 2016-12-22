using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KQ.Core;

namespace KQ.Editor.Browser
{
    class BrowserModule : IWidgetModule
    {
        public EModuleType ModuleType
        {
            get { return EModuleType.EditorBrowser; }
        }

        private DataBrowser theBrowserWidget;

        public UserControl GetWidget()
        {
            return theBrowserWidget;
        }

        public void Initialize()
        {
            theBrowserWidget = new DataBrowser();
        }
    }
}
