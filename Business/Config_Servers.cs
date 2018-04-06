using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Common;
using Model;

namespace Business
{
    public class Config_Servers
    {
        public Config_Servers()
        {
            XmlFileExists();
        }
        /// <summary>
        /// XML文件路径
        /// </summary>
        private string XmlFile = string.Format("{0}Config\\Servers.xml", Func.GetAppPath());
        /// <summary>
        /// 检查配置文件是否存在，没有则创建
        /// </summary>
        private void XmlFileExists()
        {
            FileInfo fiXML = new FileInfo(XmlFile);
            if (!(fiXML.Exists))
            {
                XDocument xelLog = new XDocument(
                    new XDeclaration("1.0", "utf-8", string.Empty),
                    new XElement("root")
                 );
                xelLog.Save(XmlFile);
            }
        }
        /// <summary>
        /// 得到所有类命名空间
        /// </summary>
        /// <returns></returns>
        public List<ConfigServers> GetAll()
        {
            List<ConfigServers> list = new List<ConfigServers>();
            try
            {
                XElement xelem = XElement.Load(XmlFile);
                var queryXML = from xele in xelem.Elements("server")
                               select new
                               {
                                   name = xele.Element("name").Value,
                                   type = xele.Element("type").Value,
                                   servername = xele.Element("servername").Value,
                                   database = xele.Element("database").Value,
                                   uid = xele.Element("uid").Value,
                                   pwd = xele.Element("pwd").Value,
                                   port = xele.Element("port").Value,
                                   file = xele.Element("file").Value
                               };
                foreach (var q in queryXML)
                {
                    list.Add(new ConfigServers()
                    {
                        Name = q.name,
                        Database = q.database,
                        file = q.file,
                        Port = q.port,
                        Pwd = q.pwd==null ? "" : Encryption.DesDecrypt(q.pwd),
                        Uid = q.uid,
                        Type = q.type,
                        ServerName = q.servername
                    });
                }

            }
            catch { }
            return list;
        }
        /// <summary>
        /// 添加一个类命名空间
        /// </summary>
        /// <param name="cns"></param>
        public bool Add(ConfigServers cns)
        {
            try
            {

                //先删除
                Delete(cns.Name);
                XElement xelem = XElement.Load(XmlFile);
                XElement newLog = new XElement("server",
                                      new XElement("name", cns.Name),
                                      new XElement("type", cns.Type),
                                      new XElement("servername", cns.ServerName),
                                      new XElement("database", cns.Database),
                                      new XElement("uid", cns.Uid),
                                      new XElement("pwd", cns.Pwd==null ? "" : Encryption.DesEncrypt(cns.Pwd)),
                                      new XElement("port", cns.Port),
                                      new XElement("file", cns.file)
                                  );
                xelem.Add(newLog);
                xelem.Save(XmlFile);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 保存类命名空间
        /// </summary>
        /// <param name="cns"></param>
        /// <returns></returns>
        public bool Save(ConfigServers cns, string oldmodel = "")
        {
            if (oldmodel!=null)
                Delete(oldmodel);
            return Add(cns);
        }
        /// <summary>
        /// 删除一个命名空间
        /// </summary>
        /// <param name="namespace1"></param>
        /// <returns></returns>
        public bool Delete(string name)
        {
            try
            {
                XElement xelem = XElement.Load(XmlFile);
                var queryXML = from xele in xelem.Elements("server")
                               where xele.Element("name").Value == name
                               select xele;
                queryXML.Remove();
                xelem.Save(XmlFile);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 查询一个命名空间
        /// </summary>
        /// <param name="namespace1"></param>
        /// <returns></returns>
        public ConfigServers Get(string name)
        {
            try
            {
                XElement xelem = XElement.Load(XmlFile);
                var queryXML = from xele in xelem.Elements("namespaceclass")
                               where xele.Element("model").Value == name
                               select new
                               {
                                   name = xele.Element("name").Value,
                                   type = xele.Element("type").Value,
                                   servername = xele.Element("servername").Value,
                                   database = xele.Element("database").Value,
                                   uid = xele.Element("uid").Value,
                                   pwd = xele.Element("pwd").Value,
                                   port = xele.Element("port").Value,
                                   file = xele.Element("file").Value
                               };
                ConfigServers cns = new ConfigServers();
                if (queryXML.Count() > 0)
                {
                    var q = queryXML.First();
                    cns.Name = q.servername + q.type;
                    cns.Database = q.database;
                    cns.file = q.file;
                    cns.Port = q.port;
                    cns.Pwd = q.pwd==null ? "" : Encryption.DesDecrypt(q.pwd);
                    cns.Uid = q.uid;
                    cns.Type = q.type;
                    cns.ServerName = q.servername;
                }
                return cns;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询默认命名空间
        /// </summary>
        /// <param name="namespace1"></param>
        /// <returns></returns>
        public ConfigServers GetDefault(DatabaseType dbType = DatabaseType.Empty)
        {
            var list = GetAll();
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                if (dbType == DatabaseType.Empty)
                {
                    return list.Last();
                }
                else
                {
                    var li = list.Where(p => p.Type == dbType.ToString());
                    var rli = li.Count() > 0 ? li.Last() : null;
                    return rli;
                }
            }

        }
    }
    public class ConfigServers
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 服务器
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 数据库
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// 数据库文件
        /// </summary>
        public string file { get; set; }

    }
    public class Encryption
    {
        public Encryption()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        private static string encryptKey = "xd!@E$fGs$i#d3E5%)8-5(5*er34/WaR";
        //默认密钥向量
        private static byte[] Keys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public static string DesEncrypt(string encryptString)
        {
            if (string.IsNullOrEmpty(encryptString))
                return string.Empty;
            RijndaelManaged rijndaelProvider = new RijndaelManaged();
            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            rijndaelProvider.IV = Keys;
            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString"></param>
        /// <returns></returns>
        public static string DesDecrypt(string decryptString)
        {
            if (string.IsNullOrEmpty(decryptString))
                return string.Empty;
            try
            {
                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
                rijndaelProvider.IV = Keys;
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch
            {
                return "";
            }

        }
    }
}
