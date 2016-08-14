using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Core
{
    /// <summary>
    /// 主窗口管理器
    /// </summary>
    public class MainWindowController
    {
        /// <summary>
        /// 实例
        /// </summary>
        public static MainWindowController Instance { get; private set; }

        /// <summary>
        /// 静态构造
        /// </summary>
        static MainWindowController()
        {
            Instance = new MainWindowController();
        }

        private List<IMainWindowContent> contentList = new List<IMainWindowContent>();

        /// <summary>
        /// 注册主窗口内容
        /// </summary>
        /// <param name="content">主窗口内容</param>
        public void RegistContent(IMainWindowContent content)
        {
            contentList.Add(content);
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        /// <param name="contentName"></param>
        /// <returns></returns>
        public IMainWindowContent GetContent(string contentName)
        {
            if (string.IsNullOrEmpty(contentName))
                return null;

            foreach(IMainWindowContent content in contentList)
            {
                if (contentName.Equals(content.ContentName))
                    return content;
            }

            return null;
        }
    }
}
