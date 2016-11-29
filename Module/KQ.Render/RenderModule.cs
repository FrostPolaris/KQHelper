using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KQ.Core;

namespace KQ.Render
{
    public class RenderModule : IWidgetModule
    {
        EModuleType IModule.ModuleType
        {
            get { return EModuleType.Render; }
        }

        private MainCanvas theMainCanvas = new MainCanvas();

        UserControl IWidgetModule.GetWidget()
        {
            return theMainCanvas;
        }

        void IModule.Initialize()
        {
        }
    }
}
