using System;

namespace Millennials.Creator.BaseClass
{
    public static class BaseHiberBaseClass
    {
        public const string baseClassTemplate =

        @"using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;

namespace {0}
{{
    /// <summary>
    /// 数据访问基类
    /// </summary>
    public class NHibernateHelper
    {{
       protected static ISessionFactory session;

       public static ISession GetSession()
       {{
            if(session == null)
            {{
                lock(typeof(NHibernateHelper))
                {{
                    if(session == null)
                    {{
                        Configuration cfg = new Configuration();
                        cfg.AddAssembly(""{1}"");
                        session = cfg.BuildSessionFactory();
                    }}
                }}
            }}
            return session.OpenSession();
       }}
    }}
}}";

    }
}