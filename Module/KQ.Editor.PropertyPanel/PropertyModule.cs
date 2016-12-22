using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KQ.Core;

namespace KQ.Editor.PropertyPanel
{
    public class PropertyModule : IWidgetModule
    {
        public EModuleType ModuleType
        {
            get { return EModuleType.EditorProperty; }
        }

        private PropertyPanelWidget propertyWidget;

        public UserControl GetWidget()
        {
            return propertyWidget;
        }

        public void Initialize()
        {
            propertyWidget = new PropertyPanelWidget();
        }
    }
}
