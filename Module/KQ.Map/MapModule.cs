using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KQ.Core;

namespace KQ.Editor.MapPanel
{
    public class MapModule : IWidgetModule
    {
        EModuleType IModule.ModuleType
        {
            get { return EModuleType.EditorMap; }
        }

        private MapPanel mapPanel = new MapPanel();

        UserControl IWidgetModule.GetWidget()
        {
            return mapPanel;
        }

        void IModule.Initialize()
        {
            mapPanel.Initialize();
        }
    }
}
