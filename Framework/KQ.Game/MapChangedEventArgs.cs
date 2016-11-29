using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KQ.Model;

namespace KQ.Game
{
    public class MapChangedEventArgs : EventArgs
    {
        public Map NewMap { get; private set; }

        MapChangedEventArgs(Map newMap)
        {
            this.NewMap = newMap;
        }
    }
}
