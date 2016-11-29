using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KQ.Core;
using KQ.Game;
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
                GameInstance curGame = Services.Game.TheGameInstance;
                return curGame.CurrentMap;
            }
        }

        public GameInstance CurrentGame
        {
            get { return Services.Game.TheGameInstance; }
        }

    }
}
