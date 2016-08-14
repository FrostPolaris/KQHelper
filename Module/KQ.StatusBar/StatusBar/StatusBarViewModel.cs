using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KQ.Core;
using KQ.GamePlay;
using KQ.Model;

namespace KQ.StatusBar
{
    class StatusBarViewModel
    {
        /// <summary>
        /// 当前地图
        /// </summary>
        public Map CurrentMap
        {
            get
            {
                Game curGame = Services.GameService.CurrentGame;
                return curGame.CurrentMap;
            }
        }

        public Game CurrentGame
        {
            get { return Services.GameService.CurrentGame; }
        }

    }
}
