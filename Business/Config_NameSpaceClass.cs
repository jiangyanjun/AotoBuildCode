using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Common;
using Model;

namespace Business
{
    public class Config_NameSpaceClass
    {
        public Config_NameSpaceClass()
        {
            XmlFileExists();
        }
        /// <summary>
        /// XML文件路径
        /// </summary>
        private string XmlFile = string.Format("{0}Config\\NameSpaceClass.xml", Func.GetAppPath());
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
        public List<ConfigNameSpaceClass> GetAll()
        {
            List<ConfigNameSpaceClass> list = new List<ConfigNameSpaceClass>();
            try
            {
                XElement xelem = XElement.Load(XmlFile);
                var queryXML = from xele in xelem.Elements("namespaceclass")
                               select new
                               {
                                   model = xele.Element("model").Value,
                                   data = xele.Element("data").Value,
                                   business = xele.Element("business").Value,
                                   interface1 = xele.Element("interface").Value,
                                   factory = xele.Element("factory").Value
                               };
                foreach (var q in queryXML)
                {
                    list.Add(new ConfigNameSpaceClass()
                    {
                        Model = q.model,
                        Data = q.data,
                        Business = q.business,
                        Factory = q.factory,
                        Interface = q.interface1
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
        public bool Add(ConfigNameSpaceClass cns)
        {
            try
            {
                //先删除
                Delete(cns.Model);
                XElement xelem = XElement.Load(XmlFile);
                XElement newLog = new XElement("namespaceclass",
                                      new XElement("model", cns.Model),
                                      new XElement("data", cns.Data),
                                      new XElement("business", cns.Business),
                                      new XElement("interface", cns.Interface),
                                      new XElement("factory", cns.Factory)
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
        public bool Save(ConfigNameSpaceClass cns, string oldmodel = "")
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
        public bool Delete(string model)
        {
            try
            {
                XElement xelem = XElement.Load(XmlFile);
                var queryXML = from xele in xelem.Elements("namespaceclass")
                               where xele.Element("model").Value == model
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
        public ConfigNameSpaceClass Get(string model)
        {
            try
            {
                XElement xelem = XElement.Load(XmlFile);
                var queryXML = from xele in xelem.Elements("namespaceclass")
                               where xele.Element("model").Value == model
                               select new
                               {
                                   model = xele.Element("model").Value,
                                   data = xele.Element("data").Value,
                                   business = xele.Element("business").Value,
                                   interface1 = xele.Element("interface").Value,
                                   factory = xele.Element("factory").Value,
                                   isdefault = xele.Element("isdefault").Value.ToLower()
                               };
                ConfigNameSpaceClass cns = new ConfigNameSpaceClass();
                if (queryXML.Count() > 0)
                {
                    cns.Model = queryXML.First().model;
                    cns.Data = queryXML.First().data;
                    cns.Business = queryXML.First().business;
                    cns.Interface = queryXML.First().interface1;
                    cns.Factory = queryXML.First().factory;
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
        public ConfigNameSpaceClass GetDefault()
        {
            var list = GetAll();
            if (list.Count == 0)
            {
                return new ConfigNameSpaceClass()
                {
                    Model = "Model",
                    Data = "Data",
                    Business = "Business",
                    Factory = "Factory",
                    Interface = "IData"
                };
            }
            else
            {
                return list.Last();
            }

        }
    }
    public class Config_NameSpace
    {
        public Config_NameSpace()
        {
            XmlFileExists();
        }
        /// <summary>
        /// XML文件路径
        /// </summary>
        private string XmlFile = string.Format("{0}Config\\NameSpace.xml", Func.GetAppPath());
        /// <summary>
        /// 得到所有命名空间
        /// </summary>
        /// <returns></returns>
        public List<ConfigNameSpace> GetAll()
        {
            List<ConfigNameSpace> list = new List<ConfigNameSpace>();
            try
            {
                XElement xelem = XElement.Load(XmlFile);
                var queryXML = from xele in xelem.Elements("namespace")
                               select new
                               {
                                   name1 = xele.Element("namespace1").Value,
                                   name2 = xele.Element("namespace2").Value
                               };
                foreach (var q in queryXML.OrderBy(p => p.name1))
                {
                    list.Add(new ConfigNameSpace()
                    {
                        Name1 = q.name1,
                        Name2 = q.name2
                    });
                }
            }
            catch { }
            return list;
        }
        /// <summary>
        /// 添加一个命名空间
        /// </summary>
        /// <param name="cns"></param>
        public bool Add(ConfigNameSpace cns)
        {
            try
            {
                //先删除
                Delete(cns.Name1);
                XElement xelem = XElement.Load(XmlFile);
                XElement newLog = new XElement("namespace",
                                      new XElement("namespace1", cns.Name1),
                                      new XElement("namespace2", cns.Name2)
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
        /// 保存命名空间
        /// </summary>
        /// <param name="cns"></param>
        /// <returns></returns>
        public bool Save(ConfigNameSpace cns, string oldname1 = "")
        {
            if (oldname1!=null)
                Delete(oldname1);
            return Add(cns);
        }
        /// <summary>
        /// 删除一个命名空间
        /// </summary>
        /// <param name="namespace1"></param>
        /// <returns></returns>
        public bool Delete(string namespace1)
        {
            try
            {
                XElement xelem = XElement.Load(XmlFile);
                var queryXML = from xele in xelem.Elements("namespace")
                               where xele.Element("namespace1").Value == namespace1
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
        public ConfigNameSpace Get(string namespace1)
        {
            try
            {
                XElement xelem = XElement.Load(XmlFile);
                var queryXML = from xele in xelem.Elements("namespace")
                               where xele.Element("namespace1").Value == namespace1
                               select new
                               {
                                   name1 = xele.Element("namespace1").Value,
                                   name2 = xele.Element("namespace2").Value,
                                   isdefault = xele.Element("isdefault").Value.ToLower()
                               };
                ConfigNameSpace cns = new ConfigNameSpace();
                if (queryXML.Count() > 0)
                {
                    cns.Name1 = queryXML.First().name1;
                    cns.Name2 = queryXML.First().name2;
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
        public ConfigNameSpace GetDefault()
        {
            var list = GetAll();
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list.Last();
            }

        }

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
    }
    public class ConfigNameSpace
    {
        /// <summary>
        /// 一级命名空间
        /// </summary>
        public string Name1 { get; set; }
        /// <summary>
        /// 二级命名空间
        /// </summary>
        public string Name2 { get; set; }

    }
}
