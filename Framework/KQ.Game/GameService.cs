using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KQ.Model;

namespace KQ.Game
{
    /// <summary>
    /// 游戏服务
    /// </summary>
    public class GameService : NotificationObject
    {
        public static GameService Instance { get; private set; }

        static GameService()
        {
            Instance = new GameService();
        }

        /// <summary>
        /// 当前游戏实例
        /// </summary>
        public GameInstance TheGameInstance
        {
            get { return _currentGame; }
            set
            {
                _currentGame = value;
                RaisePropertyChanged("CurrentGame");
            }
        }
        private GameInstance _currentGame;

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            TheGameInstance = new GameInstance();
        }
    }
}
