using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSHFrom
{
    /// <summary>
    /// 实现对app.config 的修改
    /// </summary>
    public class Config
    {
        /// <summary>
        /// app.config路径
        /// </summary>
        public static string FileName = System.IO.Path.GetFileName(Application.ExecutablePath);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AddSetting(string key, string value)
        {
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(FileName);
            config.AppSettings.Settings.Add(key, value);
            config.Save();
            return true;
        }
        /// <summary>
        /// 获取key的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSetting(string key)
        {
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(FileName);
            if (config.AppSettings.Settings[key] == null) return null;
            return config.AppSettings.Settings[key].Value; 
        }
        /// <summary>
        /// 修改key的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static bool UpdateSeeting(string key, string newValue)
        {
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(FileName);
            string value = config.AppSettings.Settings[key].Value = newValue; 
            config.Save();
            return true;
        }
    }
}
