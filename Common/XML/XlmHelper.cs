using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Common
{
    public class XlmHelper
    {
        public static string GetSetMark(string Mark)
        {
            List<string> list = new List<string>();
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\SysConfig.xml";
                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/Flage/Mark");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {
                    string sf = DCintances[i].Attributes["id"].Value;
                    if (sf == Mark.ToString())
                    {
                        return DCintances[i].Attributes["Name"].Value;
                    }
                }
            }
            catch
            {
                return "NG";
            }
            return "Mark NOT Data";
        }
        public static string GetSetSAPReason()
        {
            string list = "停售";
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\SysConfig.xml";
                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/Scrappingreason/SAPReason");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {
                    return DCintances[i].Attributes["Name"].Value;
                }
            }
            catch
            {
                return list;
            }
            return list;
        }
        /// <summary>
        /// 报废原因
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSetReason()
        {
            List<string> list = new List<string>();
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\SysConfig.xml";
                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/Scrappingreason/Reason");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {
                    list.Add(DCintances[i].Attributes["Name"].Value);
                }
            }
            catch
            {
                return null;
            }
            return list;
        }
        public static bool GetDB()
        {
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\SysConfig.xml";
                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/DataBase/Db");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {
                    bool selected = bool.Parse(DCintances[i].Attributes["Selected"].Value);
                    return selected;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool IsRecordLog()
        {
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\SysConfig.xml";
                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/Log/RecordLog");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {
                    bool selected = bool.Parse(DCintances[i].Attributes["Selected"].Value);
                    return selected;
                }
            }
            catch
            {
                return true;
            }
            return true;
        }

        public static string GetMenuText(int str)
        {
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\SysConfig.xml";
                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                //instances下所有instance节点
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/Menu/menu");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {
                    string sf = DCintances[i].Attributes["id"].Value;
                    if (sf == str.ToString())
                    {
                        return DCintances[i].Attributes["Name"].Value;
                    }
                }
                return "";
            }
            catch
            {
                return null;
            }
        }
        public static List<KeyValuePair<string, bool>> GetSelectDC()
        {
            try
            {
                List<KeyValuePair<string, bool>> DCList = new List<KeyValuePair<string, bool>>();
                KeyValuePair<string, bool> readone;
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\SysConfig.xml";


                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                //string defaultInstaceName = doc.SelectSingleNode("configuration/instances").Attributes["defaultInstance"].Value;

                //instances下所有instance节点
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/DCConfig/DC");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {

                    //遍历instance对应的connectionString
                    string DCName = DCintances[i].Attributes["Name"].Value;
                    bool selected = bool.Parse(DCintances[i].Attributes["Selected"].Value);
                    readone = new KeyValuePair<string, bool>(DCName, selected);
                    DCList.Add(readone);
                }
                return DCList;
            }
            catch
            {
                return null;
            }
        }
        public static string GetHeaderText(string str)
        {
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\HeaderSysConfig.xml";
                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                //instances下所有instance节点
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/HeaderText/text");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {
                    string sf=DCintances[i].Attributes["id"].Value;
                    if (sf == str)
                    { 
                  return DCintances[i].Attributes["Name"].Value;
                    }
                }
                return "";
            }
            catch
            {
                return null;
            }
        }
        public static string GetSQlScript(int str)
        {
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\SqlScript.xml";
                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                //instances下所有instance节点
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/DataTable/TB");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {
                    string sf = DCintances[i].Attributes["id"].Value;
                    if (sf == str.ToString())
                    {
                        return DCintances[i].Attributes["Name"].Value;
                    }
                }
                return "";
            }
            catch
            {
                return null;
            }
        }
        public static string GetNpiHeaderText(string str)
        {
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\HeaderSysConfig.xml";
                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                //instances下所有instance节点
                XmlNodeList DCintances = doc.SelectNodes("ConfigElemment/NPIHeaderText/text");
                //遍历，放入缓存
                for (int i = 0; i < DCintances.Count; i++)
                {
                    string sf = DCintances[i].Attributes["id"].Value;
                    if (sf == str)
                    {
                        return DCintances[i].Attributes["Name"].Value;
                    }
                }
                return "";
            }
            catch
            {
                return null;
            }
        }
        public static void UpdateNodes(string nodepath, List<KeyValuePair<string, bool>> selectnodelist)
        {
            try
            {
                string ConfigFile = Application.StartupPath + "\\ConfigFiles\\SysConfig.xml";


                //读取所有配置信息
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFile);
                //string defaultInstaceName = doc.SelectSingleNode("configuration/instances").Attributes["defaultInstance"].Value;

                //instances下所有instance节点
                XmlNodeList nodeintances = doc.SelectNodes(nodepath);
                //遍历，放入缓存
                for (int i = 0; i < nodeintances.Count; i++)
                {

                    //遍历instance对应的connectionString
                    string Name = nodeintances[i].Attributes["Name"].Value;
                    List<KeyValuePair<string,bool>> foundone=selectnodelist.FindAll(delegate( KeyValuePair<string,bool> temp)
                    {
                        return temp.Key == Name;
                    });
                    if (foundone != null)
                    {
                        nodeintances[i].Attributes["Selected"].Value = foundone[0].Value.ToString().ToUpper();
                    }
                  
                }
                doc.Save(ConfigFile);
            }
            catch
            {
                ;
            }
        }
    }
}
