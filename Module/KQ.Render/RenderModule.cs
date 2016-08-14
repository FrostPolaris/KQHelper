using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KQ.Core;

namespace KQ.Render
{
    public class RenderModule : IModule
    {
        public string ModuleName
        {
            get { return "RenderModule"; }
        }

        private MainCanvas theMainCanvas = new MainCanvas();

        public void Initialize()
        {
            MainWindowController.Instance.RegistContent(theMainCanvas);
        }
    }
}
